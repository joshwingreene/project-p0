using System;
using System.Collections.Generic;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintAllStores();
        }

        static IEnumerable<Store> GetAllStores()
        {
            return new List<Store>()
            {
                new Store(), // C# allows you to do this (adds one Store object to the List)
                new Store()
            };
        }

        static void PrintAllStores()
        {
            foreach(var store in GetAllStores())
            {
                System.Console.WriteLine(store);
            }
        }
    }
}
