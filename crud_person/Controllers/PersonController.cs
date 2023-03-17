using Microsoft.AspNetCore.Mvc;
using crud_person.Services;
using crud_person.Model;

namespace crud_person.Controllers;

[ApiController]
[Route("api")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;

    private IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpPost("create")]
    public IActionResult Post([FromBody] Person person)
    {
        return Ok(_personService.Create(person));
    }

    [HttpGet("find/list")]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
    }

    [HttpGet("calc/{first}/{second}")]
    public IActionResult Get(float first, float second)
    {
        float result = first / second;
        var rest = first % second;
        return Ok($"{result} - {rest}");
    }
}
