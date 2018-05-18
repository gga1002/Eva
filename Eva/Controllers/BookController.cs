using Eva.Application;
using Eva.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Eva.Controllers
{
    public class BookController : ApiController
    {
        private readonly IBookService _service;
        
        public BookController(IBookService service)
        {
            _service = service;
        }

        public IHttpActionResult Add(Book book)
        {
            var books = _service.GetAll();

            if (book == null)
                return BadRequest();

            if (books.Any(b => b.Name == book.Name))
                return BadRequest();

            _service.Add(book);
            return Ok();
        }

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

        public IHttpActionResult Remove(int id)
        {
            _service.Remove(1);
            return Ok();
        }
    }
}
