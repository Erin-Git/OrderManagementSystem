using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaOMS.ViewModels
{
    public class DeliveryVM
    {
        public int DeliveryVMId { get; set; }
        public int SerialNo { get; set; }
        public DateTime DeliveredVMDate { get; set; }
        public DateTime OrderPlacedVMDate { get; set; }
        public bool StatusVM { get; set; }
        public bool ReturnVMStatus { get; set; }
        public bool RefundVMStatus { get; set; }
        public bool ReturnRefundVMStatus { get; set; }
        public bool ReturnedRefundedVMStatus { get; set; }
        public string ComplaintVMDescription { get; set; }
        public int OrderVMId { get; set; }
        public int DeliveryStaffVMId { get; set; }
        public float TotalPriceVM { get; set; }
        public int CustomerVMId { get; set; }
        public string CustomerVMName { get; set; }
        public string ProductVMName { get; set; }
        public string CustomerVMArea { get; set; }
        public string CustomerVMDistrict { get; set; }
        public string CustomerVMSubDistrict { get; set; }
        public string CustomerVMHouseNo { get; set; }
        public string CustomerVMRoadNo { get; set; }
        public string CustomerVMContactNo { get; set; }
        public int ShippingVMId { get; set; }
        public string ShippingVMMethod { get; set; }
        public int PaymentVMId { get; set; }
        public string PaymentVMMethod { get; set; }
        public int ProductVMId { get; set; }
        public string StringStatusVM { get; set; }
        public string StringReturnedRefundedVMStatus { get; set; }
        public int HiddenPKVMId { get; set; }
        public int CurrentPage { get; set; }
        //created for return purpose
        public int QuantityVM { get; set; }
        public int TotalOrderVMCount { get; set; }
        public int TotalDeliveryVMCount { get; set; }
        public int TotalPendingDeliveryVMCount { get; set; }
        public int TotalPendingReturnRefundVMCount { get; set; }
        public int TotalPendingOrdersVMCount { get; set; }
        public int TotalCancelledOrderVMCount { get; set; }
        public int TotalReturnedRefundedOrderVMCount { get; set; }
        public int TotalCustomerVMCount { get; set; }
        public int TotalAvaiableProductVMCount { get; set; }
        public int CountOnlyDeliveredforChart { get; set; }
        //public int CountOnlyCancelledforChart { get; set; }
        //public int CountOnlyReturnedRefundedforChart { get; set; }
        public float ProfitVM { get; set; }
        public ProductInventory_VM productInventory_VM { get; set; } = new ProductInventory_VM();

    }
}
