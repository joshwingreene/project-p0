using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Factories;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

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

        public decimal GetCurrentTally()
        {
            decimal total = 0.0m;

            foreach (var pizza in Pizzas)
            {
                total += pizza.GetTotalPrice();
            }

            return total;
        }

        public void PrintPizzas()
        {
            var sb = new StringBuilder();

            foreach(var p in Pizzas)
            {
                sb.AppendLine(p.ToString());
            }

            System.Console.WriteLine("Your order includes the following pizzas:");
            System.Console.WriteLine(sb);
        }

        public void ChangeLastPizzaSize(string sizeName, List<Size> availSizes)
        {
            var lastPizza = Pizzas.Last();

            switch (sizeName)
            {
                case "Small":
                    lastPizza.Size = availSizes.Find(s => s.Name == "Small");
                    break;
                case "Medium":
                    lastPizza.Size = availSizes.Find(s => s.Name == "Medium");
                    break;
                case "Large":
                    lastPizza.Size = availSizes.Find(s => s.Name == "Large");
                    break;
            }
        }

        public void ChangePizzaSize(int index, string sizeStr, List<Size> availSizes)
        {
            var selectedPizza = Pizzas[index];

            switch (sizeStr)
            {
                case "Small":
                    selectedPizza.Size = availSizes.Find(c => c.Name == "Small");
                    break;
                case "Regular":
                    selectedPizza.Size = availSizes.Find(c => c.Name == "Medium");
                    break;
                case "Large":
                    selectedPizza.Size = availSizes.Find(c => c.Name == "Large");
                    break;
            }
        }

        public void ChangePizzaCrust(int index, string crustStr, List<Crust> availCrusts)
        {
            var selectedPizza = Pizzas[index];

            switch (crustStr)
            {
                case "Thin":
                    selectedPizza.Crust = availCrusts.Find(c => c.Name == "Thin");
                    break;
                case "Regular":
                    selectedPizza.Crust = availCrusts.Find(c => c.Name == "Regular");
                    break;
                case "Large":
                    selectedPizza.Crust = availCrusts.Find(c => c.Name == "Large");
                    break;
            }
        }
        
        public void RemovePizza(int index)
        {
            Pizzas.RemoveAt(index);
        }

        public bool CheckIfZeroPizzas()
        {
            return Pizzas.Count == 0;
        }

        private void AddMajorPizzaParts(APizzaModel currentPizza, List<Crust> availCrusts, List<Size> availSizes, List<Topping> availToppings)
        {
            currentPizza.AddCrust(availCrusts);
            currentPizza.AddSize(availSizes);
            currentPizza.AddToppings(availToppings);
        }

        public void MakeMeatPizza(List<Crust> availCrusts, List<Size> availSizes, List<Topping> availToppings)
        {
            Pizzas.Add(_pizzaFactory.Make<MeatPizza>());
            AddMajorPizzaParts(Pizzas.Last(), availCrusts, availSizes, availToppings);
        }

        public void MakePineapplePizza(List<Crust> availCrusts, List<Size> availSizes, List<Topping> availToppings)
        {
            Pizzas.Add(_pizzaFactory.Make<PineapplePizza>());
            AddMajorPizzaParts(Pizzas.Last(), availCrusts, availSizes, availToppings);
        }
    }
}
