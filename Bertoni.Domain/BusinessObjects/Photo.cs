using Bertoni.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Domain.BusinessObjects
{
    public class Photo
    {
        public Photo()
        {
        }

        public Photo(Photos from)
        {
            this.Id = from.Id;
            this.AlbumId = from.AlbumId;
            this.Title = from.Title;
            this.Url = from.Url;
            this.Thumbnail = from.Thumbnail;
        }

        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Thumbnail { get; set; }
    }
}
