using Infrastructure.Persistence;
using Infrastructure.Repository;
using Infrastructure.Transaction;
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

            // Adding repository services.
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserReposity>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IGlobalConfigurationRepository, GlobalConfigurationRepository>();
            services.AddTransient<IUserCredentialRepository, UserCredentialRepository>();
            services.AddTransient<IDatabaseTransaction, DatabaseTransaction>();

            return services;
        }
    }
}
