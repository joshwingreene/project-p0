using System.IO;
using System.Collections.Generic;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Singletons
{
    public class ClientSingleton
    {
        private static ClientSingleton _instance; // TODO - look into why this should be static (this was the last step to create a singleton)
        public static ClientSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClientSingleton();
                }

                return _instance;
            }
        }

        public List<Store> Stores { get; set; }

        private ClientSingleton() // private becauase we don't want anyone other than ClientSingleton to create it
        {
            Stores = new List<Store>(); // gives the stores an actual place in memory
        }

        public void GetAllStores()
        {

        }

        public void MakeAStore()
        {
            var s = new Store();

            Stores.Add(s);
            Save();
        }

        private void Save()
        {
            string path = @"./pizzaworld.xml";
            var file = new StreamWriter(path);
            var xml = new XmlSerializer(typeof(List<Store>)); // serializer wants the data type's definition

            xml.Serialize(file, Stores);
        }
    }
}