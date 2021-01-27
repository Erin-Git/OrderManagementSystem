using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MetaOMS.ViewModels
{
    public class ProductInventoryVM
    {
        //public ProductInventoryVM()
        //{
        //    productInventoryVMs = new List<ProductInventoryVM>();
        //}
        
        public int SerialNo { get; set; }
        public int ProductVMId { get; set; }
        public string NameVM { get; set; }
        public string ColorVM { get; set; }
        public string SizeVM { get; set; }
        public string MaterialVM { get; set; }
        public string DescriptionVM { get; set; }
        public float PurchasePriceVM { get; set; } // per product
        public float SellPriceVM { get; set; } // per product
        [DisplayName("Stock in quantity")]
        [Required(ErrorMessage = "This Field is required !")]
        public int StockInQuantityVM { get; set; }
        public int AvailableQuantityVM { get; set; }
        public int BrandVMId { get; set; }
        public string BrandNameVM { get; set; }
        public string ProductCategoryTitleVM { get; set; }
        public int ProductCategoryIdVM { get; set; }
        public DateTime StockInDateVM { get; set; }
        public int CurrentPage { get; set; }
        //quantity of ordered products in order list
        public int QuantityVM { get; set; }
        //total price of ordered products in order list
        public float EachPriceVM { get; set; }
        public float TotalPriceVM { get; set; }
        public bool StatusVM { get; set; }
        public string StringStatusVM { get; set; }
        public string ComplaintDescriptionVM { get; set; }
        public float ProductVMUnitCost { get; set; }
        public float ProfitEachVM { get; set; }
        //public List<ProductInventoryVM> productInventoryVMs { get; set; }
    }
    public enum ColorEnum
    {
        Black, Blue, Brown, Green, Grey, Purple, Orange, Red, White, Yellow
    }
    public enum SizeEnum
    {
        XS, SM, M, L, XL, XXL
    }
    public enum MaterialEnum
    {
        Chiffon, Cotton, Denim, Georgette, Halfsilk, Leather, Linen, Satin, Silk, Velvet, Wool
    }
}
