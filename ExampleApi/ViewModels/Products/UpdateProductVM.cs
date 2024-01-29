using System.ComponentModel.DataAnnotations;

namespace ExampleApi.ViewModels.Products
{
    public class UpdateProductVM
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
