using Bertoni.Domain.Abstraction;
using Bertoni.Domain.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BertoniTest.Web.Controllers
{
    public class DataController : ApiController
    {
        private IService<Comment> svcComment;

        public DataController(IService<Comment> serviceComment)
        {
            svcComment = serviceComment;
        }
        
        [HttpGet]
        public IHttpActionResult Comments(int id)
        {
            var _comments = svcComment.QueryBy(c => c.PostId == id);

            if (_comments != null)
                return Ok(_comments);

            return NotFound();
        }
    }
}