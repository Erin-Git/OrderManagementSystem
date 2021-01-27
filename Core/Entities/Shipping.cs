using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Shipping
    {
        [Key]
        public int ShippingId { get; set; }
        public string ShippingMethod { get; set; }
    }
}
