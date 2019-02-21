using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Identity.DataAccess;
using Identity.JWT;
using Identity.Repository;
using Identity.Repository.Interfaces;
using Identity.Services;

namespace Identity.Infrastructure
{
    public static class Bootstrapper
    {
        public static void Bootstrap(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Twittor-Dev")));

            //configureDI
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            //jwt
            services.AddSingleton<JWTGenerator>(service =>
            {
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

                string key = configuration.GetValue<string>("JWTHMACSHA256Key");

                return new JWTGenerator(encoder, key);
            });   
        }
    }
}
