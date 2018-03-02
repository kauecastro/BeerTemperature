using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerTemperature.Models
{
    public class BeetType
    {
        public int id { get; set; }
        public string name { get; set; }
        public int minTemperature { get; set; }
        public int maxTemperature { get; set; }
        public List<Product> products { get; set; }
    }
}