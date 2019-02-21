using System;
using System.Threading.Tasks;
using Identity.DataAccess.Entities;
using Identity.Repository.Interfaces;
using Identity.Services.Helpers;
using Identity.Services.Models;
using Identity.Services.Validators;

namespace Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task<UserDTO> FindUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email parameter cannot be null");
            }

            email = email.Trim();

            var user = await UserRepository.FindUserAsync(email);
            return user != null ? new UserDTO(user.Email, user.Password) : null;
        }

        public async Task<UserDTO> CreateUser(string email, string password)
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
            var savedUser = await UserRepository.SaveUserAsync(user);

            return savedUser != null ? new UserDTO(savedUser.Email, savedUser.Password) : null;
        }

        public async Task<bool> IsUserPassword(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
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
