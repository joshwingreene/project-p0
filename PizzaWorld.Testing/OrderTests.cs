using Xunit;
using PizzaWorld.Domain.Models;
using System.Collections.Generic;

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

        [Fact]
        private void Test_VerifyOrderTally()
        {
            // arrange
            var order = new Order();
            var meat = new MeatPizza();
            var pineapple = new PineapplePizza();

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

            meat.AddCrust(crusts);
            meat.AddSize(sizes);
            meat.AddToppings(toppings);

            pineapple.AddCrust(crusts);
            pineapple.AddSize(sizes);
            pineapple.AddToppings(toppings);

            order.Pizzas.Add(meat);
            order.Pizzas.Add(pineapple);

            // act
            var actual = order.GetCurrentTally();

            // assert
            Assert.True(actual == 21.94m);
        }

        [Fact]
        private void Test_ConfirmPizzaCrustChanged()
        {
            // arrange
            var order = new Order();
            var meat = new MeatPizza();

            List<Crust> crusts = new List<Crust>()
            {
                new Crust { EntityId = 1, Name = "Thin", Price = .99m },
                new Crust { EntityId = 2, Name = "Regular", Price = 1.99m },
                new Crust { EntityId = 3, Name = "Large", Price = 2.99m }
            };

            meat.AddCrust(crusts);
            order.Pizzas.Add(meat);

            // act
            order.ChangePizzaCrust(0, "Large", crusts);
            var actual = order;

            // assert
            Assert.True(actual.Pizzas[0].Crust.Name == "Large");
        }

        [Fact]
        private void Test_ConfirmPizzaSizeChanged()
        {
            // arrange
            var order = new Order();
            var meat = new MeatPizza();

            List<Size> sizes = new List<Size>()
            {
                new Size { EntityId = 1, Name = "Small", Inches = 10, Price = .99m },
                new Size { EntityId = 2, Name = "Medium", Inches = 12, Price = 2.99m },
                new Size { EntityId = 3, Name = "Large", Inches = 14, Price = 4.99m }
            };

            meat.AddSize(sizes);
            order.Pizzas.Add(meat);

            // act
            order.ChangePizzaSize(0, "Small", sizes);
            var actual = order;

            // assert
            Assert.True(actual.Pizzas[0].Size.Name == "Small");
        }

        [Fact]
        private void Test_ConfirmPizzaRemoved()
        {
            // arrange
            var order = new Order();
            var meat = new MeatPizza();
            var pineapple = new PineapplePizza();

            order.Pizzas.Add(meat);
            order.Pizzas.Add(pineapple);

            // act
            order.RemovePizza(1);
            var actual = order;

            // assert
            Assert.True(actual.Pizzas.Count == 1);
        }
    }
}