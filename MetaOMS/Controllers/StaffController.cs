using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using MetaOMS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace MetaOMS.Controllers
{
    public class StaffController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IDeliveryService deliveryService;
        private readonly IProductInventoryService productInventoryService;

        private readonly IOrderService orderService;
        public StaffController(ICustomerService _customerService, IDeliveryService _deliveryService, 
            IOrderService _orderService, IProductInventoryService _productInventoryService)
        {
            customerService = _customerService;
            deliveryService = _deliveryService;
            productInventoryService = _productInventoryService;
            orderService = _orderService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserRoleId") == "3")
            {
                var totalOrders = orderService.CountOrders().GroupBy(q => q.HiddenPKId);
                var pendingOrders = orderService.PendingOrderList().GroupBy(q => q.HiddenPKId);
                var pendingDeliveries = deliveryService.PendingDeliveryList().GroupBy(q => q.Order.HiddenPKId);
                var successfulDeliveries = deliveryService.CountDeliveries().GroupBy(q => q.Order.HiddenPKId);
                var cancelledOrders = orderService.CancelledOrdersforChart().GroupBy(q => q.HiddenPKId);
                var returnedRefundedOrders = deliveryService.ReturnedRefundedListforChart().GroupBy(q => q.Order.HiddenPKId);
                var pendingReturnRefunds = orderService.PendingReturnRefundList().GroupBy(q => q.Order.HiddenPKId);
                var products = productInventoryService.ProductList().Sum(q => q.AvailableQuantity);

                DeliveryVM deliveryVM = new DeliveryVM()
                {
                    TotalOrderVMCount = totalOrders.Count(),
                    TotalPendingOrdersVMCount = pendingOrders.Count(),
                    TotalPendingDeliveryVMCount = pendingDeliveries.Count(),
                    TotalDeliveryVMCount = successfulDeliveries.Count(),
                    TotalCancelledOrderVMCount = cancelledOrders.Count(),
                    TotalPendingReturnRefundVMCount = pendingReturnRefunds.Count(),
                    TotalReturnedRefundedOrderVMCount = returnedRefundedOrders.Count(),
                    TotalAvaiableProductVMCount = products
                };
                return View(deliveryVM);
            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult CustomerList(int Page = 1)
        {
            if (HttpContext.Session.GetString("UserRoleId") == "3")
            {
                return View(GetListVMTypeCustomerList(Page));

            }
            return RedirectToAction("Index","Home");
        }
        private IPagedList<CustomerVM> GetListVMTypeCustomerList(int Page)
        {
            List<CustomerVM> customerVMs = new List<CustomerVM>();
            int sl = 1;
            foreach (var item in customerService.CustomerList())
            {
                CustomerVM customerVM = new CustomerVM()
                {
                    SerialNo = sl,
                    CustomerVMId = item.CustomerId,
                    CustomerVMName = item.CustomerName,
                    ContactNoVM = item.ContactNo,
                    DistrictVM = item.District,
                    SubDistrictVM = item.SubDistrict,
                    AreaVM = item.Area,
                    GoogleMapAddressVM = item.GoogleMapAddress,
                    RoadNoVM = item.RoadNo,
                    HouseNoVM = item.HouseNo
                };
                sl++;
                customerVMs.Add(customerVM);
            }
            return customerVMs.ToPagedList(Page, 10);
        }
        public IActionResult ProductList(int? Page)
        {
            if (HttpContext.Session.GetString("UserRoleId") == "3")
            {
                var pageNumber = Page ?? 1;
                int pageSize = 10;
                List<ProductInventoryVM> productInventoryVMs = new List<ProductInventoryVM>();
                int sl = 1;
                foreach (var item in productInventoryService.ProductList())
                {
                    ProductInventoryVM productInventoryVM = new ProductInventoryVM();
                    {
                        productInventoryVM.SerialNo = sl;
                        productInventoryVM.ProductVMId = item.ProductInventoryId;
                        productInventoryVM.SizeVM = item.Size;
                        productInventoryVM.NameVM = item.Name;
                        productInventoryVM.ColorVM = item.Color;
                        productInventoryVM.DescriptionVM = item.Description;
                        productInventoryVM.MaterialVM = item.Material;
                        productInventoryVM.StockInQuantityVM = item.StockInQuantity;
                        productInventoryVM.AvailableQuantityVM = item.AvailableQuantity;
                        productInventoryVM.PurchasePriceVM = item.PurchasePrice;
                        productInventoryVM.PurchasePriceVM = item.PurchasePrice;
                        productInventoryVM.StockInDateVM = item.StockInDate;
                        productInventoryVM.SellPriceVM = item.SellPrice;
                        productInventoryVM.BrandNameVM = item.Brand.BrandName;
                        productInventoryVM.BrandVMId = item.Brand.BrandId;
                        productInventoryVM.ProductCategoryTitleVM = item.ProductCategory.ProductCategoryTitle;
                        productInventoryVM.ProductCategoryIdVM = item.ProductCategory.ProductCategoryId;
                    }
                    sl++;
                    productInventoryVMs.Add(productInventoryVM);
                }
                return View(productInventoryVMs.ToPagedList(pageNumber, pageSize));
            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult AllOrders(int? Page)
        {
            if (HttpContext.Session.GetString("UserRoleId") == "3")
            {
                var pageNumber = Page ?? 1;
                int pageSize = 5;
                int sl = 1;
                List<OrderVM> orderVMs = new List<OrderVM>();
                var orders = orderService.AllOrderList();
                if (orders != null)
                {
                    var pass = from a in orders
                               group a by new { a.HiddenPKId } into b
                               orderby b.Key.HiddenPKId
                               let c = (from d in b
                                        select new
                                        {
                                            orderId = d.OrderId,
                                            customerId = d.CustomerId,
                                            hiddenPKId = b.Key.HiddenPKId,
                                            customerName = d.Customer.CustomerName,
                                            district = d.Customer.District,
                                            subdistrict = d.Customer.SubDistrict,
                                            roadNo = d.Customer.RoadNo,
                                            houseNo = d.Customer.HouseNo,
                                            area = d.Customer.Area,
                                            contact = d.Customer.ContactNo,
                                            shippingId = d.ShippingId,
                                            shipping = d.Shipping.ShippingMethod,
                                            payementId = d.PaymentId,
                                            payement = d.Payment.PaymentMethod,
                                            productId = d.ProductInventoryId,
                                            product = d.ProductInventory.Name,
                                            quantity = d.Quantity,
                                            totalPrice = d.ProductInventory.SellPrice,
                                            deliveryStatus = d.Status,
                                            cancelStatus = d.CancelStatus,
                                            orderPlacedDate = d.OrderDate,
                                        })
                               select c;
                    ProductInventory_VM productInventory_VM = new ProductInventory_VM();
                    List<ProductInventoryVM> productInventoryVMs = new List<ProductInventoryVM>();
                    foreach (var item in pass)
                    {
                        var orderVM = new OrderVM();
                        foreach (var i in item)
                        {
                            ProductInventoryVM productInventoryVM = new ProductInventoryVM();
                            productInventoryVM.NameVM = i.product;
                            productInventoryVM.QuantityVM = i.quantity;
                            productInventoryVM.EachPriceVM = i.totalPrice * i.quantity;
                            orderVM.TotalPriceVM += productInventoryVM.EachPriceVM;
                            orderVM.SerialNo = sl;
                            orderVM.OrderVMId = i.orderId;
                            orderVM.CustomerVMId = i.customerId;
                            orderVM.HiddenPKVMId = i.hiddenPKId;
                            orderVM.CustomerVMName = i.customerName;
                            orderVM.CustomerVMArea = i.area;
                            orderVM.CustomerVMDistrict = i.district;
                            orderVM.CustomerVMSubDistrict = i.subdistrict;
                            orderVM.CustomerVMHouseNo = i.houseNo;
                            orderVM.CustomerVMRoadNo = i.roadNo;
                            orderVM.CustomerVMContactNo = i.contact;
                            orderVM.ShippingVMId = i.shippingId;
                            orderVM.ShippingVMMethod = i.shipping;
                            orderVM.PaymentVMId = i.payementId;
                            orderVM.PaymentVMMethod = i.payement;
                            orderVM.ProductVMId = i.productId;
                            if (orderService.GetCancelStatusOrderInfobyOrderId(i.hiddenPKId) != null)
                            {
                                orderVM.StringStatusVM = "Cancelled";
                            }
                            else if (deliveryService.GetReturnRefundListbyHiddenId(i.hiddenPKId).Count != 0)
                            {
                                if (deliveryService.TobeReturned(i.orderId) != null)
                                {
                                    productInventoryVM.StringStatusVM = "To-be Returned";
                                }
                                else if (deliveryService.TobeRefunded(i.orderId) != null)
                                {
                                    productInventoryVM.StringStatusVM = "To-be Refunded";
                                }
                                else if (deliveryService.TobeReturnedandRefunded(i.orderId) != null)
                                {
                                    productInventoryVM.StringStatusVM = "To-be Returned & Refunded";
                                }
                                else if (deliveryService.Returned(i.orderId) != null)
                                {
                                    productInventoryVM.StringStatusVM = "Returned";
                                }
                                else if (deliveryService.Refunded(i.orderId) != null)
                                {
                                    productInventoryVM.StringStatusVM = "Refunded";
                                }
                                else if (deliveryService.ReturnedandRefunded(i.orderId) != null)
                                {
                                    productInventoryVM.StringStatusVM = "Returned & Refunded";
                                }
                                else
                                {
                                    productInventoryVM.StringStatusVM = "Delivered";
                                }
                            }
                            else if (orderService.GetDeliveryInfobyOrderId(i.orderId) != null)
                            {
                                if (orderService.GetTrueStatusDeliveryInfobyOrderId(i.orderId) != null)
                                {
                                    orderVM.StringStatusVM = "Delivered";
                                }
                                else if (orderService.GetFalseStatusDeliveryInfobyOrderId(i.orderId) != null)
                                {
                                    orderVM.StringStatusVM = "To-be delivered";
                                }
                                else
                                {
                                    orderVM.StringStatusVM = "Pending";
                                }
                            }
                            else
                            {
                                orderVM.StringStatusVM = "Pending";
                            }
                            orderVM.OrderVMDate = i.orderPlacedDate;
                            orderVM.productInventory_VM.productInventoryVMs.Add(productInventoryVM);
                        }
                        orderVMs.Add(orderVM);
                        sl++;
                    }
                }
                return View(orderVMs.ToPagedList(pageNumber, pageSize));
            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult AllOrderIndividualInfo(int id)
        {
            List<DeliveryVM> deliveryVMs = new List<DeliveryVM>();
            var detailsfromDelivery = deliveryService.AllOrderListforIndividualInfofromDelivery(id);
            var detailsfromOrder = orderService.AllOrderListforIndividualInfofromOrder(id);
            if (detailsfromDelivery.Count != 0)
            {
                var pass1 = from a in detailsfromDelivery
                            group a by a.Order.CustomerId into b
                            let c = (from d in b
                                     select new
                                     {
                                         orderId = d.OrderId,
                                         deliveryId = d.DeliveryId,
                                         hiddenPkId = d.Order.HiddenPKId,
                                         customerId = b.Key,
                                         customerName = d.Order.Customer.CustomerName,
                                         district = d.Order.Customer.District,
                                         subdistrict = d.Order.Customer.SubDistrict,
                                         area = d.Order.Customer.Area,
                                         roadNo = d.Order.Customer.RoadNo,
                                         houseNo = d.Order.Customer.HouseNo,
                                         contact = d.Order.Customer.ContactNo,
                                         shippingId = d.Order.ShippingId,
                                         shipping = d.Order.Shipping.ShippingMethod,
                                         payementId = d.Order.PaymentId,
                                         payement = d.Order.Payment.PaymentMethod,
                                         productId = d.Order.ProductInventoryId,
                                         product = d.Order.ProductInventory.Name,
                                         quantity = d.Order.Quantity,
                                         totalPrice = d.Order.ProductInventory.SellPrice,
                                         status = d.Status,
                                         orderPlacedDate = d.Order.OrderDate,
                                         orderDeliveredDate = d.DeliveredDate,
                                         complaintDescription = d.ComplaintDescription
                                     })
                            select c;
                ProductInventory_VM productInventory_VM = new ProductInventory_VM();
                List<ProductInventoryVM> productInventoryVMs = new List<ProductInventoryVM>();
                foreach (var item in pass1)
                {
                    var deliveryVM = new DeliveryVM();
                    foreach (var i in item)
                    {
                        ProductInventoryVM productInventoryVM = new ProductInventoryVM();
                        productInventoryVM.NameVM = i.product;
                        productInventoryVM.QuantityVM = i.quantity;
                        productInventoryVM.EachPriceVM = i.totalPrice * i.quantity;
                        deliveryVM.TotalPriceVM += productInventoryVM.EachPriceVM;
                        productInventoryVM.StatusVM = i.status;
                        deliveryVM.OrderVMId = i.orderId;
                        deliveryVM.HiddenPKVMId = i.hiddenPkId;
                        deliveryVM.CustomerVMId = i.customerId;
                        deliveryVM.CustomerVMName = i.customerName;
                        deliveryVM.CustomerVMArea = i.area;
                        deliveryVM.CustomerVMDistrict = i.district;
                        deliveryVM.CustomerVMSubDistrict = i.subdistrict;
                        deliveryVM.CustomerVMHouseNo = i.houseNo;
                        deliveryVM.CustomerVMRoadNo = i.roadNo;
                        deliveryVM.CustomerVMContactNo = i.contact;
                        deliveryVM.ShippingVMId = i.shippingId;
                        deliveryVM.ShippingVMMethod = i.shipping;
                        deliveryVM.PaymentVMId = i.payementId;
                        deliveryVM.PaymentVMMethod = i.payement;
                        deliveryVM.ProductVMId = i.productId;
                        deliveryVM.OrderPlacedVMDate = i.orderPlacedDate;
                        deliveryVM.DeliveredVMDate = i.orderDeliveredDate;
                        deliveryVM.productInventory_VM.productInventoryVMs.Add(productInventoryVM);
                    }
                    deliveryVMs.Add(deliveryVM);
                }
            }
            else if (detailsfromOrder.Count != 0)
            {
                var pass2 = from a in detailsfromOrder
                            group a by a.CustomerId into b
                            let c = (from d in b
                                     select new
                                     {
                                         orderId = d.OrderId,
                                         // deliveryId = d.DeliveryId,
                                         hiddenPkId = d.HiddenPKId,
                                         customerId = b.Key,
                                         customerName = d.Customer.CustomerName,
                                         district = d.Customer.District,
                                         subdistrict = d.Customer.SubDistrict,
                                         area = d.Customer.Area,
                                         roadNo = d.Customer.RoadNo,
                                         houseNo = d.Customer.HouseNo,
                                         contact = d.Customer.ContactNo,
                                         shippingId = d.ShippingId,
                                         shipping = d.Shipping.ShippingMethod,
                                         payementId = d.PaymentId,
                                         payement = d.Payment.PaymentMethod,
                                         productId = d.ProductInventoryId,
                                         product = d.ProductInventory.Name,
                                         quantity = d.Quantity,
                                         totalPrice = d.ProductInventory.SellPrice,
                                         status = d.Status,
                                         orderPlacedDate = d.OrderDate,
                                         //orderDeliveredDate = default(DateTime ?),
                                     })
                            select c;
                ProductInventory_VM productInventory_VM = new ProductInventory_VM();
                List<ProductInventoryVM> productInventoryVMs = new List<ProductInventoryVM>();
                foreach (var item in pass2)
                {
                    var deliveryVM = new DeliveryVM();
                    foreach (var i in item)
                    {
                        ProductInventoryVM productInventoryVM = new ProductInventoryVM();
                        //DateTime date1 = new DateTime(1855, 1, 1, 0, 0, 0, 0);
                        productInventoryVM.NameVM = i.product;
                        productInventoryVM.QuantityVM = i.quantity;
                        productInventoryVM.EachPriceVM = i.totalPrice * i.quantity;
                        deliveryVM.TotalPriceVM += productInventoryVM.EachPriceVM;
                        productInventoryVM.StatusVM = i.status;
                        deliveryVM.OrderVMId = i.orderId;
                        deliveryVM.HiddenPKVMId = i.hiddenPkId;
                        deliveryVM.CustomerVMId = i.customerId;
                        deliveryVM.CustomerVMName = i.customerName;
                        deliveryVM.CustomerVMArea = i.area;
                        deliveryVM.CustomerVMDistrict = i.district;
                        deliveryVM.CustomerVMSubDistrict = i.subdistrict;
                        deliveryVM.CustomerVMHouseNo = i.houseNo;
                        deliveryVM.CustomerVMRoadNo = i.roadNo;
                        deliveryVM.CustomerVMContactNo = i.contact;
                        deliveryVM.ShippingVMId = i.shippingId;
                        deliveryVM.ShippingVMMethod = i.shipping;
                        deliveryVM.PaymentVMId = i.payementId;
                        deliveryVM.PaymentVMMethod = i.payement;
                        deliveryVM.ProductVMId = i.productId;
                        deliveryVM.OrderPlacedVMDate = i.orderPlacedDate;
                        deliveryVM.DeliveredVMDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
                        deliveryVM.productInventory_VM.productInventoryVMs.Add(productInventoryVM);
                    }
                    deliveryVMs.Add(deliveryVM);
                }
            }
            return View(deliveryVMs);
        }
        public IActionResult ViewOrderReceipt(int id)
        {
            List<OrderVM> orderVMs = new List<OrderVM>();
            var detailsfromOrder = orderService.AllOrderListforIndividualInfofromOrder(id);
            if (detailsfromOrder.Count != 0)
            {
                var pass = from a in detailsfromOrder
                           group a by a.CustomerId into b
                           let c = (from d in b
                                    select new
                                    {
                                        orderId = d.OrderId,
                                        hiddenPkId = d.HiddenPKId,
                                        customerId = b.Key,
                                        customerName = d.Customer.CustomerName,
                                        district = d.Customer.District,
                                        subdistrict = d.Customer.SubDistrict,
                                        area = d.Customer.Area,
                                        roadNo = d.Customer.RoadNo,
                                        houseNo = d.Customer.HouseNo,
                                        contact = d.Customer.ContactNo,
                                        shippingId = d.ShippingId,
                                        shipping = d.Shipping.ShippingMethod,
                                        payementId = d.PaymentId,
                                        payement = d.Payment.PaymentMethod,
                                        productId = d.ProductInventoryId,
                                        product = d.ProductInventory.Name,
                                        quantity = d.Quantity,
                                        totalPrice = d.ProductInventory.SellPrice,
                                        brand = d.ProductInventory.Brand.BrandName,
                                        category = d.ProductInventory.ProductCategory.ProductCategoryTitle,
                                        color = d.ProductInventory.Color,
                                        size = d.ProductInventory.Size,
                                        material = d.ProductInventory.Material,
                                        status = d.Status,
                                        orderPlacedDate = d.OrderDate,
                                        productUnitCost = d.ProductInventory.SellPrice,
                                    })
                           select c;
                ProductInventory_VM productInventory_VM = new ProductInventory_VM();
                List<ProductInventoryVM> productInventoryVMs = new List<ProductInventoryVM>();
                foreach (var item in pass)
                {
                    var orderVM = new OrderVM();
                    foreach (var i in item)
                    {
                        ProductInventoryVM productInventoryVM = new ProductInventoryVM();
                        productInventoryVM.NameVM = i.product;
                        productInventoryVM.ProductVMUnitCost = i.productUnitCost;
                        productInventoryVM.BrandNameVM = i.brand;
                        productInventoryVM.ProductCategoryTitleVM = i.category;
                        productInventoryVM.ColorVM = i.color;
                        productInventoryVM.SizeVM = i.size;
                        productInventoryVM.MaterialVM = i.material;
                        productInventoryVM.QuantityVM = i.quantity;
                        productInventoryVM.EachPriceVM = i.totalPrice * i.quantity;
                        orderVM.TotalPriceVM += productInventoryVM.EachPriceVM;
                        productInventoryVM.StatusVM = i.status;
                        orderVM.OrderVMId = i.orderId;
                        orderVM.HiddenPKVMId = i.hiddenPkId;
                        orderVM.CustomerVMId = i.customerId;
                        orderVM.CustomerVMName = i.customerName;
                        orderVM.CustomerVMArea = i.area;
                        orderVM.CustomerVMDistrict = i.district;
                        orderVM.CustomerVMSubDistrict = i.subdistrict;
                        orderVM.CustomerVMHouseNo = i.houseNo;
                        orderVM.CustomerVMRoadNo = i.roadNo;
                        orderVM.CustomerVMContactNo = i.contact;
                        orderVM.ShippingVMId = i.shippingId;
                        orderVM.ShippingVMMethod = i.shipping;
                        orderVM.PaymentVMId = i.payementId;
                        orderVM.PaymentVMMethod = i.payement;
                        orderVM.ProductVMId = i.productId;
                        orderVM.OrderVMDate = i.orderPlacedDate;
                        orderVM.productInventory_VM.productInventoryVMs.Add(productInventoryVM);
                    }
                    orderVMs.Add(orderVM);
                }
            }
            return View(orderVMs);
        }
    }
}
