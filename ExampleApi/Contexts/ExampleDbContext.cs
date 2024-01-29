using ExampleApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Contexts
{
    public class ExampleDbContext : DbContext
    {
        protected IConfiguration Configuration;

        public ExampleDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conString = Configuration.GetValue<string>("ConnectionStrings:Development");
            optionsBuilder.UseSqlServer(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Introducing FOREIGN KEY constraint 'FK_OrderDetails_Products_ProductId' on table 'OrderDetails' may cause cycles or multiple cascade paths.
            // Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderDetails)
                .WithOne(od => od.Product)
                .OnDelete(DeleteBehavior.NoAction);


        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTransaction> ProductTransactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<CardTransaction> CardTransactions { get; set; }

    }
}
