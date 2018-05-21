using Eva.Application;
using Eva.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eva.Controllers
{
    public class GenresController : ApiController
    {
        private IGenreService _service;

        public GenresController(IGenreService service)
        {
            _service = service;
        }
        public IEnumerable<Genre> Get(string query = null)
        {
            return _service.Get(query);
        }
    }
}
