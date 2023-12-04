using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Commands
{
    [CommandDoc(instruction: "show", documentation: "adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n")]
    internal class Show:ICommand
    {
        public Task ExecuteAsync(string[] args)
        {
            this.ShowFileContent(filePath: args[1]);
            return Task.CompletedTask;
        }

        private void ShowFileContent(string filePath)
        {
            ReadFile reader = new ReadFile();
            var petList = reader.GetPetList(filePath);
            foreach (var pet in petList)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
