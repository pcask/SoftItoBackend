using ExampleApi.Contexts;
using ExampleApi.Core;
using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;

namespace ExampleApi.Repositories.Concretes
{
    public class ProductTransactionRepository : BaseRepository<ProductTransaction>, IProductTransactionRepository
    {
        public ProductTransactionRepository(ExampleDbContext context) : base(context)
        {
        }
    }
}
