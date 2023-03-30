using Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : IProduct
    {

        Try1dbContext Context;

        public ProductService(Try1dbContext try1DbContext)
        {
            Context = try1DbContext;
        }

        public void AddProduct(Product product)
        {
            Context.Products.Add(product);
            Save();
        }

        public void DeleteProduct(int id)
        {
            var product = Context.Products.Where(x => x.Id == id).FirstOrDefault();
            Context.Products.Remove(product);
            Save();
        }

        public Product GetProduct(int id)
        {
            var product = Context.Products.Where(x => x.Id == id).FirstOrDefault();
            return product;
        }

        public List<Product> GetProducts()
        {
            var list = Context.Products.ToList();
            return list;
        }

        public void UpdateProduct(Product product)
        {
            Context.Products.Update(product);
            Save();
        }

        private void Save()
        {
            Context.SaveChanges();
        }
    }
}
