using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ArtisanStorefront.Data;

namespace ArtisanStorefront.WebApi.Controllers
{
    public class OrderController : ApiController
    {
        // GET: api/Order
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // GET: api/Order/5
        // public string Get(int id)
        // {
        //    return "value";
        // }


        //Get order by ID
        [HttpGet]
        public IHttpActionResult Get(int orderId)
        {
            OrderService orderService = CreateOrderService();
            var order = orderService.GetOrderById(orderId);
            return Ok(order);
        }
    }

    // POST: api/Order
    public void Post([FromBody]string value)
        {
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
      //  public void Delete(int id)
       // {
       // }

    public IHttpActionResult Delete(int orderId)
    {
        var service = CreateOrderService();
        if (!service.DeleteOrder(orderId))
            return InternalServerError();

        return Ok();

    }
        
}
