using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MetaOMS.ViewModels
{
    public class ShippingVM
    {
        public int SerialNo { get; set; }

        public int ShippingVMId { get; set; }
        [DisplayName("Name of shipping method")]
        [Required(ErrorMessage = "This Field is required !")]
        public string ShippingVMMethod { get; set; }
        public int CurrentPage { get; set; }

    }
}
