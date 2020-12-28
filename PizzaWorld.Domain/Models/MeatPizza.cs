using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class MeatPizza : APizzaModel
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
            Toppings = new List<Topping>
            {
                new Topping("Cheese"),
                new Topping("Pepperoni"),
                new Topping("Sausage"),
            };
        }
    }
}