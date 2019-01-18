using System.Collections.Generic;
using Twitter.Identity.DataAccess.Entities;

namespace Twittor.Identity.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        void CreateUser();
    }
}
