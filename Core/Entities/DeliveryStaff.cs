using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class DeliveryStaff
    {
        [Key]
        public int DeliveryStaffId { get; set; }
        public string DeliveryStaffName { get; set; }
        public string ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
