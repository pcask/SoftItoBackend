using ExampleApi.Entities;

namespace ExampleApi.ViewModels.Orders
{
    public class CreateOrderVM
    {
        public Guid UserId { get; set; }
        public IList<ProductTransaction> ProductTransactions { get; set; }

        public CreateOrderVM()
        {
            ProductTransactions = new List<ProductTransaction>();
        }
    }
}
