using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MiniERPRateLimitApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 50000, Quantity = 10 },
            new Product { Id = 2, Name = "Mouse", Price = 500, Quantity = 50 }
        };

        [HttpGet]
        public ActionResult<List<Product>> GetAll() => _products;
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}