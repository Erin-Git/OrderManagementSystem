using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MetaOMS.ViewModels
{
    public class CustomerVM
    {
        public int SerialNo { get; set; }
        public int CustomerVMId { get; set; }
        [DisplayName("Customer's Name")]
        [Required(ErrorMessage = "This Field is required !")]
        public string CustomerVMName { get; set; }
        [DisplayName("Customer's District")]
        [Required(ErrorMessage = "This Field is required !")]
        public string DistrictVM { get; set; }
        [DisplayName("Customer's Sub-district")]
        [Required(ErrorMessage = "This Field is required !")]
        public string SubDistrictVM { get; set; }
        [DisplayName("Customer's Area")]
        [Required(ErrorMessage = "This Field is required !")]
        public string AreaVM { get; set; }
        [DisplayName("Customer's Road No.")]
        [Required(ErrorMessage = "This Field is required !")]
        public string RoadNoVM { get; set; }
        [DisplayName("Customer's House No.")]
        [Required(ErrorMessage = "This Field is required !")]
        public string HouseNoVM { get; set; }
        [DisplayName("Enter Link (Google Map) of the Address")]
        [Required(ErrorMessage = "This Field is required !")]
        public string GoogleMapAddressVM { get; set; }
        [DisplayName("Customer's Phone Number")]
        [Required(ErrorMessage = "This Field is required !")]
        public string ContactNoVM { get; set; }
        public int CurrentPage { get; set; }

    }
}
