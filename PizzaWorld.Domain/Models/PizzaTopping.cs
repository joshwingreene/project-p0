using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class PizzaTopping : AEntity
    {
        public APizzaModel Pizza { get; set; }
        public Topping Topping { get; set; }

        public PizzaTopping() {}

        public PizzaTopping(APizzaModel pizza, Topping topping)
        {
            Pizza = pizza;
            Topping = topping;
        }
    }
}