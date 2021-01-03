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
            AddToppings();
            AddTypePrice();
        }

        public decimal GetTotalPrice() 
        {
            return Crust.Price + Size.Price + TypePrice;
        }

        protected virtual void AddCrust() {}
        protected virtual void AddSize() {}
        protected virtual void AddToppings() {}
        protected virtual void AddTypePrice() {}
    }
}