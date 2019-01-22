using System.Security.Cryptography;

namespace Twittor.Identity.Services.Helpers
{
    public static class CryptoUtils
    {
        private const int SALT_LENGTH = 128 / 8; // 128 bits

        public static (string hashedPassword, string salt) HashPassword(string password)
        {
            var salt = CreateSalt();
            var hashedPassword = HashPassword(password, salt);

            return (hashedPassword, salt);
        }

        public static string HashPassword(string password, byte[] salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        private static string CreateSalt()
        {
            //Generate a cryptographic random number.
            //RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            //byte[] buff = new byte[SALT_LENGTH];
            //rng.GetBytes(buff);

            //return buff;

            BCrypt.Net.BCrypt.GenerateSalt();
        }
    }
}
