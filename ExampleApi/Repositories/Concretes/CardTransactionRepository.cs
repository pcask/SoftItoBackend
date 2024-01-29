using ExampleApi.Contexts;
using ExampleApi.Core;
using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;

namespace ExampleApi.Repositories.Concretes
{
    public class CardTransactionRepository : BaseRepository<CardTransaction>, ICardTransactionRepository
    {
        public CardTransactionRepository(ExampleDbContext context) : base(context)
        {
        }
    }
}
