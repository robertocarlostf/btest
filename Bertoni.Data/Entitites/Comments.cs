using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Data.Entitites
{
    public class Comments
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
