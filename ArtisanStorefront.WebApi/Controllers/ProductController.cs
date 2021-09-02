using ArtisanStorefront.Models;
using ArtisanStorefront.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArtisanStorefront.WebApi.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        // GET: api/Product
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
       
       
        
            private ProductService CreateProductService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var productService = new ProductService(userId);
                return productService;
            }

            public IHttpActionResult Put(ProductEdit product)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var service = CreateProductService();

                if (!service.UpdateProduct(product))
                    return InternalServerError();

                return Ok();
            }
        

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
