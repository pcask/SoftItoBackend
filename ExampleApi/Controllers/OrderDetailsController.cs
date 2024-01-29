using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
    private readonly IOrderDetailRepository _orderDetailRepository;

    public OrderDetailsController(IOrderDetailRepository orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_orderDetailRepository.GetAll());
    }

    [HttpGet("GetAllWithOrder")]
    public IActionResult GetAllWithOrder()
    {
        return Ok(_orderDetailRepository.GetAll(include: qOd => qOd.Include(od => od.Order)));
    }

    [HttpGet("GetAllWithProduct")]
    public IActionResult GetAllWithProduct()
    {
        return Ok(_orderDetailRepository.GetAll(include: qOd => qOd.Include(od => od.Product)));
    }

    [HttpGet("GetAllWithProductTransaction")]
    public IActionResult GetAllWithProductTransaction()
    {
        return Ok(_orderDetailRepository.GetAll(include: qOd => qOd.Include(od => od.ProductTransaction)));
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_orderDetailRepository.Get(od => od.Id == id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] OrderDetail orderDetail)
    {
        return Ok(_orderDetailRepository.Add(orderDetail));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] OrderDetail orderDetail)
    {
        return Ok(_orderDetailRepository.Update(orderDetail));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult DeleteById(Guid id)
    {
        var orderDetail = _orderDetailRepository.Get(od => od.Id == id);
        if (orderDetail == null)
            return BadRequest("OrderDetail not found!");
        return Ok(_orderDetailRepository.Delete(orderDetail));
    }
}
