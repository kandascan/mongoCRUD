using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessObject
{
    public class User
    {
        User()
        {
            addresses = new List<Address>();
        }
        public ObjectId Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public IEnumerable<Address> addresses { get; set; }
        public int __v { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public string houseNumber { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
    }
}
