using System.Collections.Generic;
using System;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models // the point is to be specific as to where the code is
{
    public class Store : AEntity
    {
        public List<Order> Orders { get; set; }

        /* crud methods
        - create
        - read
        - update
        - delete
        */

        public void CreateOrder()
        {
            Orders.Add(new Order());
        }

        bool DeleteOrder(Order order) // "tell me what to delete"
        {
            try
            {
                Orders.Remove(order);

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                GC.Collect(); // tells GC that whatever is here is ready to be cleaned out (level 1 or its critical that we need more memory)
            }
        }
    }
}