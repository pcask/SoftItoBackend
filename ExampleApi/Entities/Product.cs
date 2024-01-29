using ExampleApi.Core;
using System.ComponentModel.DataAnnotations;

namespace ExampleApi.Entities
{
    public class Product : Entity<Guid>
    {
        [MaxLength(100)]
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ProductTransaction> ProductTransactions { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }



        public Product()
        {
            ProductTransactions = new HashSet<ProductTransaction>();
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
