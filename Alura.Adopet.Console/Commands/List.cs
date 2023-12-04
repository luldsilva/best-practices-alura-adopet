using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Commands
{
    [CommandDoc(instruction: "list", documentation: "adopet list comando que exibe no terminal o conteudo cadastrado na base de dados do AdoPet.")]
    internal class List:ICommand
    {
        public Task ExecuteAsync(string[] args)
        {
            this.PetDataListFromAPIAsync();
            return Task.CompletedTask;
        }

        private async Task PetDataListFromAPIAsync()
        {
            var httpPetList = new HttpPetClient();
            IEnumerable<Pet>? pets = await httpPetList.ListPetsAsync();
            System.Console.WriteLine("------ Lista de Pets importados no sistema ------");
            if(pets != null && pets.Any())
            {
                foreach (var pet in pets)
                {
                    System.Console.WriteLine(pet);
                }
            }
        }
    }
}
