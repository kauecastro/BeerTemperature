using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTemperature.Models;

namespace BeerTemperature.DAO
{
    public class ProductDAO
    {
        public void Create(Product product)
        {
            if (product == null)
                throw new Exception("Product is required to cretate in database !");
            using (var context = new EntityContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }



        public Product Read(Product product)
        {
            if (product == null)
                throw new Exception("Product is required to cretate in database !");

            Product productResponse = new Product();
                using (var context = new EntityContext())
                {
                    var products = from p in context.Products select p;

                    //Filters
                    if (product.id > 0)
                        products = products.Where(q => q.id == product.id);
                    if (product.productName != null && !string.IsNullOrEmpty(product.productName))
                        products = products.Where(q => q.productName == product.productName);

                    productResponse = products.FirstOrDefault();
                }

            return productResponse;
        }





    }
}