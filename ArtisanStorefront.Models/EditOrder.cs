using ArtisanStorefront.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtisanStorefront.Models
{
    public class EditOrder
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
       
        public int Quantity { get; set; }

        public bool IsExpedited { get; set; }
    }
}
