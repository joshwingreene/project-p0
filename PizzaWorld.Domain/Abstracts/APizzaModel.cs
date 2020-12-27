//using System.Collections.Generic;

namespace PizzaWorld.Domain.Abstracts
{
    public class APizzaModel : AEntity // no longr abstract bc creating a new migration expects concrete classes
    {
        public string Crust { get; set; }
        public string Size { get; set; }
        //public List<string> Toppings { get; set; }

        protected APizzaModel()
        {
            AddCrust();
            AddSize();
            AddToppings();
        }

        protected virtual void AddCrust() {}
        protected virtual void AddSize() {}
        protected virtual void AddToppings() {}
    }
}