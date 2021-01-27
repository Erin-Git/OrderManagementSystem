using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; }
    }
}
