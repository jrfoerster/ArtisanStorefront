using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtisanStorefront.Data;
using ArtisanStorefront.Models;

namespace ArtisanStorefront.Services
{
    public class OrderService
    {
        private readonly Guid _userId;

        public OrderService(Guid userId)
        {
            _userId = userId;
        }

        public OrderDetail GetOrderById(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == orderId && e.SellerId == _userId);
                return
                    new OrderDetail
                    {
                        OrderId = entity.OrderId,
                        Quantity = entity.Quantity,
                        PurchaseDate = entity.PurchaseDate,
                        AmountDue = entity.AmountDue,
                        IsExpedited = entity.IsExpedited,
                        BuyerId = entity.BuyerId,
                        SellerId = entity.SellerId,

                    };
            }
        }

        public bool DeleteOrder(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == orderId && e.SellerId == _userId);

                ctx.Orders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }

   

    

}
