using ExampleApi.Contexts;
using ExampleApi.Core;
using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;

namespace ExampleApi.Repositories.Concretes
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ExampleDbContext context) : base(context)
        {
        }
    }
}
