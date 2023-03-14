using Database.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public static class DbInitializer
    {


        public static void Seed(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var newUser = new User()
            {
                FirstName = "admin",
                LastName = "admin",
                Money = 0,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "password"),
                SecurityStamp = string.Empty
            };

            var adminRole = new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" };
            var customerRole = new IdentityRole { Name = "Customer", NormalizedName = "CUSTOMER" };



            // Seed the aspNetUsers table
            modelBuilder.Entity<User>().HasData(newUser);

            // Seed the aspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(adminRole, customerRole);

            // Assign the admin role to the admin user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRole.Id,
                    UserId = newUser.Id,
                }
            );
        }


    }
}
