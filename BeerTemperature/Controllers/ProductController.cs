using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeerTemperature.DAO;
using BeerTemperature.Models;
using Newtonsoft.Json;

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

            if(products == null || products.Count <= 0)
                throw new Exception("There are no products with this filter !");

            var minTemperature = products.FirstOrDefault().beerType.minTemperature.ToString();

            return minTemperature;
        }

        public string ReadProducts(string beerName = null)
        {
            ProductDAO productDAO = new ProductDAO();

            var products = productDAO.Read(new Product() { productName = beerName });
            return JsonConvert.SerializeObject(products);
        }

        public string CreateProduct(string beerName, string typeName)
        {
            if (beerName == null || typeName == null)
                throw new Exception("All the arguments are required !");

            ProductDAO productDAO = new ProductDAO();

            var typeId = (int)Enum.Parse(typeof(BeerTypesCatalog), typeName);

            BeetType beerType = new BeetType() { id = typeId };

            productDAO.Create(new Product() { productName = beerName, beerType = beerType });


            return "Product created !";
        }

        public string UpdateProduct(int id, string beerName = "", string typeName = null)
        {
            int typeId;

            if (id <= 0)
                throw new Exception("The ID of the product is required !");

            ProductDAO productDAO = new ProductDAO();

            BeetType beerType = new BeetType();

            if (typeName != null)
            {
                typeId = (int)Enum.Parse(typeof(BeerTypesCatalog), typeName);
                beerType.id = typeId;
            }

            productDAO.UpdateById(new Product() { id = id, productName = beerName, beerType = beerType });


            return "Product Updated !";
        }

        public string DeleteProduct(string beerName)
        {
            if (beerName == null)
                throw new Exception("A beerName are required !");

            ProductDAO productDAO = new ProductDAO();

            productDAO.Delete(new Product() { productName = beerName });

            return "Product deleted with success !";
        }

    }
}