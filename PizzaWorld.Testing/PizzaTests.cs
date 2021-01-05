using PizzaWorld.Domain.Models;
using Xunit;
using System.Collections.Generic;

namespace PizzaWorld.Testing
{
    public class PizzaTests
    {
        [Fact]
        private void Test_PizzaExists()
        {
            // arrange
            var sut = new MeatPizza(); // inference

            // act
            var actual = sut;

            // assert
            Assert.IsType<MeatPizza>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        private void Test_VerifyPricingComputation()
        {
            // arrange
            var sut = new MeatPizza(); // inference

            List<Crust> crusts = new List<Crust>()
            {
                new Crust { EntityId = 1, Name = "Thin", Price = .99m },
                new Crust { EntityId = 2, Name = "Regular", Price = 1.99m },
                new Crust { EntityId = 3, Name = "Large", Price = 2.99m }
            };

            List<Size> sizes = new List<Size>()
            {
                new Size { EntityId = 1, Name = "Small", Inches = 10, Price = .99m },
                new Size { EntityId = 2, Name = "Medium", Inches = 12, Price = 2.99m },
                new Size { EntityId = 3, Name = "Large", Inches = 14, Price = 4.99m }
            };

            List<Topping> toppings = new List<Topping>()
            {
                    new Topping { EntityId = 1, Name = "Cheese"},
                    new Topping { EntityId = 2, Name = "Pepperoni"},
                    new Topping { EntityId = 3, Name = "Sausage"},
                    new Topping { EntityId = 4, Name = "Pineapple"}
            };

            sut.AddCrust(crusts);
            sut.AddSize(sizes);
            sut.AddToppings(toppings);

            // act
            var actual = sut.GetTotalPrice();

            // assert
            Assert.True(actual == 10.97m);
        }

        [Fact]
        private void Test_CheckCrustAdded()
        {
            // arrange
            var sut = new MeatPizza(); // inference

            List<Crust> crusts = new List<Crust>()
            {
                new Crust { EntityId = 1, Name = "Thin", Price = .99m },
                new Crust { EntityId = 2, Name = "Regular", Price = 1.99m },
                new Crust { EntityId = 3, Name = "Large", Price = 2.99m }
            };

            // act
            sut.AddCrust(crusts);
            var actual = sut;

            // assert
            Assert.IsType<Crust>(actual.Crust);
            Assert.NotNull(actual.Crust);
        }

        [Fact]
        private void Test_CheckSizeAdded()
        {
            // arrange
            var sut = new MeatPizza(); // inference

            List<Size> sizes = new List<Size>()
            {
                new Size { EntityId = 1, Name = "Small", Inches = 10, Price = .99m },
                new Size { EntityId = 2, Name = "Medium", Inches = 12, Price = 2.99m },
                new Size { EntityId = 3, Name = "Large", Inches = 14, Price = 4.99m }
            };

            // act
            sut.AddSize(sizes);
            var actual = sut;

            // assert
            Assert.IsType<Size>(actual.Size);
            Assert.NotNull(actual.Size);
        }

        [Fact]
        private void Test_CheckToppingsAdded()
        {
            // arrange
            var sut = new MeatPizza(); // inference

            List<Topping> toppings = new List<Topping>()
            {
                    new Topping { EntityId = 1, Name = "Cheese"},
                    new Topping { EntityId = 2, Name = "Pepperoni"},
                    new Topping { EntityId = 3, Name = "Sausage"},
                    new Topping { EntityId = 4, Name = "Pineapple"}
            };

            // act
            sut.AddToppings(toppings);
            var actual = sut;

            // assert
            Assert.True(actual.PizzaToppings.Count == 3);
        }

        [Fact]
        private void Test_CheckPriceAdded()
        {
            // arrange
            var sut = new MeatPizza(); // inference

            // act
            var actual = sut;

            // assert
            Assert.True(actual.TypePrice == 5.99m);
        }

        [Fact]
        private void Test_CheckNameAdded()
        {
            // arrange
            var sut = new MeatPizza(); // inference

            // act
            var actual = sut;

            // assert
            Assert.True(actual.Name == "Meat Pizza");
        }
    }
}