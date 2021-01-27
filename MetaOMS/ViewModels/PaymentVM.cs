using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MetaOMS.ViewModels
{
    public class PaymentVM
    {
        public int SerialNo { get; set; }
        public int PaymentVMId { get; set; }
        [DisplayName("Name of payment method")]
        [Required(ErrorMessage = "This Field is required !")]
        public string PaymentVMMethod { get; set; }
        public int CurrentPage { get; set; }

    }
}
