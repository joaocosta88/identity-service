using System.Collections.Generic;
using Twittor.Identity.DataAccess.Entities;

namespace Twittor.Identity.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        void CreateUser();
    }
}
