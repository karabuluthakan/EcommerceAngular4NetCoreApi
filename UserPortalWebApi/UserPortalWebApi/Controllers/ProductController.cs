using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Web.Http;
using UserPortalWebApi.Models;

namespace UserPortalWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ApiController
    {
        private readonly Context _context;
        public ProductController(Context context)
        {
            _context = context;
        }
        List<Product> productList = new List<Product>()
        {
            new Product(){Name="Bilgisayar",Price=500,ProductID=1},
            new Product(){Name="Monitör",Price=200,ProductID=2},
            new Product(){Name="Klavye",Price=50,ProductID=3},
            new Product(){Name="Kamera",Price=60,ProductID=4}
        };
        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productList.ToList();
        }

        // GET api/values/5
        // [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productList.FirstOrDefault(x => x.ProductID == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            productList.Add(product);
        }

        // PUT api/values/5
        //  [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product newProduct)
        {
            var oldProduct = productList.FirstOrDefault(x => x.ProductID == id);
            oldProduct.Name = newProduct.Name;
            oldProduct.Price = newProduct.Price;
        }

        // DELETE api/values/5
        // [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = productList.FirstOrDefault(x => x.ProductID == id);
            productList.Remove(product);
        }
    }
}
