using Alura.Adopet.Console.Commands;
using Alura.Adopet.Console.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes
{
    public class GenerateDocumentationTest
    {
        [Fact]
        public void WhenExistsCommandsShouldBeReturnNotEmptydictionary()
        {
            //Arrange
            Assembly assemblyWithDocCommandType = Assembly.GetAssembly(typeof(CommandDoc))!;

            //Act
            Dictionary<string, CommandDoc> dictionary = SystemDocumentation.ToDictionary(assemblyWithDocCommandType);

            //Assert
            Assert.NotEmpty(dictionary);
        }
    }
}
