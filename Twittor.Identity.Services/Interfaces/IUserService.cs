using System.Threading.Tasks;
using Twittor.Identity.Services.Models;

namespace Twittor.Identity.Services
{
    public interface IUserService
    {
        Task<UserDTO> FindUserByEmailAsync(string email);
        Task<UserDTO> CreateUser(string email, string password);
        Task<bool> IsUserPassword(string email, string password);
    }
}
