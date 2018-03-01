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

        public EntityContext() : base("data source=.\\SQLEXPRESS; initial catalog=ESupplements; Integrated Security=true; user id=sa; password=Zener47kaue;") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<BeetType> BeerTypes { get; set; }

    }
}