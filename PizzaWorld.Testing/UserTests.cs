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
            var sut = new User("test", "12345");

            // act
            var actual = sut;

            // assert
            Assert.IsType<User>(actual);
            Assert.NotNull(actual);
        }
    }
}