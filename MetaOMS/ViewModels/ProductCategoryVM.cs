using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MetaOMS.ViewModels
{
    public class ProductCategoryVM
    {
        public int SerialNo { get; set; }
        public int ProductCategoryVMId { get; set; }
        [DisplayName("Name of product category")]
        [Required(ErrorMessage = "This Field is required !")]
        public string ProductCategoryVMTitle { get; set; }
        public int CurrentPage { get; set; }

    }
}
