using ExampleApi.Core;

namespace ExampleApi.Entities
{
    public class CardTransaction : Entity<Guid>
    {
        public Guid CardId { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Card Card { get; set; }
    }
}
