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
        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new ProductService(userId);
        }

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
        public IHttpActionResult Post([FromBody] ProductCreate product)
        {
            if (product is null)
            {
                return BadRequest("Http Request Body cannot be empty!");
            }

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var service = CreateProductService();

            if (service.CreateProduct(product) == false)
            {
                return InternalServerError();
            }

            return Ok();
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
        public IHttpActionResult Delete(int id)
        {
            var service = CreateProductService();

            if (service.DeleteProduct(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
