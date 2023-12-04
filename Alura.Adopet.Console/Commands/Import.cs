using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Commands
{
    [CommandDoc(instruction: "import", documentation: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
    internal class Import:ICommand
    {
        HttpClient client;
        public Import()
        {
            client = ConfiguraHttpClient("http://localhost:5057");
        }
        private async Task FilePetImportAsync(string fileImportPath)
        {
            var reader = new ReadFile();
            List<Pet> listaDePet = reader.GetPetList(fileImportPath);

            foreach (var pet in listaDePet)
            {
                try
                {
                    var resposta = await CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }

        Task<HttpResponseMessage> CreatePetAsync(Pet pet)
        {
            HttpResponseMessage? response = null;
            using (response = new HttpResponseMessage())
            {
                return client.PostAsJsonAsync("pet/add", pet);
            }
        }

        HttpClient ConfiguraHttpClient(string url)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);
            return _client;
        }

        public async Task ExecuteAsync(string[] args)
        {
            await this.FilePetImportAsync(fileImportPath: args[1]);
        }
    }
}
