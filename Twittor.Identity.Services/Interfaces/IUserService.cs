using System.Threading.Tasks;
using Twittor.Identity.DataAccess.Entities;

namespace Twittor.Identity.Services
{
    public interface IUserService
    {
        Task<User> FindUserByEmailAsync(string email);
        Task<User> CreateUser(string email, string password);
        Task<bool> IsUserPassword(string email, string password);
    }
}
