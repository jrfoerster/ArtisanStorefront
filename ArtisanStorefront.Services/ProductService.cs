using ArtisanStorefront.Data;
using ArtisanStorefront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtisanStorefront.Services
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public bool UpdateProduct(ProductEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .Products
                .Single(e => e.ProductId == model.ProductId && e.SellerId == _userId);

                entity.ProductId = model.ProductId;
                entity.Name = model.Name;
                entity.Stock = model.Stock;
                entity.Price = model.Price;

                return ctx.SaveChanges() == 1;
            }
            
        }


    }
}
