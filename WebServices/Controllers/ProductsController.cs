using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public class Product
        {
            public int ID { get; set; }
            public string ProductName { get; set; }
            public string Price { get; set; }
            public string Quantity { get; set; }
        }

        public static List<Product> productList = new List<Product>()
        {
           new Product
            {
                ID = 101,
                ProductName = "Computer",
                Price = "40000",
                Quantity = "1"
            },
            new Product
            {
                ID = 102,
                ProductName = "Mouse",
                Price = "400",
                Quantity = "1"
            },
            new Product
            {
                ID = 104,
                ProductName = "Speaker",
                Price = "4000",
                Quantity = "1"
            }
        };

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productList;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            Product prodObject = (from prod in productList
                                  where prod.ID == id
                               select prod).SingleOrDefault();
            return prodObject;
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] Product prodValue)
        {
            productList.Add(prodValue);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product prodValue)
        {
            Product prodObj= (from product in productList
                                         where product.ID == prodValue.ID
                                      select product).SingleOrDefault();

            prodObj.ProductName = prodValue.ProductName;
            prodObj.Price = prodValue.Price;
            prodObj.Quantity = prodValue.Quantity;
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productList.RemoveAll(x => x.ID == id);
        }
    }
}
