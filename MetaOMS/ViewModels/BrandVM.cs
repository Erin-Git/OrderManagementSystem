using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MetaOMS.ViewModels
{
    public class BrandVM
    {
        public int SerialNo { get; set; }
        public int BrandVMId { get; set; }

        [DisplayName("Name of the supplier brand or company")]
        [Required(ErrorMessage = "This Field is required !")]
        public string BrandVMName { get; set; }
        public int CurrentPage { get; set; }

    }
}
