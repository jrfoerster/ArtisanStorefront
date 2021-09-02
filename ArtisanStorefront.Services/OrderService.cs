using ArtisanStorefront.Data;
using ArtisanStorefront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtisanStorefront.Services
{
    public class OrderService
    {
        private readonly Guid _userId;

        public OrderService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOrder(OrderCreate model)
        {
            var entity =
                new Order()
                {
                    BuyerId = _userId,
                    Quantity = model.Quantity,
                    PurchaseDate = DateTimeOffset.Now,
                    AmountDue = model.AmountDue

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Orders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


    }
}
