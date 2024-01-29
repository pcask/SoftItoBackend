using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardTypesController : ControllerBase
{
    private readonly ICardTypeRepository _cardTypeRepository;

    public CardTypesController(ICardTypeRepository cardTypeRepository)
    {
        _cardTypeRepository = cardTypeRepository;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_cardTypeRepository.GetAll());
    }

    [HttpGet("GetAllWithCards")]
    public IActionResult GetAllWithCards()
    {
        return Ok(_cardTypeRepository.GetAll(include: qCT => qCT.Include(ct => ct.Cards)));
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_cardTypeRepository.Get(ct => ct.Id == id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] CardType cardType)
    {
        return Ok(_cardTypeRepository.Add(cardType));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] CardType cardType)
    {
        return Ok(_cardTypeRepository.Update(cardType));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult DeleteById(Guid id)
    {
        var cardType = _cardTypeRepository.Get(ct => ct.Id == id);
        if (cardType == null)
            return BadRequest("Card type not found!");
        return Ok(_cardTypeRepository.Delete(cardType));
    }
}
