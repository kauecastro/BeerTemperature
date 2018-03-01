using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerTemperature.Models
{
    public class Product
    {
        public int id { get; set; }
        public string productName { get; set; }
        public BeetType beerType { get; set; }
    }
}