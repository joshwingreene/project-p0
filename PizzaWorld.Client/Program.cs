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

        static void UserView()
        {
            var user = new User();

            //PrintAllStores();
            PrintAllStoresWithEF();
            
            user.SelectedStore = _client.SelectStore();
            user.SelectedStore.CreateOrder();
            user.Orders.Add(user.SelectedStore.Orders.Last()); // last because the above line just created a new order
            // while loop (user user.SelectPizza() until the user says no more pizza)
            user.Orders.Last().MakeMeatPizza();
            user.Orders.Last().MakeMeatPizza();

            System.Console.WriteLine(user);
        }
    }
}
