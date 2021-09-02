﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtisanStorefront.Models
{
    public class OrderDetail
    {


        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset PurchaseDate { get; set; }

        public decimal AmountDue { get; set; }

        public bool IsExpedited { get; set; }

        public Guid BuyerId { get; set; }

        public Guid SellerId { get; set; }

    }
}
