using ExampleApi.Core;
using System.ComponentModel.DataAnnotations;

namespace ExampleApi.Entities
{
    public class Category : Entity<Guid>
    {
        [MaxLength(80)]
        public required string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
}
