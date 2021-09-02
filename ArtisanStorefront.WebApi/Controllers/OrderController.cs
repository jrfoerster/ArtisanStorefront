using ArtisanStorefront.Models;
using ArtisanStorefront.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace ArtisanStorefront.WebApi.Controllers
{
    public class OrderController : ApiController
    {
        private OrderService CreateOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var orderService = new OrderService(userId);
            return orderService;
        }

        //Get order by ID
        public IHttpActionResult Get(int id)
        {
            OrderService orderService = CreateOrderService();
            var order = orderService.GetOrderById(id);
            return Ok(order);
        }

        // POST: api/Order
        public IHttpActionResult Post(OrderCreate order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOrderService();

            if (!service.CreateOrder(order))
                return InternalServerError();

            return Ok();
        }

        // PUT: api/Order/5
        public IHttpActionResult Put(EditOrder order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOrderService();

            if (!service.UpdateOrder(order))
                return InternalServerError();

            return Ok();
        }

        // DELETE: api/Order/5
        public IHttpActionResult Delete(int id)
        {
            var service = CreateOrderService();
            if (!service.DeleteOrder(id))
                return InternalServerError();

            return Ok();
        }
    }
}
