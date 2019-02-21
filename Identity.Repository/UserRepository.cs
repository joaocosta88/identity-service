using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Identity.DataAccess;
using Identity.DataAccess.Entities;
using Identity.Repository.Interfaces;

namespace Identity.Repository
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
