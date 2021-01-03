using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Factories;
using System.Collections.Generic;
using System;
using System.Linq;

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

        public void PrintPriceOfLastPizza()
        {
            Console.WriteLine(Pizzas.Last().GetTotalPrice());
        }

        public void ChangeLastPizzaSize(string sizeName)
        {
            switch (sizeName)
            {
                case "Small":
                    Pizzas.Last().Size = new Size("Small", 12, .99m);
                    break;
                case "Medium":
                    Pizzas.Last().Size = new Size("Medium", 12, 2.99m);
                    break;
                case "Large":
                    Pizzas.Last().Size = new Size("Large", 12, 4.99m);
                    break;
            }
        }

        public void MakeMeatPizza()
        {
            Pizzas.Add(_pizzaFactory.Make<MeatPizza>());
        }

        public void MakePineapplePizza()
        {
            Pizzas.Add(_pizzaFactory.Make<PineapplePizza>());
        }
    }
}
