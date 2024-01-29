using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExampleApi.ViewModels.Categories;

namespace ExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_categoryRepository.GetAll());
    }

    [HttpGet("GetAllWithProducts")]
    public IActionResult GetAllWithProducts()
    {
        return Ok(_categoryRepository.GetAll(include: qCategory => qCategory.Include(c => c.Products)));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] CreateCategoryVM createCategoryVM)
    {
        Category category = new() { Name = createCategoryVM.Name };

        return Ok(_categoryRepository.Add(category));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] UpdateCategoryVM updateCategoryVM)
    {
        var category = _categoryRepository.Get(c => c.Id == updateCategoryVM.Id);
        if (category == null)
            return BadRequest();

        category.Name = updateCategoryVM.Name != default ? updateCategoryVM.Name : category.Name;

        return Ok(_categoryRepository.Update(category));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult Delete(Guid id)
    {
        var category = _categoryRepository.Get(c => c.Id == id);
        if (category == null)
            return BadRequest("Category not found!");

        return Ok(_categoryRepository.Delete(category));
    }
}
