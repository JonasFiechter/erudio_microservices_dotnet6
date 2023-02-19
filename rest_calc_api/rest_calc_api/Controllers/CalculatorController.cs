using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

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

        [HttpGet("{operation}/{firstNumber}/{secondNumber}")]
        
        public IActionResult Get(string operation, string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                var firstConvertedNumber = ConvertToDecimal(firstNumber);
                var secondConvertedNumber = ConvertToDecimal(secondNumber);

                string result = CheckOperation(operation, firstConvertedNumber, secondConvertedNumber);

                return Ok(result);

            }    

            return BadRequest("Invalid Input");
        }


        public string CheckOperation(string operation, decimal firstNumber, decimal secondNumber)
        {
            if (operation == "sum")
            {
                decimal sumResult = firstNumber + secondNumber;
                return sumResult.ToString();
            }

            if (operation == "multiply") 
            {
                decimal multiplyResult = firstNumber * secondNumber;
                return multiplyResult.ToString();
            }

            if (operation == "divide")
            {
                decimal divideResult = firstNumber / secondNumber;
                return divideResult.ToString();
            }

            else
            {
                string checkResult = "Invalid Operation";
                return checkResult;
            }
        }

        private bool IsNumeric(string number)
        {
            if (double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double result)) 
            {
                return true;
            };
            return false;
        }

        private decimal ConvertToDecimal(string number) 
        {

            decimal decimalValue;
            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            
            return 0;    
        }
    }
}