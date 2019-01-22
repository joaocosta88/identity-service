using System.Threading.Tasks;
using Twittor.Identity.DataAccess.Entities;

namespace Twittor.Identity.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> SaveUserAsync(User user);
        Task<User> FindUserAsync(string email);
    }
}
