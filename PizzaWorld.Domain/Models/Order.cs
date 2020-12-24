using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Factories;
using System.Collections.Generic;

namespace PizzaWorld.Domain.Models // the point is to be specific as to where the code is
{
    public class Order : AEntity // changed to public in order for the test to get access to it
    {
        private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();

        public List<APizzaModel> Pizzas { get; set; }

        public Order()
        {
            Pizzas = new List<APizzaModel>();
        }

        public void MakeMeatPizza()
        {
            Pizzas.Add(_pizzaFactory.Make<MeatPizza>());
        }
    }
}
