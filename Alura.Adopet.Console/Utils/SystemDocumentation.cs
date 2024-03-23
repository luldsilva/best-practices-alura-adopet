using Alura.Adopet.Console.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Utils
{
    public class SystemDocumentation
    {
        public static Dictionary<string, CommandDoc> ToDictionary(Assembly assemblyWithDocCommandType)
        {
            return assemblyWithDocCommandType.GetTypes()
                .Where(t => t.GetCustomAttributes<CommandDoc>().Any())
                .Select(t => t.GetCustomAttribute<CommandDoc>()!)
                .ToDictionary(d => d.Instruction);
        }
    }
}
