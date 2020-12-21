namespace PizzaWorld.Domain.Models // the point is to be specific as to where the code is
{
    public class Order // changed to public in order for the test to get access to it
    {
        public Order()
        {
            Pizzas = new List<APizzaModel>();
        }
    }
}