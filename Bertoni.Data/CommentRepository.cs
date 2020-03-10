using Bertoni.Data.Abstraction;
using Bertoni.Data.Entitites;
using Bertoni.Data.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Data
{
    public class CommentRepository : IRepository<Comments>
    {
        private const string _url = @"https://jsonplaceholder.typicode.com/comments";

        public Comments Get(int id)
        {
            Comments _return = null;

            try
            {
                var _json = RestHelper.GetJsonRequest(_url, $"id={id}");

                if(!String.IsNullOrEmpty(_json))
                    _return = JsonConvert.DeserializeObject<Comments>(_json);
            }
            catch (Exception x)
            {
                throw;
            }

            return _return;
        }

        public IList<Comments> GetAll()
        {
            List<Comments> _return = null;

            try
            {
                var _json = RestHelper.GetJsonRequest(_url);

                if (!String.IsNullOrEmpty(_json))
                    _return = JsonConvert.DeserializeObject<List<Comments>>(_json);
            }
            catch (Exception x)
            {
                throw;
            }

            return _return;
        }
    }
}
