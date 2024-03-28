using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Models;

namespace Alura.Adopet.Console.Services
{
    public class HttpPetClient
    {
        // cria instância de HttpClient para consumir API Adopet
        readonly HttpClient client;
        public HttpPetClient(HttpClient client)
        {
            this.client = client;
        }
        public async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }

        public Task CreatePetAsync(Pet pet)
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }


    }
}
