using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaOMS.ViewModels
{
    public class OrderVM
    {
        public int SerialNo { get; set; }
        public int OrderVMId { get; set; }
        public int HiddenPKVMId { get; set; }
        public DateTime OrderVMDate { get; set; }
        public DateTime DeliverVMDate { get; set; }
        public int QuantityVM { get; set; }
        public float TotalPriceVM { get; set; }
        public bool StatusVM { get; set; }
        public bool CancelVMStatus { get; set; }
        //for showing string type status
        public string StringStatusVM { get; set; }
        public int ProductVMId { get; set; }
        public string ProductVMName { get; set; }
        public int ShippingVMId { get; set; }
        public string ShippingVMMethod { get; set; }
        public int PaymentVMId { get; set; }
        public string PaymentVMMethod { get; set; }
        public string ProductVMColor { get; set; }
        public string ProductVMSize { get; set; }
        public string ProductVMMaterial { get; set; }
        public string ProductVMCategory { get; set; }
        public string ProductVMBrand { get; set; }
        public float ProductVMEachPrice { get; set; }
        //for showing in update order, sum of sub-totals
        //public float ProductVMAllTotalPrice { get; set; }
        public int CustomerVMId { get; set; }
        public string CustomerVMName { get; set; }
        public string CustomerVMContactNo { get; set; }
        public string CustomerVMArea { get; set; }
        public string CustomerVMDistrict { get; set; }
        public string CustomerVMSubDistrict { get; set; }
        public string CustomerVMHouseNo { get; set; }
        public string CustomerVMRoadNo { get; set; }
        public ProductInventory_VM productInventory_VM { get; set; } = new ProductInventory_VM();
    }
}
