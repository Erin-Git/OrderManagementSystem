using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public string ProductCategoryTitle { get; set; }
    }
}
