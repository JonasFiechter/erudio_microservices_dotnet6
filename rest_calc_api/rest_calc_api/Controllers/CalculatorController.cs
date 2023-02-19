using Microsoft.AspNetCore.Mvc;

namespace rest_calc_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }    

            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string number)
        {
            return false;
        }

        private decimal ConvertToDecimal(string number) 
        {
            throw new NotImplementedException();    
        }
    }
}