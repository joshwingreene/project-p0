using System;

namespace PizzaWorld.Domain.Abstracts
{
    public abstract class AEntity
    {
        public long EntityId { get; set; }

        protected AEntity()
        {
            //EntityId = DateTime.Now.Ticks; // commented out bc sql has a way of creating unique IDs by default
        }
    }
}