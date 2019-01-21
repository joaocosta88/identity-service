using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Twittor.Identity.DataAccess;
using Twittor.Identity.Services;

namespace Twittor.Identity.Infrastructure
{
    public static class Bootstrapper
    {
        public static void Bootstrap(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Twittor-Dev")));

            //configureDI
            services.AddScoped<IUserService, UserService>();
        }
    }
}
