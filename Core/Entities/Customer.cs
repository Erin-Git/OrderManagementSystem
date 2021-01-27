using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string Area { get; set; }
        public string RoadNo { get; set; }
        public string HouseNo { get; set; }
        public string GoogleMapAddress { get; set; }
        public string ContactNo { get; set; }
    }
}
