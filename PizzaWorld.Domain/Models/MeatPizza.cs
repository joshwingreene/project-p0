using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class MeatPizza : APizzaModel
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
                new PizzaTopping(this, new Topping { Name = "Sausage" })
            };
        }
        
        protected override void AddTypePrice()
        {
            TypePrice = 5.99m;
        }
    }
}