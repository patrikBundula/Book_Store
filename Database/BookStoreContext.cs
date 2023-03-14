using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Database.Entity;
using Database.Entity.System;
using DataBase;

namespace Database
{

    public class BookStoreContext : IdentityDbContext<User>
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<FileStore> FileStore { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }
    }


}
