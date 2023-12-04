using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Commands
{
    internal interface ICommand
    {
        Task ExecuteAsync(string[] args);
    }
}
