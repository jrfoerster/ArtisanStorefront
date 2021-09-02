using ArtisanStorefront.Data;
using ArtisanStorefront.Models;
using System;
using System.Linq;

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



        //UPDATE
        public bool UpdateOrder(EditOrder model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .Orders
                .Single(e => e.OrderId == model.OrderId && e.SellerId == _userId);

                entity.Quantity = model.Quantity;
                entity.IsExpedited = model.IsExpedited;

                return ctx.SaveChanges() == 1;
            }
        }


    }

   

    

}
