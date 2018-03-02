using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTemperature.Models;
using System.Data.Entity;

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
                product.beerType = context.BeerTypes.Where(q => q.id == product.beerType.id).FirstOrDefault();
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public List<Product> Read(Product product)
        {
            if (product == null)
                throw new Exception("Product is required to cretate in database !");

            List<Product> productResponse = new List<Product>();
            using (var context = new EntityContext())
            {
                var products = context.Products.Include(x => x.beerType).ToList();

                if (product.id > 0)
                    products = products.Where(q => q.id == product.id).ToList();
                if (product.productName != null && !string.IsNullOrEmpty(product.productName))
                    products = products.Where(q => q.productName == product.productName).ToList();

                if (products == null)
                    throw new Exception("There are no products in the database with this filter !");

                foreach (var p in products)
                {
                    BeetType beerType = new BeetType()
                    {
                        id = p.beerType.id,
                        name = p.beerType.name,
                        minTemperature = p.beerType.minTemperature,
                        maxTemperature = p.beerType.maxTemperature
                    };

                    productResponse.Add(new Product()
                    {
                        id = p.id,
                        productName = p.productName,
                        beerType = beerType
                    });
                }
            }

            return productResponse;
        }

        public void UpdateById(Product product)
        {
            if (product == null)
                throw new Exception("Product is required to update in database !");

            Product productResponse = new Product();

            using (var context = new EntityContext())
            {

                var products = context.Products.Include(x => x.beerType).FirstOrDefault(x => x.id == product.id);

                if (products == null)
                    throw new Exception("There are no products in the database with this id !");

                if (product.productName != null && !string.IsNullOrEmpty(product.productName))
                    products.productName = product.productName;

                if (product.beerType.id > 0)
                {
                    var beerType = context.BeerTypes.Where(q => q.id == product.beerType.id).FirstOrDefault();
                    if (beerType != null)
                        product.beerType = beerType;
                }
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            if (product == null)
                throw new Exception("Product is required to cretate in database !");

            Product productResponse = new Product();

            using (var context = new EntityContext())
            {
                var products = from p in context.Products select p;

                if (product.id > 0)
                    products = products.Where(q => q.id == product.id);

                if (products == null)
                    throw new Exception("There are no products in the database with this id !");

                productResponse = products.FirstOrDefault();
                context.Products.Remove(productResponse);
                context.SaveChanges();
            }
        }
    }
}