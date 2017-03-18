using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataAccess.Test
{
    [TestFixture]
    public class MongoDBTest
    {
        [Test]
        public void CheckConnectionToLocalMongoDB()
        {
            MongoDB mongo = new MongoDB();
            var isActive = mongo.CheckConnection();

            Assert.IsTrue(isActive);

        }

        [Test]
        public void ShouldReturnsAllUsers()
        {
            MongoDB mongo = new MongoDB();
            var users = mongo.GetAllUsers();

            CollectionAssert.AllItemsAreUnique(users);
        }
    }
}
