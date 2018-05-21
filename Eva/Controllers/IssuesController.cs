using Eva.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eva.Controllers
{
    [Authorize]
    public class IssuesController : ApiController
    {
        private readonly IIssueService _service;

        public IssuesController(IIssueService service)
        {
            _service = service;
        }

        public IHttpActionResult CheckOut(int BookId)
        {
            return Ok();
        }

        public IHttpActionResult CheckIn(int BookId)
        {
            return Ok();
        }

        public void MockCurrentUser(object _userId, string v)
        {
            throw new NotImplementedException();
        }
    }
}
