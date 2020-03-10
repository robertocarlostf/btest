using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Data.Helpers
{
    public class RestHelper
    {
        public static string GetJsonRequest(string url, string queryString = null)
        {
            if (String.IsNullOrEmpty(url))
                throw new ArgumentException("URL is required");

            try
            {
                string _return = null;

                using (var _client = new HttpClient())
                {
                    _client.BaseAddress = new Uri(url);
                    _return = _client.GetStringAsync(queryString ?? $"?{queryString}").Result;
                }
               
                return _return;
            }
            catch (HttpRequestException wx)
            {
                throw;
            }
            catch (Exception x)
            {
                throw;
            }
        }
    }
}
