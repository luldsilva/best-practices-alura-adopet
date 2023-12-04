using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes
{
    public class PetFromCSVFileTest
    {
        [Fact]
        public void PetReturnWhenValidString()
        {
            //arrange
            string line = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
            //act
            Pet pet = line.ConvertFromText();
            //assert
            Assert.NotNull(pet);
        }
    }
}
