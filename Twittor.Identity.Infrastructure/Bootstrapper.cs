using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Twittor.Identity.DataAccess;
using Twittor.Identity.Services;

namespace Twittor.Identity.Infrastructure
{
    public static class Bootstrapper
    {
        public static void Bootstrap(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase("TestDb"));

            //configureDI
            BootstrapDependencies(services);
        }

        private static void  BootstrapDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
