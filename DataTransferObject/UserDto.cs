using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccessObject;
using MongoDB.Bson;

namespace DataTransferObject
{
    public class UserDto
    {
        private IDataAccess _dataAccess;
        public UserDto(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public User GetUser(ObjectId id)
        {
            return _dataAccess.GetUserById(id);
        }

        public List<User> GetUsers()
        {
            return _dataAccess.GetAllUsers();
        } 

        public void EditUser(User user)
        {
            _dataAccess.UpdateUser(user);
        }

        public void AddUser(User user)
        {
            _dataAccess.InserUser(user);
        }

        public void AddUsers(List<User> users)
        {
            _dataAccess.InserUsers(users);
        }

        public void DeleteUser(ObjectId id)
        {
            _dataAccess.RemoveUser(id);
        }
    }
}
