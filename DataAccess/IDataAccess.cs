using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;
using MongoDB.Bson;

namespace DataAccess
{
    public interface IDataAccess
    {
        bool CheckConnection();
        List<User> GetAllUsers();
        User GetUserById(ObjectId id);
        void InserUser(User user);
        void InserUsers(List<User> users);
        void UpdateUser(User user);
        void RemoveUser(ObjectId id);
    }
}
