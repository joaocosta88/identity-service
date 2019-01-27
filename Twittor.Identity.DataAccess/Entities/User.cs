using System;

namespace Twittor.Identity.DataAccess.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }

        protected User() { }

        public User(string email, string password, byte[] salt)
        {
            Email = email;
            Password = password;
            Salt = salt;
        }
    }
}
