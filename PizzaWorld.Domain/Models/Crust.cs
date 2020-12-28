using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Crust : AEntity
    {
        public string Name { get; set; }

        public Crust() {}

        public Crust(string name) {
            Name = name;
        }
    }
}