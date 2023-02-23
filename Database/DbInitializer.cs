using Database.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;



        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
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
            _modelBuilder.Entity<User>().HasData(newUser);

            // Seed the aspNetRoles table
            _modelBuilder.Entity<IdentityRole>().HasData(adminRole, customerRole);

            // Assign the admin role to the admin user
            _modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRole.Id,
                    UserId = newUser.Id,
                }
            );
        }


    }
}
