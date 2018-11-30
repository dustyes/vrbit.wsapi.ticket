using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace vrbit.wsapi.ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/values/5/5
        [HttpGet("{firstnumber}/{secondnumber}")]
        public ActionResult<string> Sum(string firstnumber, string secondnumber)
        {
            if(IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                var sum = ConvertToDecimal(firstnumber) + ConvertToDecimal(secondnumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");

        }

        private decimal ConvertToDecimal(string number)
        {
            decimal value;
            
            if(decimal.TryParse(number, out value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        private bool IsNumeric(string number)
        {
            double num;

            bool isNumber = double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out num);

            return isNumber;
        }
    }
}
