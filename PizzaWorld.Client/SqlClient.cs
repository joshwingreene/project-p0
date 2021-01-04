using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storing;

namespace PizzaWorld.Client
{
    public class SqlClient // Used to put the actual data into the database
    {
        private readonly PizzaWorldContext _db = new PizzaWorldContext();

        public SqlClient()
        {
            /*
            if (ReadStores().Count() == 0)
            {
                CreateStore();
            }
            */
        }

        // Orders

        public IEnumerable<Order> ReadOrders(Store store)
        {
            return ReadOne(store.Name).Orders;
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