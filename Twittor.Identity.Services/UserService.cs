using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twittor.Identity.DataAccess.Entities;
using Twittor.Identity.Repository.Interfaces;

namespace Twittor.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        
        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email parameter cannot be null");
            }

            email = email.Trim();

            return await UserRepository.FindUserAsync(email);
        }

        public async Task<User> CreateUser(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {

            }
            if(string.IsNullOrWhiteSpace(password))
            {

            }

            //validate email
            email = email.Trim();

            //validate password
            password = password.Trim();

            return new User();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task CreateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
