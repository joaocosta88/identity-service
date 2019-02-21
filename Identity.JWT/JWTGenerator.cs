using JWT;
using Identity.JWT.Models;

namespace Identity.JWT
{
    public class JWTGenerator
    {
        private readonly IJwtEncoder JWTEncoder;
        private readonly string Key;

        public JWTGenerator(IJwtEncoder jwtEncoder, string key)
        {
            JWTEncoder = jwtEncoder;
            Key = key;
        }

        public string GenerateToken(string userEmail)
        {
            var payload = JWTPayload.Build(userEmail);
            return JWTEncoder.Encode(payload, Key);
        }
    }
}
