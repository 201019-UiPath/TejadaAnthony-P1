using StoreAppDB.Models;
using System.Collections.Generic;

namespace StoreAppLib
{
    public interface IUserService
    {
        void AddUser(User user);
        void DeleteUser(User user);
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        void UpdateUser(User user);
    }
}