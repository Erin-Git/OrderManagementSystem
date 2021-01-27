using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
        public DateTime DeliveredDate { get; set; }
        public bool Status { get; set; }
        public bool ReturnStatus { get; set; }
        public bool RefundStatus { get; set; }
        public bool ReturnRefundStatus { get; set; }
        public bool ReturnedRefundedStatus { get; set; }
        public string ComplaintDescription { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int DeliveryStaffId { get; set; }
        public DeliveryStaff DeliveryStaff { get; set; }
    }
}
