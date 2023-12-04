using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Testes
{
    public class HttpClientPetTest
    {
        [Fact]
        public async Task PetListNotEmpty()
        {
            //Arrange
            var petClient = new HttpPetClient();
            //Act
            var petList = await petClient.ListPetsAsync();
            //Assert
            Assert.NotNull(petList);
            Assert.NotEmpty(petList);

        }
        [Fact]
        public async Task ThrowExceptionWhenAPIOff()
        {
            //Arrange
            var petClient = new HttpPetClient(uri:"http://localhost:1111");
            //Act+Assert
            await Assert.ThrowsAnyAsync<Exception>(()=> petClient.ListPetsAsync());

        }
    }
}