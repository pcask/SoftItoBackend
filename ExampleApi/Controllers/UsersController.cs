using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NufusMudurlugu;
using static NufusMudurlugu.KPSPublicSoapClient;

namespace ExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private IUserRepository _userRepository;
    private ICardTransactionRepository _cardTransactionRepository;

    public UsersController(IUserRepository userRepository, ICardTransactionRepository cardTransactionRepository)
    {
        _userRepository = userRepository;
        _cardTransactionRepository = cardTransactionRepository;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_userRepository.GetAll());
    }

    [HttpGet("GetAllWithOrders")]
    public IActionResult GetAllWithOrders()
    {
        return Ok(_userRepository.GetAll(include: qU => qU.Include(u => u.Orders).ThenInclude(o => o.OrderDetails)));
    }

    [HttpGet("GetAllWithAllDetails")]
    public IActionResult GetAllWithAllDetails()
    {
        return Ok(_userRepository.GetAll(include: qU => qU
        .Include(u => u.Orders).ThenInclude(o => o.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.Category)
        .Include(u => u.Orders).ThenInclude(o => o.OrderDetails).ThenInclude(od => od.ProductTransaction)));
    }

    [HttpGet("GetById/{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(_userRepository.Get(user => user.Id == id));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] User model)
    {
        using KPSPublicSoapClient soapClient = new(EndpointConfiguration.KPSPublicSoap12);

        var result = await soapClient.TCKimlikNoDogrulaAsync(long.Parse(model.IdentificationNumber), model.FirstName, model.LastName, model.BirthYear);
        if (!result.Body.TCKimlikNoDogrulaResult)
            return BadRequest("User information is incorrect!");

        return Ok(_userRepository.Add(model));
    }

    [HttpPost("Update")]
    public IActionResult Update([FromBody] User model)
    {
        return Ok(_userRepository.Update(model));
    }

    [HttpPost("DeleteById/{id}")]
    public IActionResult Update(Guid id)
    {
        var user = _userRepository.Get(user => user.Id == id);
        if (user == null)
            return BadRequest("User not found!");

        return Ok(_userRepository.Delete(user));
    }

    [HttpPost("AddBalance")]
    public IActionResult AddBalance([FromBody] CardTransaction cardTransaction)
    {
        return Ok(_cardTransactionRepository.Add(cardTransaction));
    }
}
