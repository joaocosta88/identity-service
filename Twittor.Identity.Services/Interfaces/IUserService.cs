using System.Collections.Generic;
using System.Threading.Tasks;
using Twittor.Identity.DataAccess.Entities;

namespace Twittor.Identity.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        Task CreateUser(User user);
    }
}
