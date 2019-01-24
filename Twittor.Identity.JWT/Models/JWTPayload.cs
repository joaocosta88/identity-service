
namespace Twittor.Identity.JWT.Models
{
    public class JWTPayload
    {
        public string Email { get; internal set; }
       
        protected JWTPayload() { }

        public static JWTPayload Build(string email)
        {
            return new JWTPayload()
            {
                Email = email
            };
        }
    }
}
