using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;
using CarsStore.Models;

namespace CarsStore.Data
{
    public partial class CarStoreEntities : DbContext
    {
        public CarStoreEntities()
                : base("name=CarStore")
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<BodyStyle> BodyStyles { get; set; }
        public DbSet<Interior> Interiors { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<PurchaseType> PurchaseTypes { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Specials> Specials { get; set; }
        public DbSet<State> States { get; set; }
    }
}