using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;


namespace Book_Store
{

    public class BookStoreContext : IdentityDbContext<User>
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            new DbInitializer(builder).Seed();
        }


    }


}
