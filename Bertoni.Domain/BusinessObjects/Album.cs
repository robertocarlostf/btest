using Bertoni.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Domain.BusinessObjects
{
    public class Album
    {
        public Album()
        {
        }

        public Album(Albums from)
        {
            this.Id = from.Id;
            this.UserId = from.UserId;
            this.Title = from.Title;
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
    }
}
