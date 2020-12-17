using Xunit;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Testing
{
    public class OrderTests // tests must be public
    {
        [Fact]
        private void Test_OrderExists()
        {
            // arrange
            var sut = new Order(); // inference (infers that sut is an Order)
            // Order sut = new Order(); // statement (sut can ONLY be Order from a memory allocation standpoint)
            // (however this is not performant enough for fred to use it all the time)

            // act
            var actual = sut;

            // assert
            Assert.IsType<Order>(actual); // tests that actual is actually an order
            Assert.NotNull(actual); // tests that actual actually has a value (checks that it is pointing to a memory address)
        }
    }
}