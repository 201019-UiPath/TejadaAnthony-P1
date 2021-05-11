using StoreAppDB.Models;
using System.Collections.Generic;
namespace StoreAppDB.Interfaces
{
    public interface IUserRepoActions
    {
        void AddUser(User user);
        void UpdateUser(User user);
        User GetUserById(int id);
        User GetUserByEmail(string email);
        List<User> GetAllUsers();
        void DeleteUser(User user);
    }
}