using System;
using System.Linq;
using System.Collections.Generic;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;

namespace PizzaWorld.Client
{
    class Program
    {
        private static readonly ClientSingleton _client = ClientSingleton.Instance;

        private static readonly SqlClient _sql = new SqlClient();

        /*
        public Program()
        {
            _client = new ClientSingleton.Instance;
        }
        */

        static void Main(string[] args)
        {
            //var cs = ClientSingleton.Instance; // want avilable during the runtime
            
            //_client.MakeAStore();

            /*
            PrintAllStores();
            System.Console.WriteLine(_client.SelectStore());
            */

            UserView();
        }

        /*
        static IEnumerable<Store> GetAllStores()
        {
            return new List<Store>()
            {
                new Store(), // C# allows you to do this (adds one Store object to the List)
                new Store()
            };
            
        }
        */

        static void PrintAllStores()
        {
            foreach(var store in _client.Stores)
            {
                System.Console.WriteLine(store);
            }
        }

        static void PrintAllStoresWithEF()
        {
            foreach (var store in _sql.ReadStores())
            {
                System.Console.WriteLine(store);
            }
        }

        static void PrintAvailablePizzaTypes()
        {
            List<string> availablePizzaTypes = new List<string>
            {
                "Meat",
                "Pineapple"
            };

            foreach (var pizzaType in availablePizzaTypes)
            {
                System.Console.WriteLine(pizzaType);
            }
        }

        static void UserView()
        {
            var user = new User();

            _sql.SaveUser(user);

            //PrintAllStores();
            PrintAllStoresWithEF();
            
            user.SelectedStore = _sql.SelectStore();
            user.SelectedStore.CreateOrder();
            user.Orders.Add(user.SelectedStore.Orders.Last()); // last because the above line just created a new order
            
            string input = "";

            while (input != "submit")
            {
                PrintAvailablePizzaTypes();
                System.Console.WriteLine("Enter a type of pizza to add to your order. Or Enter \"submit\" to submit your order");
                input = Console.ReadLine();
                switch (input)
                {
                    case "Meat":
                        user.Orders.Last().MakeMeatPizza();
                        break;
                    case "Pineapple":
                        user.Orders.Last().MakePineapplePizza();
                        break;
                    case "submit":
                        _sql.Update(user.SelectedStore);
                        System.Console.WriteLine(user);
                        break;
                }
            }
        }
    }
}
