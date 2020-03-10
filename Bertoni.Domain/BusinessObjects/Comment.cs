using Bertoni.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Domain.BusinessObjects
{
    public class Comment
    {
        public Comment()
        {

        }

        public Comment(Comments from)
        {
            this.Id = from.Id;
            this.PostId = from.PostId;
            this.Name = from.Name;
            this.Email = from.Email;
            this.Body = from.Body;
        }

        public int Id { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
