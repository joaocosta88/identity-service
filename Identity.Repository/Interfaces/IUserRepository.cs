using System.Threading.Tasks;
using Identity.DataAccess.Entities;

namespace Identity.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> SaveUserAsync(User user);
        Task<User> FindUserAsync(string email);
    }
}
