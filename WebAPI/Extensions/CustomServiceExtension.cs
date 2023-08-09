using Core.SharedLibrary.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Operation;
using Operation.Basket;
using Operation.Redis;
using Operation.Token;

namespace WebAPI.Extensions
{
    public static class CustomServiceExtension
    {
        public static void AddServiceExtension(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IKupunService, KupunService>();
            services.AddScoped<IDigitalWalletService, DigitalWalletService>();

            services.AddSingleton<RedisService>(sp =>
            {
                var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
                var redis = new RedisService(redisSettings.Host, redisSettings.Port);

                redis.Connect();

                return redis;
            });
        }
    }
}