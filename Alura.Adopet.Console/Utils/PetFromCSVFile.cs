using Alura.Adopet.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Utils
{
    public static class PetFromCsvFile
    {
        public static Pet ConvertFromText(this string line)
        {
            string[]? properties = line.Split(';');

            return new Pet(Guid.Parse(properties[0]), properties[1],
                int.Parse(properties[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro);
        }
    }
}
