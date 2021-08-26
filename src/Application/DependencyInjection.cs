using Application.Services;
using Application.Services.DbServices;
using Application.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Managers;
using Application.DTOs.ResponseDTOs;
using Application.Services.EncryptionServices;
using Application.Interfaces.EncyptionInterfaces;
using Application.Services.JwtServices;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            #region Jwt Service

            var jwtSection = config.GetSection("JWT");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSection.GetSection("Issuer").Value,
                    ValidAudience = jwtSection.GetSection("Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.GetSection("Key").Value))
                };
            });

            #endregion

            #region Application Service

            // Adding application services.
            services.AddTransient<IAuthenticationService, JwtService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IEncryptionService, BCryptEncryptionService>();
            services.AddTransient<IJwtConfigurationServiceModel, JwtConfigurationServiceModel>();

            services.AddAutoMapper(typeof(DependencyInjection));

            #endregion

            #region Repository Service

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
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient(typeof(IBaseSecondLevelRepository<,>), typeof(BaseSecondLevelRepository<,>));

            #endregion

            #region Manager Service

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

            #endregion

            return services;
        }
    }
}
