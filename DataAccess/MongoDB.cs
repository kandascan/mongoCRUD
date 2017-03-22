using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace DataAccess
{
    public class MongoDB : IDataAccess
    {
        private MongoDatabase MongoDatabase { get; set; }

        private const string localConnectionString = "mongodb://localhost:27017";
        private const string mLabUser = "pepisboczek";
        private const string mLabPass = "h2h4wkrpfv";
        private const string Collection = "users";
        private const string dataBaseName = "mywalletdb";
        private const string mLabConnectionString = "mongodb://" + mLabUser + ":" + mLabPass + "@ds117899.mlab.com:17899/" + dataBaseName;

        public MongoDB()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(mLabConnectionString));
            MongoClient mongoClient = new MongoClient(settings);
            var server = mongoClient.GetServer();
            MongoDatabase = server.GetDatabase(dataBaseName);
        }

        public bool CheckConnection()
        {
            var client = new MongoClient(mLabConnectionString);
            var server = client.GetServer();
            try
            {
                server.Connect();
                server.Disconnect();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return MongoDatabase.GetCollection<User>(Collection).FindAll().ToList();
        }

        public User GetUserById(ObjectId id)
        {
            return MongoDatabase.GetCollection<User>(Collection).FindOneById(id);
        }

        public void InserUser(User user)
        {
            var collection = MongoDatabase.GetCollection<User>(Collection);
            collection.Insert(user);
        }

        public void UpdateUser(User user)
        {
            var collection = MongoDatabase.GetCollection<User>(Collection);
            IMongoQuery query = Query.EQ("_id", user.Id);
            IMongoUpdate update = Update.Set("username", user.username)
                .Set("email", user.email).Set("password", user.password);

            collection.FindAndModify(query, SortBy.Null, update);
        }

        public void RemoveUser(ObjectId id)
        {
            var collection = MongoDatabase.GetCollection<User>(Collection);
            IMongoQuery query = Query.EQ("_id", id);
            collection.Remove(query);
        }
        
        public void InserUsers(List<User> users)
        {
            var collection = MongoDatabase.GetCollection<User>(Collection);
            collection.InsertBatch(users);
        }

        public void UpdateAddressTableInUserObject(User user) // This object should contain few addresses
        {
            var collection = MongoDatabase.GetCollection<User>(Collection);
            collection.Save(user);
        }
    }
}
