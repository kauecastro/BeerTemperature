using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeerTemperature.DAO;
using BeerTemperature.Models;

namespace BeerTemperature.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public string GetMinTemperature(string beerName)
        {
            if (beerName == null)
                throw new Exception("BeerName is required !");

            ProductDAO productDAO = new ProductDAO();

            var products = productDAO.Read(new Product() { productName = beerName });

            var minTemperature = products.FirstOrDefault().beerType.minTemperature.ToString();

            return minTemperature;
        }

        public string CreateProduct(string beerName, string typeName)
        {
            if (beerName == null || typeName == null)
                throw new Exception("All the arguments are required !");

            ProductDAO productDAO = new ProductDAO();

            var typeId = (int)Enum.Parse(typeof(BeerTypesCatalog), typeName);

            BeetType beerType = new BeetType() { id = typeId };

            productDAO.Create(new Product() { productName = beerName, beerType = beerType });


            return "";
        }

    }
}