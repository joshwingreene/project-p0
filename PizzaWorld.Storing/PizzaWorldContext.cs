using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Models; // you also need to add a reference to the domain to the storing project since we need access to the model definitions here
using PizzaWorld.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaWorld.Storing /* DON'T FORGET TO REMOVE the PW BEFORE COMMITTING and PUSHING (commit the second line and save the first line somewhere on my computer) */
{
    public class PizzaWorldContext : DbContext
    {
        // representation of the schema (order is not needed because it is being tracked by both the stores and the users)
        // (this sets up the side, i.e. registering the C# objects (data types) with the ORM (the ORM does the conversion to POCOs)) (the context is the ORM)
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<APizzaModel> Pizzas { get; set; }
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Topping> Toppings { get; set; }


        // now we need to let the ORM know where to the save the data type from the C# objects
        // we do this by connecting to the database (configure our context to know where to connect to our database)
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            // REMINDER - Always add the right values when in use
            builder.UseSqlServer("Server=;Initial Catalog=;User ID=;Password=;");
        }

        // Define how records should be created
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>().HasKey(s => s.EntityId);
            builder.Entity<User>().HasKey(u => u.EntityId);
            builder.Entity<Order>().HasKey(o => o.EntityId);
            builder.Entity<APizzaModel>().HasKey(p => p.EntityId);
            builder.Entity<Crust>().HasKey(c => c.EntityId);
            builder.Entity<Size>().HasKey(sz => sz.EntityId);
            builder.Entity<Topping>().HasKey(t => t.EntityId);

            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<Store>().HasData(new List<Store>()
                {
                    new Store { EntityId = 1, Name = "First Store"},
                    new Store { EntityId = 2, Name = "Second Store"}
                }
            );
        }
    }
}