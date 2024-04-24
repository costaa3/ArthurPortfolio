using Microsoft.AspNetCore.Mvc;
using SimpleCalculatorApp;

namespace MySimpleCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {


        [HttpGet("Add/{left}/{right}")]
        public int Get(int left,int right)
        {
            Calculator calculator = new Calculator();
            return calculator.Sum(left, right);
        } 
    }
}