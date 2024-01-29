using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductTransactionsController : ControllerBase
{
    private readonly IProductTransactionRepository _productTransactionRepository;

    public ProductTransactionsController(IProductTransactionRepository productTransactionRepository)
    {
        _productTransactionRepository = productTransactionRepository;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_productTransactionRepository.GetAll());
    }

    [HttpGet("GetAllWithProduct")]
    public IActionResult GetAllWithProduct()
    {
        return Ok(_productTransactionRepository.GetAll(include: qPT => qPT.Include(pt => pt.Product)));
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_productTransactionRepository.Get(pt => pt.Id == id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] ProductTransaction productTransaction)
    {
        return Ok(_productTransactionRepository.Add(productTransaction));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] ProductTransaction productTransaction)
    {
        return Ok(_productTransactionRepository.Update(productTransaction));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult DeleteById(Guid id)
    {
        var pt = _productTransactionRepository.Get(pt => pt.Id == id);
        if (pt == null)
            return BadRequest("Product transaction not found!");
        return Ok(_productTransactionRepository.Delete(pt));
    }
}
