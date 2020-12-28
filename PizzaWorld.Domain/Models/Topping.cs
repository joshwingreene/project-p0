using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Topping : AEntity
    {
        public string Name { get; set; }

        public Topping() {}

        public Topping(string name)
        {
            Name = name;
        }
    }
}