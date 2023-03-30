using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProduct
    {
        List<Product> GetProducts();

        Product GetProduct(int id);

        void AddProduct(Product product);

        void DeleteProduct(int id);

        void UpdateProduct(Product product);
    }
}
