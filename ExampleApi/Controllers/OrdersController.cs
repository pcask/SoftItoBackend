using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;
using ExampleApi.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IProductTransactionRepository _productTransactionRepository;

    public OrdersController(IOrderRepository orderRepository, IProductTransactionRepository productTransactionRepository, IOrderDetailRepository orderDetailRepository)
    {
        _orderRepository = orderRepository;
        _productTransactionRepository = productTransactionRepository;
        _orderDetailRepository = orderDetailRepository;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_orderRepository.GetAll());
    }

    [HttpGet("GetAllWithOrderDetails")]
    public IActionResult GetAllWithOrderDetails()
    {
        return Ok(_orderRepository.GetAll(include: qO => qO.Include(o => o.OrderDetails)));
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_orderRepository.Get(o => o.Id == id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] CreateOrderVM createOrderVM)
    {
        if (createOrderVM.ProductTransactions.Count < 0)
            return BadRequest("Product list cannot be empty!");

        if (createOrderVM.ProductTransactions.Any(pt => pt.Quantity <= 0))
            return BadRequest("The quantity of products cannot be less than 1!");

        var checkQuantity = createOrderVM.ProductTransactions.Select(ptVM => _productTransactionRepository.GetAll(pt => pt.Id == ptVM.Id).Sum(pt => pt.Quantity) - ptVM.Quantity).Any(q => q < 0);

        if (checkQuantity)
            return BadRequest("Sorry, there are not enough products in stock!");

        // Yeni "order" ekleniyor.
        var addedOrder = _orderRepository.Add(new()
        {
            UserId = createOrderVM.UserId,
            CreatedDate = DateTime.UtcNow
        });

        createOrderVM.ProductTransactions.ToList().ForEach(pt =>
        {
            pt.Quantity = pt.Quantity > 0 ? -pt.Quantity : pt.Quantity;

            var addedProductTransaction = _productTransactionRepository.Add(pt); // Yeni "productTransaction" ekleniyor.

            // Yeni "orderDetail" ekleniyor.
            _orderDetailRepository.Add(new()
            {
                OrderId = addedOrder.Id,
                ProductId = addedProductTransaction.ProductId,
                ProductTransactionId = addedProductTransaction.Id,
            });
        });

        return Ok(addedOrder);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Order order)
    {
        return Ok(_orderRepository.Update(order));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult DeleteById(Guid id)
    {
        var order = _orderRepository.Get(o => o.Id == id);
        if (order == null)
            return BadRequest("Order not found!");
        return Ok(_orderRepository.Delete(order));
    }
}
