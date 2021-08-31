using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtisanStorefront.Data
{
    public enum Category
    {
        Candles,
        Lamps,
        JumpRopes,
        Clothes
    }

    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public Guid SellerId { get; set; }

        [Required]
        public Category ProductType { get; set; }
    }
}
