using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;
using ExampleApi.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private IProductRepository _productRepository;
    private ICategoryRepository _categoryRepository;

    public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_productRepository.GetAll());
    }

    [HttpGet("GetAllWithCategory")]
    public IActionResult GetAllWithCategory()
    {
        return Ok(_productRepository.GetAll(include: qP => qP.Include(p => p.Category)));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] CreateProductVM createProductVM)
    {
        var category = _categoryRepository.Get(cat => cat.Id == createProductVM.CategoryId);
        if (category == null)
            return BadRequest("Category not found!");

        Product product = new()
        {
            Name = createProductVM.Name,
            CategoryId = createProductVM.CategoryId,
            Description = createProductVM.Description,
            Price = createProductVM.Price,
        };
        return Ok(_productRepository.Add(product));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] UpdateProductVM updateProductVM)
    {
        var product = _productRepository.Get(p => p.Id == updateProductVM.Id);

        if (product == null)
            return BadRequest("Product not found!");


        product.Name = updateProductVM.Name != default ? updateProductVM.Name : product.Name;
        product.Price = updateProductVM.Price != default ? updateProductVM.Price : product.Price;
        product.CategoryId = updateProductVM.CategoryId != default ? updateProductVM.CategoryId : product.CategoryId;
        product.Description = updateProductVM.Description != default ? updateProductVM.Description : product.Description;

        return Ok(_productRepository.Update(product));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult Update(Guid id)
    {
        var product = _productRepository.Get(p => p.Id == id);
        if (product == null)
            return BadRequest("Product not found!");

        return Ok(_productRepository.Delete(product));
    }
}
