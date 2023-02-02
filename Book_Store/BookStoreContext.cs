using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_Store
{

    public class BookStoreContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql(connectionString: "server=localhost;database=book_store;user=root;password=qpu0DF00", ServerVersion.AutoDetect("server=localhost;database=book_store;user=root;password=qpu0DF00"));

        //}



    }


}
