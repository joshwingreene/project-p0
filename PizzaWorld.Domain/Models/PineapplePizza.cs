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

        public override void AddToppings(List<Topping> availableToppings)
        {   
            PizzaToppings = new List<PizzaTopping>
            {
                new PizzaTopping(this, availableToppings.Find(t => t.Name == "Cheese")),
                new PizzaTopping(this, availableToppings.Find(t => t.Name == "Pepperoni")),
                new PizzaTopping(this, availableToppings.Find(t => t.Name == "Pineapple"))
            };
        }

        protected override void AddTypePrice()
        {
            TypePrice = 5.99m;
        }
    }
}