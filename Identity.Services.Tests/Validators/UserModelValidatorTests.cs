using Microsoft.VisualStudio.TestTools.UnitTesting;
using Identity.Services.Validators;

namespace Identity.Services.Tests.Validators
{
    [TestClass]
    public class UserModelValidatorTests
    {
        [TestMethod]
        public void IsUserEmailValid_NullEmail_NotValid()
        {
            string email = null;
            var isValid = UserModelValidator.IsUserEmailValid(email);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsUserEmailValid_EmptySpaceEmail_NotValid()
        {
            var email = "";
            var isValid = UserModelValidator.IsUserEmailValid(email);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsUserEmailValid_WhiteSpaceEmail_NotValid()
        {
            var email = "    ";
            var isValid = UserModelValidator.IsUserEmailValid(email);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsUserEmailValid_InvalidEmailFormat_NotValid()
        {
            var email = "test@";
            var isValid = UserModelValidator.IsUserEmailValid(email);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsUserEmailValid_ValidEmailFormat_IsValid()
        {
            var email = "test@test.com";
            var isValid = UserModelValidator.IsUserEmailValid(email);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsUserPasswordValid_NullPassword_NotValid()
        {
            string password = null;
            var isValid = UserModelValidator.IsUserPasswordValid(password);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsUserPasswordValid_EmptySpacePassword_NotValid()
        {
            var password = "";
            var isValid = UserModelValidator.IsUserPasswordValid(password);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsUserPasswordValid_WhiteSpacePassword_NotValid()
        {
            var password = "    ";
            var isValid = UserModelValidator.IsUserPasswordValid(password);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsUserPasswordValid_InvalidUserPasswordLength_NotValid()
        {
            var password = "12345";
            var isValid = UserModelValidator.IsUserPasswordValid(password);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsUserPasswordValid_ValidPasswordFormat_IsValid()
        {
            var password = "abc123";
            var isValid = UserModelValidator.IsUserPasswordValid(password);
            Assert.IsTrue(isValid);
        }
    }
}
