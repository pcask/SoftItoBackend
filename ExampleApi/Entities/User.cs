using ExampleApi.Core;
using System.ComponentModel.DataAnnotations;

namespace ExampleApi.Entities
{
    public class User : Entity<Guid>
    {
        [MaxLength(20)]
        public required string IdentificationNumber { get; set; }
        [MaxLength(150)] // Arabistandan dolayı :)
        public required string FirstName { get; set; }
        [MaxLength(150)]
        public required string LastName { get; set; }
        public short BirthYear { get; set; }
        [MaxLength(10)]
        public string? CarPlate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Card> Cards { get; set; }

        public User()
        {
            Orders = new HashSet<Order>();
            Cards = new HashSet<Card>();
        }
    }
}
