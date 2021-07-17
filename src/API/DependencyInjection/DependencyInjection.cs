using API.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace API.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPI(this IServiceCollection services)
        {
            // Adding manager services
            services.AddTransient(typeof(IBaseManager<>), typeof(BaseManager<>));
            services.AddTransient<IBrandManager, BrandManager>();

            services.AddAutoMapper(typeof(Startup));

            return services;
        }
    }
}
