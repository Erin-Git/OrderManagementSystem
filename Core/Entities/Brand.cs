using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
