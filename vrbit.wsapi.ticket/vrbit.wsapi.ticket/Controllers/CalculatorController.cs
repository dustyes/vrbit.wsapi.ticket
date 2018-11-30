using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vrbit.wsapi.ticket.Comum;

namespace vrbit.wsapi.ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        Util util = new Util();

        // GET api/values/5/5
        [HttpGet("sum/{firstnumber}/{secondnumber}")]
        public ActionResult<string> Sum(string firstnumber, string secondnumber)
        {
            if(util.IsNumeric(firstnumber) && util.IsNumeric(secondnumber))
            {
                var sum = util.ConvertToDecimal(firstnumber) + util.ConvertToDecimal(secondnumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");

        }

        [HttpGet("sub/{firstnumber}/{secondnumber}")]
        public ActionResult<string> Sub(string firstnumber, string secondnumber)
        {
            if (util.IsNumeric(firstnumber) && util.IsNumeric(secondnumber))
            {
                var sum = util.ConvertToDecimal(firstnumber) - util.ConvertToDecimal(secondnumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");

        }

        [HttpGet("div/{firstnumber}/{secondnumber}")]
        public ActionResult<string> Div(string firstnumber, string secondnumber)
        {
            if (util.IsNumeric(firstnumber) && util.IsNumeric(secondnumber))
            {
                var sum = util.ConvertToDecimal(firstnumber) / util.ConvertToDecimal(secondnumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");

        }

        [HttpGet("mult/{firstnumber}/{secondnumber}")]
        public ActionResult<string>  Mult(string firstnumber, string secondnumber)
        {
            if (util.IsNumeric(firstnumber) && util.IsNumeric(secondnumber))
            {
                var sum = util.ConvertToDecimal(firstnumber) / util.ConvertToDecimal(secondnumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");

        }

        [HttpGet("mean/{firstnumber}/{secondnumber}")]
        public ActionResult<string> Mean(string firstnumber, string secondnumber)
        {
            if (util.IsNumeric(firstnumber) && util.IsNumeric(secondnumber))
            {
                var sum = util.ConvertToDecimal(firstnumber) + util.ConvertToDecimal(secondnumber) / 2;
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");

        }

        [HttpGet("square/{firstnumber}/{secondnumber}")]
        public ActionResult<string> Square(string number)
        {
            if (util.IsNumeric(number))
            {
                var square = Math.Sqrt((double)util.ConvertToDecimal(number));
                return Ok(square.ToString());
            }

            return BadRequest("Invalid input");

        }

    }
}
