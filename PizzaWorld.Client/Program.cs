using System;
using System.Linq;
using System.Collections.Generic;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Singletons;

namespace PizzaWorld.Client
{
    class Program
    {
        private static readonly SqlClient _sql = new SqlClient();

        static void Main(string[] args)
        {
            UserView();
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

        private static void PrintTallyWithMsg(string msg, Order order)
        {
            System.Console.WriteLine("\n" + msg + ":\n");
            System.Console.WriteLine(order);
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
                System.Console.WriteLine("Available Pizzas:");
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
                //currentOrder.PrintPriceOfLastPizza();
                PrintTallyWithMsg("Current Order Total", currentOrder);

                do
                {
                    System.Console.WriteLine("What would you like to do?");
                    System.Console.WriteLine("a) Add another pizza to your order");
                    if (!currentOrder.CheckIfZeroPizzas())
                    {
                        System.Console.WriteLine("b) Edit the pizzas in your order");
                        System.Console.WriteLine("c) Checkout");
                    }
                    else
                    {
                        System.Console.WriteLine("d) Cancel Order");
                    }

                    submitInput = Console.ReadLine();

                    // Edit Pizza Area
                    if (submitInput == "b")
                    {
                        currentOrder.PrintPizzas();
                        System.Console.WriteLine("Which pizza would you like to edit? (use numbers, starting from 0)");
                        int.TryParse(Console.ReadLine(), out int pizzaNumInput);

                        var selectedPizza = currentOrder.Pizzas.ElementAtOrDefault(pizzaNumInput);

                        System.Console.WriteLine("What do you want to do with this pizza?");
                        System.Console.WriteLine("a) Change the type of crust");
                        System.Console.WriteLine("b) Change the size");
                        System.Console.WriteLine("c) Remove it");
                        
                        string editOptionInput = Console.ReadLine();

                        switch (editOptionInput)
                        {
                            case "a": // TODO: Use one common method for this two cases
                                System.Console.WriteLine(selectedPizza.ToString() + "'s Currrent Crust: " + selectedPizza.Crust.ToString());
                                System.Console.WriteLine("What do you want to change the Crust to");
                                foreach (var c in availableCrusts)
                                {
                                    System.Console.WriteLine(c);
                                }
                                string crustChoiceInput = Console.ReadLine();
                                currentOrder.ChangePizzaCrust(pizzaNumInput, crustChoiceInput, availableCrusts);
                                PrintTallyWithMsg("Updated Order Tally", currentOrder);
                                break;
                            case "b":
                                System.Console.WriteLine(selectedPizza.ToString() + "'s Currrent Size: " + selectedPizza.Size.ToString());
                                System.Console.WriteLine("What do you want to change the Size to?");
                                foreach (var c in availableSizes)
                                {
                                    System.Console.WriteLine(c);
                                }
                                string sizeChoiceInput = Console.ReadLine();
                                currentOrder.ChangePizzaSize(pizzaNumInput, sizeChoiceInput, availableSizes);
                                PrintTallyWithMsg("Updated Order Tally", currentOrder);
                                break;
                            case "c":
                                currentOrder.RemovePizza(pizzaNumInput);
                                PrintTallyWithMsg("Updated Order Tally", currentOrder);
                                break;
                            default:
                                break;
                        }
                    }

                }   while (submitInput == "b");
                
            } while (submitInput == "a");

            if (submitInput == "c")
            {
                // Display final tally and associated message
                PrintTallyWithMsg("Final Order Total", currentOrder);

                _sql.Update(user.SelectedStore);
                //System.Console.WriteLine(user);

                do
                {
                    System.Console.WriteLine("Thank you for your order. Will that be all?");
                    System.Console.WriteLine("a) Yes");
                    System.Console.WriteLine("b) Show order history");
                    System.Console.WriteLine("c) Make another order");
                    submitInput = Console.ReadLine();

                    switch (submitInput)
                    {
                        case "a":
                            System.Console.WriteLine("Thank you. Come again!");
                            break;
                        case "b":
                            _sql.DisplayUserOrderHistory(user);
                            break;
                        case "c":
                            CreateAndProcessOrder(user);
                            break;
                        default:
                            break;
                    }
                } while (submitInput == "b");
            } 

            if (submitInput == "d")
            {
                user.SelectedStore.DeleteOrder(currentOrder);
                System.Console.WriteLine("Thank you. Come again!");
            }
        }

        static void UserView()
        {
            Console.WriteLine("Welcome to PizzaWorld!");
            Console.WriteLine("a) Sign In");
            Console.WriteLine("b) Create Account");
            string accountInput = Console.ReadLine();

            User user = null;
            string usernameInput = "";
            string passwordInput = "";

            if (accountInput == "a")
            {
                do
                {
                    Console.WriteLine("Enter Username");
                    usernameInput = Console.ReadLine();

                    Console.WriteLine("Enter Password");
                    passwordInput = Console.ReadLine();

                    user = _sql.GetUserIfCredentialsAreValid(usernameInput, passwordInput);

                    if (user == null) {
                        Console.WriteLine("Your credentials were incorrect. Please try again");
                    }
                    
                } while (user == null);
            }
            else if (accountInput == "b")
            {
                bool AlreadyExists = false;
                do
                {
                    Console.WriteLine("Select Username");
                    usernameInput = Console.ReadLine();

                    AlreadyExists = _sql.CheckIfUsernameExists(usernameInput);

                    if (AlreadyExists)
                    {
                        Console.WriteLine("Your chosen username has been taken. Please try another one");
                    }

                } while (AlreadyExists);

                Console.WriteLine("Select Password");
                passwordInput = Console.ReadLine();

                user = new User(usernameInput, passwordInput);
                _sql.SaveUser(user);
            }

            //var user = new User();

            //_sql.SaveUser(user);

            //PrintAllStores();

            PrintAllStoresWithEF();
            
            user.SelectedStore = _sql.SelectStore();

            _sql.Update(user.SelectedStore); // this line is just in case the user cancels their order

            CreateAndProcessOrder(user);
        }
    }
}
