using ExampleApi.Core;

namespace ExampleApi.Entities
{
    public class Card : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid CardTypeId { get; set; }
        public long CardUID { get; set; }
        public decimal Limit { get; set; } // Düşebileceği eksi bakiye sınırı

        public virtual User User { get; set; }
        public virtual CardType CardType { get; set; }
        public virtual ICollection<CardTransaction> CardTransactions { get; set; }

        public Card()
        {
            CardTransactions = new HashSet<CardTransaction>();
        }

    }
}
