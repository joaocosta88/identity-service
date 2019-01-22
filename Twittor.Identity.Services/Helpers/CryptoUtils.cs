using System;
using System.Security.Cryptography;

namespace Twittor.Identity.Services.Helpers
{
    public static class CryptoUtils
    {
        private const int SALT_BYTE_SIZE = 24;
        private const int HASH_BYTE_SIZE = 20; // to match the size of the PBKDF2-HMAC-SHA-1 hash 
        private const int ITERATIONS_COUNT = 10000;

        public static (string hashedPassword, byte[] salt) HashPassword(string password)
        {
            var salt = CreateSalt();
            var hashedPassword = HashPassword(password, salt);

            return (hashedPassword, salt);
        }

        public static string HashPassword(string password, byte[] salt)
        {
            using (var pdkdf2 = new Rfc2898DeriveBytes(password, salt, ITERATIONS_COUNT))
            {
                var hashedPwd = pdkdf2.GetBytes(HASH_BYTE_SIZE);
                return Convert.ToBase64String(hashedPwd);
            }
        }

        private static byte[] CreateSalt()
        {
            //Generate a cryptographic random number.
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] buff = new byte[SALT_BYTE_SIZE];
                rng.GetBytes(buff);
                return buff;
            }
        }
    }
}
