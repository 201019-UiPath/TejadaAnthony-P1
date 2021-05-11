using StoreAppDB.Models;
using StoreAppDB.Interfaces;
using StoreAppDB;
using System.Collections.Generic;

namespace StoreAppLib
{
    public class UserService : IUserService
    {
        private StoreAppContext context;
        private IUserRepoActions repo;

        public UserService(StoreAppContext context, IUserRepoActions repo)
        {
            this.repo = repo;
            this.context = context;

        }

        public void AddUser(User user)
        {
            repo.AddUser(user);
        }

        public void DeleteUser(User user)
        {
            repo.DeleteUser(user);
        }

        public List<User> GetAllUsers()
        {
            return repo.GetAllUsers();
        }

        public User GetUserByEmail(string email)
        {
            return repo.GetUserByEmail(email);
        }

        public User GetUserById(int id)
        {
            return repo.GetUserById(id);
        }

        public void UpdateUser(User user)
        {
            repo.UpdateUser(user);
        }
    }
}