using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models // the point is to be specific as to where the code is
{
    public class User : AEntity
    {
        public List<Order> Orders { get; set; }

        public Store SelectedStore { get; set; }

        public User()
        {
            Orders = new List<Order>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach(var p in Orders.Last().Pizzas)
            {
                sb.AppendLine(p.ToString());
            }

            // $ means you can take any properties of fields of that object and get the string value of them
            return $"you have selected this store: {SelectedStore} and ordered these pizzas: { sb.ToString() }"; // called string interpolation
            //return $"I have selected this store: {SelectedStore}"; // called string concatenation
        }
    }
}