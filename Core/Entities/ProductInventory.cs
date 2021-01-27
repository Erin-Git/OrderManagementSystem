using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class ProductInventory
    {
        [Key]
        public int ProductInventoryId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public float PurchasePrice { get; set; } // per product
        public float SellPrice { get; set; } // per product
        public DateTime StockInDate { get; set; }
        public int StockInQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
