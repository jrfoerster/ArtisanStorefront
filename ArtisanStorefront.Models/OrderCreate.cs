using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtisanStorefront.Models
{
   public class OrderCreate
    {
        [Required]
        public int Quantity { get; set; }
        public decimal AmountDue { get; set; }
    }
}
