using System;
using Twittor.Identity.DataAccess;
using Twittor.Identity.Services;

namespace Twittor.Identity.Infrastructure
{
    public static class Bootstrapper
    {
        public static void Bootstrap(IServicesCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase("TestDb"));

            //configureDI
            BootstrapDependencies(services);
        }

        private void BootstrapDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
