using System.Collections.Generic;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Abstracts
{
    public class APizzaModel : AEntity // no longr abstract bc creating a new migration expects concrete classes
    {
        public Crust Crust { get; set; }
        public Size Size { get; set; }
        public List<PizzaTopping> PizzaToppings { get; set; }

        public decimal TypePrice { get; set; }

        protected APizzaModel()
        {
            AddCrust();
            AddSize();
            AddTypePrice();
        }

        public decimal GetTotalPrice() 
        {
            return Crust.Price + Size.Price + TypePrice;
        }

        protected virtual void AddCrust() {}
        protected virtual void AddSize() {}
        protected virtual void AddTypePrice() {}
        public virtual void AddToppings(List<Topping> availableToppings) {}
    }
}