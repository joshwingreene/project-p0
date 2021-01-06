using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storing;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Client
{
    public class SqlClient // Used to put the actual data into the database
    {
        private readonly PizzaWorldContext _db = new PizzaWorldContext();

        public SqlClient() {}

        // Orders

        public IEnumerable<Order> ReadOrders(Store store)
        {
            return ReadOne(store.Name).Orders;
        }

        private void DisplayOrders(List<Order> orders)
        {
            System.Console.WriteLine("Note: Newest Orders are Shown First\n");

            orders.Sort();

            for (var o = 0; o < orders.Count; o++)
            {
                System.Console.WriteLine("Order #" + (o+1));
                System.Console.WriteLine("---------------------");
                System.Console.WriteLine(orders[o]);
            }
        }

        public void DisplayUserOrderHistory(User user)
        {
            var u = _db.Users
                        .Include(s => s.SelectedStore)
                        .Include(u => u.Orders)
                        .ThenInclude(o => o.Pizzas)
                        .FirstOrDefault(u => u.EntityId == user.EntityId);

            //u.DisplayNumberOfPastOrders();
            //u.DisplaySelectedStore();

            // Filter the user's orders with the currently selected store
            if (u.SelectedStore.Name == "Pizza Plaza")
            {
                var store1 = _db.Stores
                                .Include(o => o.Orders)
                                .FirstOrDefault(s1 => s1.EntityId == 1);

                List<Order> userOrdersFromFirstStore = new List<Order>();

                for (var i = 0; i < store1.Orders.Count; i++)
                {
                    foreach (var usr in u.Orders)
                    {
                        if (usr.EntityId == store1.Orders[i].EntityId)
                        {
                            userOrdersFromFirstStore.Add(usr);
                        }
                    }
                }

                //System.Console.WriteLine("Number of Orders from First Store: " + userOrdersFromFirstStore.Count);
                DisplayOrders(userOrdersFromFirstStore);
            }
            else if (u.SelectedStore.Name == "Pizza Bonanza")
            {
                var store2 = _db.Stores
                                .Include(o => o.Orders)
                                .FirstOrDefault(s2 => s2.EntityId == 2);

                List<Order> userOrdersFromSecondStore = new List<Order>();

                for (var i = 0; i < store2.Orders.Count; i++)
                {
                    foreach (var usr in u.Orders)
                    {
                        if (usr.EntityId == store2.Orders[i].EntityId)
                        {
                            userOrdersFromSecondStore.Add(usr);
                        }
                    }
                }

                //System.Console.WriteLine("Number of Orders from Second Store: " + userOrdersFromSecondStore.Count);
                DisplayOrders(userOrdersFromSecondStore);
            }
        }

        public void DisplayStoreOrderHistory(Store store)
        {
            var st = _db.Stores
                    .Include(o => o.Orders).ThenInclude(p => p.Pizzas).ThenInclude(c => c.Crust)
                    .Include(o => o.Orders).ThenInclude(p => p.Pizzas).ThenInclude(s => s.Size)
                    .FirstOrDefault(s1 => s1.EntityId == store.EntityId);

            DisplayOrders(st.Orders);
        }

        private void DisplaySalesForGivenPizza(string pizzaType, List<APizzaModel> pizzas)
        {
            Console.WriteLine($"\nTotal Number of {pizzaType}s Sold: {pizzas.Count}");
            var totalRevenue = 0.0m;

            foreach (var p in pizzas)
            {
                totalRevenue += p.GetTotalPrice();
            }

            Console.WriteLine($"Total Revenue from {pizzaType}: ${totalRevenue}");
        }

        private void DisplaySales(List<Order> orders)
        {
            // Filter into three piles of pizzas
            List<APizzaModel> meatPizzas = new List<APizzaModel>();
            List<APizzaModel> pineapplePizzas = new List<APizzaModel>();
            List<APizzaModel> gumboPizzas = new List<APizzaModel>();

            foreach (var o in orders)
            {
                meatPizzas.AddRange(o.Pizzas.FindAll(p => p.Name == "Meat Pizza"));
                pineapplePizzas.AddRange(o.Pizzas.FindAll(p => p.Name == "Pineapple Pizza"));
                gumboPizzas.AddRange(o.Pizzas.FindAll(p => p.Name == "Gumbo Pizza"));
            }

            DisplaySalesForGivenPizza("Meat Pizza", meatPizzas);
            DisplaySalesForGivenPizza("Pineapple Pizza", pineapplePizzas);
            DisplaySalesForGivenPizza("Gumbo Pizza", gumboPizzas);            
        }

        public void DisplayStoreSales(Store store)
        {
            var st = _db.Stores
                    .Include(o => o.Orders).ThenInclude(p => p.Pizzas).ThenInclude(c => c.Crust)
                    .Include(o => o.Orders).ThenInclude(p => p.Pizzas).ThenInclude(s => s.Size)
                    .FirstOrDefault(s1 => s1.EntityId == store.EntityId);

            DisplaySales(st.Orders);
        }

        // Stores

        public IEnumerable<Store> ReadStores()
        {
            return _db.Stores;
        }

        public Store ReadOne(string name)
        {
            return _db.Stores.FirstOrDefault<Store>(store => store.Name == name);
        }

        public void Save(Store store)
        {
            _db.Add(store); // like git add
            _db.SaveChanges(); // like git commit
        }

        public void CreateStore()
        {
            Save(new Store());
        }

        public Store SelectStore()
        {
            string input = Console.ReadLine();
            return ReadOne(input);
        }

        public void Update(Store store)
        {
            _db.SaveChanges();
        }

        // Users

        public void SaveUser(User user)
        {
            _db.Add(user);
            _db.SaveChanges();
        }

        public bool CheckIfUsernameExists(string username)
        {
            return null != _db.Users.FirstOrDefault<User>(user => user.Username == username);
        }

        public User GetUserIfCredentialsAreValid(string username, string password)
        {
            var user = _db.Users.FirstOrDefault<User>(user => user.Username == username);

            if (user != null)
            {
                if (user.Password == password)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        // Toppings
        public IEnumerable<Topping> GetToppings()
        {
            return _db.Toppings;
        }

        // Crusts
        public IEnumerable<Crust> GetCrusts()
        {
            return _db.Crusts;
        }

        // Sizes
        public IEnumerable<Size> GetSizes()
        {
            return _db.Sizes;
        }
    }
}