using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Crust : AEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Crust() {}

        public Crust(string name, decimal price) {
            Name = name;
            Price = price;
        }
    }
}