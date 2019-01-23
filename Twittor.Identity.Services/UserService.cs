using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twittor.Identity.DataAccess.Entities;
using Twittor.Identity.Repository.Interfaces;
using Twittor.Identity.Services.Helpers;
using Twittor.Identity.Services.Validators;

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
            //validate email
            email = email.Trim();
            if (!UserModelValidator.IsUserEmailValid(email))
            {
                throw new ArgumentException("Email format is not valid");
            }

            //validate password
            password = password.Trim();
            if (!UserModelValidator.IsUserPasswordValid(password))
            {
                throw new ArgumentException("Password format is not valid");
            }

            var hashedPasswordWithSalt = CryptoUtils.HashPassword(password);
            var user = new User(email, hashedPasswordWithSalt.hashedPassword, hashedPasswordWithSalt.salt);
            return await UserRepository.SaveUserAsync(user);
        }

        public async Task<bool> IsUserPassword(string email, string password)
        {
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException();
            }

            var user = await UserRepository.FindUserAsync(email);
            if (user == null)
            {
                throw new ArgumentException();
            }

            var hashedPassword = CryptoUtils.HashPassword(password, user.Salt);
            return hashedPassword == user.Password;
        }
    }
}
