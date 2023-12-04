using Alura.Adopet.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Utils
{
    internal class ReadFile
    {
        public List<Pet> GetPetList(string filePath)
        {
            List<Pet> petList = new List<Pet>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                System.Console.WriteLine("------ Dados a serem importados ------");
                while (!sr.EndOfStream)
                {
                    //Separa linha usando ponto e virgula
                    string[]? properties = sr.ReadLine().Split(';');
                    //cria objeto Pet a partir da separacao
                    Pet pet = new Pet(Guid.Parse(properties[0]), properties[1],
                        int.Parse(properties[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro);
                    petList.Add(pet);
                }
            }

            return petList;
        }
    }
}
