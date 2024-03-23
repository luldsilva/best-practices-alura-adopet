using Alura.Adopet.Console.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Commands
{
    [CommandDoc(instruction: "help", documentation: "adopet help comando que exibe informacoes da ajuda. \n" +
        "adopet help <NOME_COMANDO para acessar a ajuda de um comando especifico.>")]
    internal class Help:ICommand
    {
        private readonly Dictionary<string, CommandDoc> docs;

        public Help()
        {
            docs = SystemDocumentation.ToDictionary(Assembly.GetExecutingAssembly());
        }

        public Task ExecuteAsync(string[] args)
        {
            this.ShowDocumentation(args); 
            return Task.CompletedTask;
        }

        private void ShowDocumentation(string[] parameters)
        {
            if (parameters.Length == 1)
            {
                System.Console.WriteLine("adopet help <parametro> ous simplemente adopet help  " +
                     "comando que exibe informações de ajuda dos comandos.");
                System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
                System.Console.WriteLine("Comando possíveis: ");
                foreach (var doc in docs.Values)
                {
                    System.Console.WriteLine(doc.Documentation);
                }
            }
            else if (parameters.Length == 2)
            {
                string showableCommand = parameters[1];
                if (docs.ContainsKey(showableCommand))
                {
                    var command = docs[showableCommand];
                    System.Console.WriteLine(command.Documentation);
                }
            }
        }
    }
}
