using API.Managers;
using Application.DTOs.ResponseDTOs;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPI(this IServiceCollection services)
        {
            // Adding manager services
            services.AddTransient(typeof(IBaseManager<>), typeof(BaseManager<>));
            services.AddTransient<IBrandManager, BrandManager>();
            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<IFeedbackManager, FeedbackManager>();
            services.AddTransient<IInventoryManager, InventoryManager>();
            services.AddTransient<IOrderManager, OrderManager>();
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IPaymentManager, PaymentManager>();
            services.AddTransient<IGlobalConfigurationManager, GlobalConfigurationManager>();
            services.AddTransient<IUserCredentialManager, UserCredentialManager>();
            services.AddTransient<IAuthenticationManager, AuthenticationManager>();
            services.AddTransient<IApiResponseDTO, ApiResponseDTO>();

            services.AddAutoMapper(typeof(Startup));

            return services;
        }
    }
}
