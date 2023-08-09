using Data.Context;
using Data.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extensions
{
    public static class CustomIdentityExtension
    {
        public static void AddIdentityExtension(this IServiceCollection services)
        {
            services.AddIdentity<UserApp, RoleApp>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

            }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}