using ExampleApi.Contexts;
using ExampleApi.Core;
using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;

namespace ExampleApi.Repositories.Concretes
{
    public class CardTypeRepository : BaseRepository<CardType>, ICardTypeRepository
    {
        public CardTypeRepository(ExampleDbContext context) : base(context)
        {
        }
    }
}
