using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
