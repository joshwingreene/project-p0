using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Singletons
{
    public class ClientSingleton
    {
        private const string _path = @"./pizzaworld.xml";

        // singleton (which is a creational design pattern) - static on the creation part (which is the _instance and Instance) (only one instance for each one)
        // using static on the class (only one of) would force us to make everything static

        private static ClientSingleton _instance;
        public static ClientSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClientSingleton(); // exactly once
                }

                return _instance;
            }
        }

        public List<Store> Stores { get; set; }

        public List<APizzaModel> Pizzas { get; set; }

        private ClientSingleton() // private becauase we don't want anyone other than ClientSingleton to create it
        {
            Read();
            //Stores = new List<Store>(); // gives the stores an actual place in memory
        }

        public void GetAllStores()
        {

        }

        public void MakeAStore()
        {
            Stores.Add(new Store());
            Save();
        }

        public Store SelectStore()
        {
            int.TryParse(Console.ReadLine(), out int input); // 0 or selection
            // if we just had Parse instead of TryParse - you will either get the result or 0

            //Stores.FirstOrDefault(s => s == input); // assumption - unipe property and user gave the right input/info
            // the above line forces you to edit the store class
            return Stores.ElementAtOrDefault(input); // null if there are no stores in the list
            
            //Stores[input]; // exception (indexing is expecting a number)
        }

        private void Save()
        {
            /*
            var file = new StreamWriter(_path);
            var xml = new XmlSerializer(typeof(List<Store>)); // serializer wants the data type's definition

            xml.Serialize(file, Stores);
            */

            using (var file = new StreamWriter(_path))
            {
                var xml = new XmlSerializer(typeof(List<Store>));

                xml.Serialize(file, Stores);
            }
        }

        private void Read()
        {
            if (!File.Exists(_path))
            {
                Stores = new List<Store>();
                return;
            }

            var file = new StreamReader(_path);
            var xml = new XmlSerializer(typeof(List<Store>));

            Stores = xml.Deserialize(file) as List<Store>;

            /*
            if (File.Exists(_path))
            {
                var file = new StreamReader(_path);
                var xml = new XmlSerializer(typeof(List<Store>));

                Stores = xml.Deserialize(file) as List<Store>;
            }
            else
            {
                Stores = new List<Store>(); // don't want Read to create stores
            }
            */
        }
    }
}