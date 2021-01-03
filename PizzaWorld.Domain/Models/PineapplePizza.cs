using PizzaWorld.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaWorld.Domain.Models
{
    public class PineapplePizza : APizzaModel
    {
        protected override void AddCrust()
        {
            Crust = new Crust("Regular");
        }

        protected override void AddSize()
        {
            Size = new Size("Medium", 12);
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
    }
}