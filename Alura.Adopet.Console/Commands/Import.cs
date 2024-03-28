using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Commands
{
    [CommandDoc(instruction: "import", documentation: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
    internal class Import:ICommand
    {
        private readonly HttpPetClient petClient;
        public Import(HttpPetClient petClient)
        {
            this.petClient = petClient;
        }
        private async Task FilePetImportAsync(string fileImportPath)
        {
            var reader = new ReadFile();
            List<Pet> listaDePet = reader.GetPetList(fileImportPath);

            foreach (var pet in listaDePet)
            {
                try
                {
                    await petClient.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }

        public async Task ExecuteAsync(string[] args)
        {
            await this.FilePetImportAsync(fileImportPath: args[1]);
        }
    }
}
