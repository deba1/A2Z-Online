using Application.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        // Adding services dependency injection of DbContext and migrating database.
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.BuildServiceProvider().GetService<AppDbContext>().Database.Migrate(); // Do migration automatically.

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

            return services;
        }
    }
}
