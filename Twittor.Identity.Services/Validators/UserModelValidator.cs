using System;
using System.Net.Mail;

namespace Twittor.Identity.Services.Validators
{
    public static class UserModelValidator
    {
        public static bool IsUserEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {                
                new MailAddress(email);
            }
            catch(FormatException)
            {
                return false;
            }

            return true;
        }

        public static bool IsUserPasswordValid(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if(password.Length < 6)
            {
                return false;
            }

            return true;
        }
    }
}
