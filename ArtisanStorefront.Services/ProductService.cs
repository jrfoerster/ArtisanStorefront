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

        public bool CreateProduct(ProductCreate model)
        {
            var entity = new Product()
            {
                SellerId = _userId,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Stock = model.Stock,
                ProductType = model.ProductType
            };

            using (var context = new ApplicationDbContext())
            {
                context.Products.Add(entity);
                return context.SaveChanges() == 1;
            }
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
      
        public bool DeleteProduct(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var product = context.Products.Find(id);

                if (product is null)
                {
                    return false;
                }

                context.Products.Remove(product);
                return context.SaveChanges() == 1;
            }
        }
    }
}
