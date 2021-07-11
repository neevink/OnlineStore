using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using OnlineStore.DataModels;

namespace OnlineStore.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FurnitureType> FurnitureTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }

        static StoreContext()
        {
            Database.SetInitializer<StoreContext>(new StoreContextInitializer());
        }

        public StoreContext() : base ("Default") { }
    }
}