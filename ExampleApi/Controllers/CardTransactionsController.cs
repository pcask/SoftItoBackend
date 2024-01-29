using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardTransactionsController : ControllerBase
{
    private readonly ICardTransactionRepository _cardTransactionRepository;

    public CardTransactionsController(ICardTransactionRepository cardTransactionRepository)
    {
        _cardTransactionRepository = cardTransactionRepository;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_cardTransactionRepository.GetAll());
    }

    [HttpGet("GetAllWithCard")]
    public IActionResult GetAllWithCard()
    {
        return Ok(_cardTransactionRepository.GetAll(include: qCT => qCT.Include(ct => ct.Card)));
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_cardTransactionRepository.Get(ct => ct.Id == id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody] CardTransaction cardTransaction)
    {
        return Ok(_cardTransactionRepository.Add(cardTransaction));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] CardTransaction cardTransaction)
    {
        return Ok(_cardTransactionRepository.Update(cardTransaction));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult DeleteById(Guid id)
    {
        var cardTransaction = _cardTransactionRepository.Get(ct => ct.Id == id);
        if (cardTransaction == null)
            return BadRequest("Card transaction not found!");
        return Ok(_cardTransactionRepository.Delete(cardTransaction));
    }
}
