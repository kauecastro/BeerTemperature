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

                if (product.id > 0)
                    products = products.Where(q => q.id == product.id);
                if (product.productName != null && !string.IsNullOrEmpty(product.productName))
                    products = products.Where(q => q.productName == product.productName);

                if (products == null)
                    throw new Exception("There are no products in the database with this id !");

                productResponse = products.FirstOrDefault();
            }

            return productResponse;
        }

        public void UpdateById(Product product)
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
                productResponse.productName = product.productName;
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