using PizzaWorld.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaWorld.Domain.Models
{
    public class PineapplePizza : APizzaModel
    {
        protected override void AddCrust()
        {
            Crust = new Crust("Regular", 1.99m);
        }

        protected override void AddSize()
        {
            Size = new Size("Medium", 12, 2.99m);
        }

        protected override void AddToppings()
        {
            PizzaToppings = new List<PizzaTopping>
            {
                new PizzaTopping(this, new Topping { Name = "Cheese" }),
                new PizzaTopping(this, new Topping { Name = "Pepperoni" }),
                new PizzaTopping(this, new Topping { Name = "Pineapple" })
            };
        }

        protected override void AddTypePrice()
        {
            TypePrice = 5.99m;
        }
    }
}