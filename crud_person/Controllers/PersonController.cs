using Microsoft.AspNetCore.Mvc;
using crud_person.Services;

namespace crud_person.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;

    private IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet("{find}/{_id}")]
    public IActionResult Get(long _id)
    {
        return Ok(_personService.FindByID(_id));
    }
}
