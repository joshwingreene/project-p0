using System.Collections.Generic;

namespace PizzaWorld.Domain.Models // the point is to be specific as to where the code is
{
    public class User
    {
        public List<Order> Orders { get; set; }

        public User()
        {
            Orders = new List<Order>();
        }
        public Store SelectedStore { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach(var p in Orders.Last().Pizza)
            {
                sb.AppendLine(p.ToString());
            }

            // $ means you can take any properties of fields of that object and get the string value of them
            return $"you have have selected this store: {SelectedStore} and ordered these pizzas: { sb.ToString() }"; // called string interpolation
            //return $"I have selected this store: {SelectedStore}"; // called string concatenation
        }
    }
}