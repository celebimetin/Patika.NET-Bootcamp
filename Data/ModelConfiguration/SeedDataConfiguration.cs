using Data.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelConfiguration
{
    public static class SeedDataConfiguration
    {
        public static void Seed(this ModelBuilder builder)
        {
            var password = "admin";
            var passwordHasher = new PasswordHasher<UserApp>();

            //Seed Role
            var adminRole = new RoleApp
            {
                Name = "admin",
            };
            adminRole.NormalizedName = adminRole.Name.ToUpper();
            builder.Entity<RoleApp>().HasData(adminRole);

            //Seed User
            var adminUser = new UserApp
            {
                UserName = "admin",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                FirstName = "admin",
                LastName = "admin",

            };
            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, password);

            builder.Entity<UserApp>().HasData(adminUser);

            //Seed UserRoles
            var userRoles = new IdentityUserRole<string>();
            userRoles.UserId = adminUser.Id;
            userRoles.RoleId = adminRole.Id;

            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}