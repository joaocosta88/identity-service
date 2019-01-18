using System.Collections.Generic;
using Twittor.Identity.DataAccess;
using Twittor.Identity.DataAccess.Entities;

namespace Twittor.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext DataContext;

        public UserService(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IEnumerable<User> GetAll()
        {
            return DataContext.Users;
        }

        public void CreateUser()
        {
            DataContext.Users.Add(new User()
            {

            });

            DataContext.SaveChanges();
        }
    }
}
