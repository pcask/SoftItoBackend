using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardsController : ControllerBase
{
    private readonly ICardRepository _cardRepository;

    public CardsController(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_cardRepository.GetAll());
    }

    [HttpGet("GetAllWithUser")]
    public IActionResult GetAllWithUser()
    {
        return Ok(_cardRepository.GetAll(include: qC => qC.Include(c => c.User)));
    }
    [HttpGet("GetAllWithCardType")]
    public IActionResult GetAllWithCardType()
    {
        return Ok(_cardRepository.GetAll(include: qC => qC.Include(c => c.CardType)));
    }

    [HttpGet("GetAllWithCardTransactions")]
    public IActionResult GetAllWithCardTransactions()
    {
        return Ok(_cardRepository.GetAll(include: qC => qC.Include(c => c.CardTransactions)));
    }


    [HttpGet("GetById/{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_cardRepository.Get(c => c.Id == id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] Card card)
    {
        return Ok(_cardRepository.Add(card));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Card card)
    {
        return Ok(_cardRepository.Update(card));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult DeleteById(Guid id)
    {
        var card = _cardRepository.Get(c => c.Id == id);
        if (card == null)
            return BadRequest("Card not found!");
        return Ok(_cardRepository.Delete(card));
    }
}
