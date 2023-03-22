using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPIController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductAPIController : ControllerBase
    {
        private readonly ILogger<ProductAPIController> _logger;

        public ProductAPIController(ILogger<ProductAPIController> logger)
        {
            _logger = logger;
        }

        [HttpGet("api/{param}")]
        public IActionResult Get(string param)
        {
            return Ok("Working");
        }
    }
}