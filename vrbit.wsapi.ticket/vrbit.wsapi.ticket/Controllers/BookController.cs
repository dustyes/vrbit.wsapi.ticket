using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vrbit.wsapi.ticket.Business;
using vrbit.wsapi.ticket.Data.VO;
using vrbit.wsapi.ticket.Model;

namespace vrbit.wsapi.ticket.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class BookController : Controller
    {
        private IBookBusiness _bookBusiness;

        public BookController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var book = _bookBusiness.FindById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_bookBusiness.FindById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();

            return new ObjectResult(_bookBusiness.Create(book));
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] BookVO book)
        {
            var bookUpdate = new ObjectResult(_bookBusiness.Update(book));

            if (bookUpdate == null)
                return BadRequest();

            return bookUpdate;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _bookBusiness.Delete(id);

            return NoContent();
        }
    }
}