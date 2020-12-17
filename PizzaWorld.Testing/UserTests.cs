using Xunit;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Testing
{
    public class UserTests
    {
        [Fact]
        private void Test_UserExists()
        {
            // arrange
            var sut = new User();

            // act
            var actual = sut;

            // assert
            Assert.IsType<User>(actual);
            Assert.NotNull(actual);
        }
    }
}