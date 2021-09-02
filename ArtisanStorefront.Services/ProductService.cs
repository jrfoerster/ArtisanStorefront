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


        // GET -- READ
        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .Products
                .Where(e => e.SellerId == _userId)
                .Select(
                e =>
                new ProductListItem
                {
                    ProductId = e.ProductId,
                    Name = e.Name,
                }
                );
                return query.ToArray();
            }
        }

        //GET BY ID ---  READ BY ID
        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .Products
                .Single(e => e.ProductId == id && e.SellerId == _userId);
                return
                new ProductDetail
                {
                    ProductId = entity.ProductId,
                    Name = entity.Name,
                    Description = entity.Description,
                    Price = entity.Price,
                    Stock = entity.Stock,
                    SellerId = entity.SellerId,
                    ProductType = entity.ProductType
                };
            }
        }


    }
}
