using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Schema.Mapper;

namespace WebAPI.Extensions
{
    public static class CustomMapperExtension
    {
        public static void AddMapperExtension(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            services.AddSingleton(config.CreateMapper());
        }
    }
}