using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Services
{
    public class AdopetAPIClientFactory : IHttpClientFactory
    {
        private string uri = "http://localhost:5057";
        public HttpClient CreateClient(string name)
        {

            HttpClient _client = new HttpClient();        
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(uri);
            return _client;
        }
    }
}
