using Data.Repository;
using Data.Repository.Base;
using Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extensions
{
    public static class CustomRepositoryExtension
    {
        public static void AddRepositoryExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepositoryBase<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IDigitalWalletRepository, DigitalWalletRepository>();
        }
    }
}