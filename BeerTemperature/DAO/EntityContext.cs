using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BeerTemperature.Models;

namespace BeerTemperature.DAO
{
    public class EntityContext : DbContext
    {

        public EntityContext() : base("Name=BTContext") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<BeetType> BeerTypes { get; set; }

    }
}