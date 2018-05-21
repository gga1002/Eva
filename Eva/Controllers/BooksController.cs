using Eva.Application;
using Eva.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Eva.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookService _service;
        
        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody]Book book)
        {
            var books = _service.Get();

            if (book == null)
                return BadRequest();

            _service.Add(book);
            return Ok();
        }

        [Authorize][HttpPut, HttpPatch]
        public IHttpActionResult Update(Book book)
        {
            try
            {
                _service.Update(book);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize][HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            _service.Remove(1);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get(string query = null)
        {
            var result = _service.Get(query);

            if (result == null || result.Count() == 0)
                return NotFound();

            return Ok(result);
        }
    }
}
