using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        ///public float TotalPrice { get; set; }
        public bool Status { get; set; }
        public bool CancelStatus { get; set; }
        public int ProductInventoryId { get; set; }
        public ProductInventory ProductInventory { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ShippingId { get; set; }
        public Shipping Shipping { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public int HiddenPKId { get; set; }
    }
}
