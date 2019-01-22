using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Twittor.Identity.DataAccess;
using Twittor.Identity.DataAccess.Entities;
using Twittor.Identity.Repository.Interfaces;

namespace Twittor.Identity.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext DbContext;

        public UserRepository(DataContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<User> FindUserAsync(string email)
        {
            return await DbContext.Users.FirstOrDefaultAsync(m => m.Email.Equals(email));
        }

        public async Task<User> SaveUserAsync(User user)
        {
            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();

            return user;
        }
    }
}
