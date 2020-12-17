using Xunit;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Testing
{
    public class StoreTests
    {
        [Fact]
        private void Test_StoreExists()
        {
            // arrange
            var sut = new Store();

            // act
            var actual = sut;

            // assert
            Assert.IsType<Store>(actual);
            Assert.NotNull(actual);
        }
    }
}