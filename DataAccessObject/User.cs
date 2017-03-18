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
        public ObjectId Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int __v { get; set; }
    }
}
