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

        private static void CreateAndProcessOrder(User user) // TODO: Thinking about having the list of parts be sent as params
        {
            user.SelectedStore.CreateOrder();
            user.Orders.Add(user.SelectedStore.Orders.Last()); // last because the above line just created a new order
            
            List<Crust> availableCrusts = _sql.GetCrusts().ToList();
            List<Size> availableSizes = _sql.GetSizes().ToList();
            List<Topping> availableToppings = _sql.GetToppings().ToList();

            Order currentOrder = user.Orders.Last();
            string submitInput = "";

            do
            {
                PrintAvailablePizzaTypes();
                System.Console.WriteLine("Enter a type of pizza to add to your order.");
                string typeInput = Console.ReadLine();
                System.Console.WriteLine("Enter the size for your pizza");
                string sizeInput = Console.ReadLine();
                
                switch (typeInput)
                {
                    case "Meat":
                        currentOrder.MakeMeatPizza(availableCrusts, availableSizes, availableToppings);
                        break;
                    case "Pineapple":
                        currentOrder.MakePineapplePizza(availableCrusts, availableSizes, availableToppings);
                        break;
                    default:
                        break;
                }
                currentOrder.ChangeLastPizzaSize(sizeInput, availableSizes); // Reason for no if - editing a pizza to small and then back to medium
                currentOrder.PrintPriceOfLastPizza();
                System.Console.WriteLine("Current Order Total: " + currentOrder.GetCurrentTally());

                System.Console.WriteLine("What would you like to do?");
                System.Console.WriteLine("a) Add another pizza to your order");
                System.Console.WriteLine("b) Edit the pizzas in your order");
                System.Console.WriteLine("c) Checkout");
                //System.Console.WriteLine("Would you like to add another pizza to your order or checkout? Enter \"submit\" to submit your order");
                submitInput = Console.ReadLine();

                //TODO - Thinking about putting the edit code here
            } while (submitInput == "a");

            if (submitInput == "c")
            {
                // Display final tally and associated message
                System.Console.WriteLine("Final Order Total: " + currentOrder.GetCurrentTally());

                _sql.Update(user.SelectedStore);
                System.Console.WriteLine(user);

                do
                {
                    System.Console.WriteLine("Thank you for your order. Will that be all?");
                    System.Console.WriteLine("a) Yes");
                    System.Console.WriteLine("b) Show previous orders");
                    System.Console.WriteLine("c) Make another order");
                    submitInput = Console.ReadLine();

                    switch (submitInput)
                    {
                        case "a":
                            System.Console.WriteLine("Thank you. Come again!");
                            break;
                        case "b":
                            // TODO
                            break;
                        case "c":
                            CreateAndProcessOrder(user);
                            break;
                        default:
                            break;
                    }
                } while (submitInput == "b");
            } 
        }

        static void UserView()
        {
            var user = new User();

            _sql.SaveUser(user);

            //PrintAllStores();
            PrintAllStoresWithEF();
            
            user.SelectedStore = _sql.SelectStore();

            CreateAndProcessOrder(user);

            /*
            user.SelectedStore.CreateOrder();
            user.Orders.Add(user.SelectedStore.Orders.Last()); // last because the above line just created a new order
            
            List<Crust> availableCrusts = _sql.GetCrusts().ToList();
            List<Size> availableSizes = _sql.GetSizes().ToList();
            List<Topping> availableToppings = _sql.GetToppings().ToList();

            Order currentOrder = user.Orders.Last();
            string submitInput = "";

            do
            {
                PrintAvailablePizzaTypes();
                System.Console.WriteLine("Enter a type of pizza to add to your order.");
                string typeInput = Console.ReadLine();
                System.Console.WriteLine("Enter the size for your pizza");
                string sizeInput = Console.ReadLine();
                
                switch (typeInput)
                {
                    case "Meat":
                        currentOrder.MakeMeatPizza(availableCrusts, availableSizes, availableToppings);
                        break;
                    case "Pineapple":
                        currentOrder.MakePineapplePizza(availableCrusts, availableSizes, availableToppings);
                        break;
                    default:
                        break;
                }
                currentOrder.ChangeLastPizzaSize(sizeInput);
                currentOrder.PrintPriceOfLastPizza();
                System.Console.WriteLine("Current Order Total: " + currentOrder.GetCurrentTally());

                System.Console.WriteLine("What would you like to do?");
                System.Console.WriteLine("a) Add another pizza to your order");
                System.Console.WriteLine("b) Edit the pizzas in your order");
                System.Console.WriteLine("c) Checkout");
                //System.Console.WriteLine("Would you like to add another pizza to your order or checkout? Enter \"submit\" to submit your order");
                submitInput = Console.ReadLine();

                //TODO - Thinking about putting the edit code here
            } while (submitInput == "a");

            if (submitInput == "c")
            {
                // Display final tally and associated message
                System.Console.WriteLine("Final Order Total: " + currentOrder.GetCurrentTally());

                _sql.Update(user.SelectedStore);
                System.Console.WriteLine(user);

                System.Console.WriteLine("Thank you for your order. Will that be all?");
                System.Console.WriteLine("a) Yes");
                System.Console.WriteLine("b) Show previous orders");
                System.Console.WriteLine("c) Make another order");
            } 

            */
        }
    }
}
