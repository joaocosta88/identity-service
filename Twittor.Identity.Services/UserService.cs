using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task CreateUser()
        {
            await DataContext.Users.AddAsync(new User()
            {
                Email = "testing"
            });

            DataContext.SaveChanges();
        }
    }
}
