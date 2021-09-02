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



        //UPDATE
        public bool UpdateNote(EditOrder model)
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
