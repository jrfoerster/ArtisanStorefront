using ArtisanStorefront.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtisanStorefront.Models
{
	public class ProductDetail
	{
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid SellerId { get; set; }
        public Category ProductType { get; set; }
    }
}
