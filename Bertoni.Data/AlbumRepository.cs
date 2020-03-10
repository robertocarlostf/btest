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
    public class AlbumRepository : IRepository<Albums>
    {
        private const string _url = @"https://jsonplaceholder.typicode.com/albums";

        public Albums Get(int id)
        {
            Albums _return = null;

            try
            {
                var _json = RestHelper.GetJsonRequest(_url, $"id={id}");

                if(!String.IsNullOrEmpty(_json))
                    _return = JsonConvert.DeserializeObject<Albums>(_json);
            }
            catch (Exception x)
            {
                throw;
            }

            return _return;
        }

        public IList<Albums> GetAll()
        {
            List<Albums> _return = null;

            try
            {
                var _json = RestHelper.GetJsonRequest(_url);

                if (!String.IsNullOrEmpty(_json))
                    _return = JsonConvert.DeserializeObject<List<Albums>>(_json);
            }
            catch (Exception x)
            {
                throw;
            }

            return _return;
        }
    }
}
