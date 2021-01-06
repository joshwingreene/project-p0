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

        [Fact]
        private void Test_CheckCreateOrder()
        {
            // arrange
            var sut = new Store();

            // act
            sut.CreateOrder();
            var actual = sut;

            // assert
            Assert.True(actual.Orders.Count == 1);
        }

        [Fact]
        private void Test_CheckDeleteOrder()
        {
            // arrange
            var sut = new Store();

            sut.CreateOrder();
            sut.CreateOrder();

            var order = sut.Orders[1];

            // act
            var actual = sut.DeleteOrder(order);

            // assert
            Assert.True(actual == true);
            Assert.True(sut.Orders.Count == 1);
        }
    }
}