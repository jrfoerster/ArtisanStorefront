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

        public bool DeleteProduct(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var product = context.Products.Find(id);
                context.Products.Remove(product);
                return context.SaveChanges() == 1;
            }
        }
    }
}
