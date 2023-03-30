using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProduct ProductService;

        public ProductController(IProduct iproduct) 
        {
            ProductService = iproduct;
        }

        [HttpGet(nameof(GetProducts))]
        public List<Product> GetProducts()
        {
            return ProductService.GetProducts();
        }

        [HttpGet(nameof(GetProduct))]
        public Product GetProduct(int id) 
        {
            return ProductService.GetProduct(id);
        }

        [HttpPost(nameof(AddProduct))]
        public void AddProduct([FromBody] Product product) 
        {
            ProductService.AddProduct(product);
        }

        [HttpDelete(nameof(DeleteProduct))]
        public void DeleteProduct(int id)
        {
            ProductService.DeleteProduct(id);
        }

        [HttpGet(nameof(UpdateProduct))]
        public void UpdateProduct(Product product)
        {
            ProductService.UpdateProduct(product);
        }
    }
}
