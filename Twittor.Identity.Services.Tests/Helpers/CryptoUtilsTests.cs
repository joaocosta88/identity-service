
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Twittor.Identity.Services.Helpers;

namespace Twittor.Identity.Services.Tests.Helpers
{
    [TestClass]
    public class CryptoUtilsTests
    {
        private const string plaintext = "this is a plaintext string";
        [TestMethod]
        public void HashPassword_GenerateSalt_ShouldGenerateSaltAndCypherText()
        {
            var output = CryptoUtils.HashPassword(plaintext);
            Assert.IsNotNull(output);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(output.hashedPassword));
            Assert.AreNotEqual(output.hashedPassword, plaintext);

            Assert.IsTrue(output.salt != null);
            Assert.IsTrue(output.salt.Length > 0);
            //convert salt from byte to string
            var salt = Convert.ToBase64String(output.salt);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(salt));
        }

        [TestMethod]
        public void HashPassword_ProvideSalt_ShouldHaveSameOutput()
        {
            var output = CryptoUtils.HashPassword(plaintext);
            var hashedPwd = output.hashedPassword;

            var secondPwdHash = CryptoUtils.HashPassword(plaintext, output.salt);
            Assert.AreEqual(hashedPwd, secondPwdHash);
        }
    }
}
