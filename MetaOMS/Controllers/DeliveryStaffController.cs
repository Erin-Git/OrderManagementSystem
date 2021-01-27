using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Services.Interfaces;
using MetaOMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace MetaOMS.Controllers
{
    public class DeliveryStaffController : Controller
    {
        
        private readonly IDeliveryService deliveryService;
        private readonly IProductInventoryService productInventoryService;

        private readonly IOrderService orderService;
        public DeliveryStaffController(IDeliveryService _deliveryService, IOrderService _orderService,
            IProductInventoryService _productInventoryService)
        {
            deliveryService = _deliveryService;
            productInventoryService = _productInventoryService;
            orderService = _orderService;
        }
        public IActionResult Index()
        {
            var pendingDeliveries = deliveryService.PendingDeliveryList().GroupBy(q => q.Order.HiddenPKId);
            var successfulDeliveries = deliveryService.CountDeliveries().GroupBy(q => q.Order.HiddenPKId);
            var pendingReturnRefunds = orderService.PendingReturnRefundList().GroupBy(q => q.Order.HiddenPKId);
            var cancelledOrders = deliveryService.CountCancelledfromDeliverables().GroupBy(q => q.Order.HiddenPKId);
            DeliveryVM deliveryVM = new DeliveryVM()
            {
                TotalPendingDeliveryVMCount = pendingDeliveries.Count(),
                TotalDeliveryVMCount = successfulDeliveries.Count(),
                TotalPendingReturnRefundVMCount=pendingReturnRefunds.Count(),
                TotalCancelledOrderVMCount= cancelledOrders.Count()
            };
            return View(deliveryVM);
        }
        public IActionResult DeliverableOrder(int id)
        {
            List<Order> orders = deliveryService.GetListofCustomersforOrderDeliver(id);
            if (orders.Count != 0)
            {
                List<Delivery> deliveries = deliveryService.GetListofCustomerstoCheckIfExists(id);
                List<Delivery> deliveries1 = deliveryService.GetListofExistingCustomerstoCheckIfExists(id);
                if (deliveries.Count == 0)
                {
                    for (int i = 0; i < orders.Count; i++)
                    {
                        deliveryService.AddDeliverableOrder(new Delivery()
                        {
                            OrderId = orders[i].OrderId,
                            Status = false,
                            DeliveredDate = DateTime.Now,
                            //will be changed at the end, user auth
                            DeliveryStaffId = 1
                        });
                    }
                    return Json(new { sms = "Saved" });
                }
                else if (deliveries1.Count!=0)
                {
                    for (int i = 0; i < orders.Count; i++)
                    {
                        deliveryService.AddDeliverableOrder(new Delivery()
                        {
                            OrderId = orders[i].OrderId,
                            Status = false,
                            DeliveredDate = DateTime.Now,
                            //will be changed at the end, user auth
                            DeliveryStaffId = 1
                        });
                    }
                    return Json(new { sms = "Saved" });
                }
                else
                {
                    deliveryService.DeleteDeliverableOrderbyId(id);
                    return Json(new { sms = "Deleted" });
                }
            }
            else
                return RedirectToAction("CustomerList", "Admin");
        }
        public IActionResult DeliveredOrderList(int? Page) //delivered order list
        {
            var pageNumber = Page ?? 1;
            int pageSize = 5;
            int sl = 1;
            List<DeliveryVM> deliveryVMs = new List<DeliveryVM>();
            var orders = orderService.DeliveredOrderList();
            if (orders != null)
            {
                var pass = from a in orders
                           group a by new { a.Order.HiddenPKId } into b
                           orderby b.Key.HiddenPKId
                           let c = (from d in b
                                    select new
                                    {
                                        orderId = d.OrderId,
                                        hiddenPKId = b.Key.HiddenPKId,
                                        customerId = d.Order.CustomerId,
                                        customerName = d.Order.Customer.CustomerName,
                                        area = d.Order.Customer.Area,
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
                                    })
                           select c;
                ProductInventory_VM productInventory_VM = new ProductInventory_VM();
                List<ProductInventoryVM> productInventoryVMs = new List<ProductInventoryVM>();
                foreach (var item in pass)
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
                        deliveryVM.SerialNo = sl;
                        deliveryVM.OrderVMId = i.orderId;
                        deliveryVM.CustomerVMId = i.customerId;
                        deliveryVM.CustomerVMName = i.customerName;
                        deliveryVM.CustomerVMArea = i.area;
                        deliveryVM.CustomerVMContactNo = i.contact;
                        deliveryVM.ShippingVMId = i.shippingId;
                        deliveryVM.ShippingVMMethod = i.shipping;
                        deliveryVM.PaymentVMId = i.payementId;
                        deliveryVM.PaymentVMMethod = i.payement;
                        deliveryVM.ProductVMId = i.productId;
                        if (orderService.GetDeliveryInfobyOrderId(i.orderId) != null)
                        {
                            if (orderService.GetTrueStatusDeliveryInfobyOrderId(i.orderId) != null)
                            {
                                deliveryVM.StatusVM = true;
                                deliveryVM.StringStatusVM = "Delivered";
                            }
                            //else if (orderService.GetFalseStatusDeliveryInfobyOrderId(i.orderId) != null)
                            //{
                            //    deliveryVM.StatusVM = true;
                            //    deliveryVM.StringStatusVM = "To-be delivered";
                            //}
                            //else
                            //{
                            //    deliveryVM.StatusVM = false;
                            //    deliveryVM.StringStatusVM = "Pending";
                            //}
                        }
                        //else
                        //{
                        //    deliveryVM.StatusVM = false;
                        //    deliveryVM.StringStatusVM = "Pending";
                        //}
                        deliveryVM.OrderPlacedVMDate = i.orderPlacedDate;
                        deliveryVM.DeliveredVMDate = i.orderDeliveredDate;
                        deliveryVM.productInventory_VM.productInventoryVMs.Add(productInventoryVM);
                    }
                    deliveryVMs.Add(deliveryVM);
                    sl++;
                }
            }
            return View(deliveryVMs.ToPagedList(pageNumber, pageSize));
        }
        //public IActionResult DeliverableOrderList(int? Page)
        //{
        //    var pageNumber = Page ?? 1;
        //    int pageSize = 5;
        //    int sl = 1;
        //    List<DeliveryVM> deliverieVMs = new List<DeliveryVM>();
        //    var deliverableOrders = deliveryService.DeliveryList();
        //    if (deliverableOrders!=null)
        //    {
        //        var pass = from a in deliverableOrders
        //                   group a by a.Order.CustomerId into b
        //                   let c = (from d in b
        //                            select new
        //                            {
        //                                orderId=d.OrderId,
        //                                deliveryId=d.DeliveryId,
        //                                customerId=b.Key,
        //                                customerName=d.Order.Customer.CustomerName,
        //                                area = d.Order.Customer.Area,
        //                                contact = d.Order.Customer.ContactNo,
        //                                shippingId = d.Order.ShippingId,
        //                                shipping = d.Order.Shipping.ShippingMethod,
        //                                payementId = d.Order.PaymentId,
        //                                payement = d.Order.Payment.PaymentMethod,
        //                                productId = d.Order.ProductInventoryId,
        //                                product = d.Order.ProductInventory.Name,
        //                                quantity = d.Order.Quantity,
        //                                totalPrice = d.Order.ProductInventory.SellPrice,
        //                                status = d.Status,
        //                                orderPlacedDate = d.Order.OrderDate,
        //                                deliveredDate=d.DeliveredDate
        //                            })
        //                   select c;
        //        ProductInventory_VM productInventory_VM = new ProductInventory_VM();
        //        List<ProductInventoryVM> productInventoryVMs = new List<ProductInventoryVM>();
        //        foreach (var item in pass)
        //        {
        //            var deliveryVM = new DeliveryVM();

        //            foreach (var i in item)
        //            {
        //                ProductInventoryVM productInventoryVM = new ProductInventoryVM();
        //                productInventoryVM.NameVM = i.product;
        //                productInventoryVM.QuantityVM = i.quantity;
        //                productInventoryVM.EachPriceVM = i.totalPrice * i.quantity;
        //                deliveryVM.TotalPriceVM += productInventoryVM.EachPriceVM;
        //                productInventoryVM.StatusVM = i.status;
        //                deliveryVM.SerialNo = sl;
        //                deliveryVM.OrderVMId = i.orderId;
        //                deliveryVM.CustomerVMId = i.customerId;
        //                deliveryVM.CustomerVMName = i.customerName;
        //                deliveryVM.CustomerVMArea = i.area;
        //                deliveryVM.CustomerVMContactNo = i.contact;
        //                deliveryVM.ShippingVMId = i.shippingId;
        //                deliveryVM.ShippingVMMethod = i.shipping;
        //                deliveryVM.PaymentVMId = i.payementId;
        //                deliveryVM.PaymentVMMethod = i.payement;
        //                deliveryVM.ProductVMId = i.productId;
        //                if (deliveryService.GetDeliveryInfobyOrderId(i.orderId) != null)
        //                {
        //                    if (deliveryService.GetTrueStatusDeliveryInfobyOrderId(i.orderId) != null)
        //                    {
        //                        deliveryVM.StatusVM = true;
        //                        deliveryVM.StringStatusVM = "Delivered";
        //                    }
        //                    else
        //                    {
        //                        deliveryVM.StatusVM = false;
        //                        deliveryVM.StringStatusVM = "Pending";
        //                    }
        //                }
        //                else
        //                {
        //                    deliveryVM.StatusVM = false;
        //                    deliveryVM.StringStatusVM = "Pending";
        //                }
        //                deliveryVM.DeliveredVMDate = i.deliveredDate;
        //                deliveryVM.OrderPlacedVMDate = i.orderPlacedDate;
        //                deliveryVM.productInventory_VM.productInventoryVMs.Add(productInventoryVM);
        //            }
        //            deliverieVMs.Add(deliveryVM);
        //            sl++;
        //        }
        //    }
        //    return View(deliverieVMs.ToPagedList(pageNumber, pageSize));
        //}
        public IActionResult PendingDeliveryList(int? Page)
        {
            var pageNumber = Page ?? 1;
            int pageSize = 5;
            int sl = 1;
            List<DeliveryVM> deliveryVMs = new List<DeliveryVM>();
            var deliverableOrders = deliveryService.PendingDeliveryList();
            if (deliverableOrders != null)
            {
                var pass = from a in deliverableOrders
                           //group a by new { a.Order.CustomerId, a.Status, a.Order.OrderDate } into b
                           group a by new { a.Order.CustomerId, a.Status, a.Order.HiddenPKId } into b
                           orderby b.Key.CustomerId
                           let c = (from d in b
                                    select new
                                    {
                                        orderId = d.OrderId,
                                        deliveryId = d.DeliveryId,
                                        customerId = b.Key.CustomerId,
                                        //edited newly
                                        hiddenPkId=b.Key.HiddenPKId,
                                        customerName = d.Order.Customer.CustomerName,
                                        area = d.Order.Customer.Area,
                                        district = d.Order.Customer.District,
                                        subDistrict = d.Order.Customer.SubDistrict,
                                        houseNo = d.Order.Customer.HouseNo,
                                        roadNo = d.Order.Customer.RoadNo,
                                        contact = d.Order.Customer.ContactNo,
                                        shippingId = d.Order.ShippingId,
                                        shipping = d.Order.Shipping.ShippingMethod,
                                        payementId = d.Order.PaymentId,
                                        payement = d.Order.Payment.PaymentMethod,
                                        productId = d.Order.ProductInventoryId,
                                        product = d.Order.ProductInventory.Name,
                                        quantity = d.Order.Quantity,
                                        totalPrice = d.Order.ProductInventory.SellPrice,
                                        status = b.Key.Status,
                                        //orderPlacedDate = b.Key.OrderDate,
                                        orderPlacedDate = d.Order.OrderDate,
                                        deliveredDate = d.DeliveredDate
                                    })
                           select c;
                ProductInventory_VM productInventory_VM = new ProductInventory_VM();
                List<ProductInventoryVM> productInventoryVMs = new List<ProductInventoryVM>();
                foreach (var item in pass)
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
                        deliveryVM.SerialNo = sl;
                        deliveryVM.OrderVMId = i.orderId;
                        deliveryVM.CustomerVMId = i.customerId;
                        //edited newly
                        deliveryVM.HiddenPKVMId = i.hiddenPkId;
                        deliveryVM.CustomerVMName = i.customerName;
                        deliveryVM.CustomerVMArea = i.area;
                        deliveryVM.CustomerVMDistrict = i.district;
                        deliveryVM.CustomerVMSubDistrict = i.subDistrict;
                        deliveryVM.CustomerVMHouseNo = i.houseNo;
                        deliveryVM.CustomerVMRoadNo = i.roadNo;
                        deliveryVM.CustomerVMContactNo = i.contact;
                        deliveryVM.ShippingVMId = i.shippingId;
                        deliveryVM.ShippingVMMethod = i.shipping;
                        deliveryVM.PaymentVMId = i.payementId;
                        deliveryVM.PaymentVMMethod = i.payement;
                        deliveryVM.ProductVMId = i.productId;
                        if (deliveryService.GetDeliveryInfobyOrderId(i.orderId) != null)
                        {
                            if (deliveryService.GetTrueStatusDeliveryInfobyOrderId(i.orderId) != null)
                            {
                                deliveryVM.StatusVM = true;
                                deliveryVM.StringStatusVM = "Delivered";
                            }
                            else
                            {
                                deliveryVM.StatusVM = false;
                                deliveryVM.StringStatusVM = "Pending";
                            }
                        }
                        else
                        {
                            deliveryVM.StatusVM = false;
                            deliveryVM.StringStatusVM = "Pending";
                        }
                        deliveryVM.DeliveredVMDate = i.deliveredDate;
                        deliveryVM.OrderPlacedVMDate = i.orderPlacedDate;
                        deliveryVM.productInventory_VM.productInventoryVMs.Add(productInventoryVM);
                    }
                    deliveryVMs.Add(deliveryVM);
                    sl++;
                }
            }
            return View(deliveryVMs.ToPagedList(pageNumber, pageSize));
        }
        public IActionResult OrderIndividualInfo(int id)
        {
            List<DeliveryVM> deliveryVMs = new List<DeliveryVM>();
            var deliveries = deliveryService.GetListofCustomerbyIdIndividual(id);
            if (deliveries.Count != 0)
            {
                var pass = from a in deliveries
                           group a by a.Order.CustomerId into b
                           let c = (from d in b
                                    select new
                                    {
                                        orderId = d.OrderId,
                                        deliveryId = d.DeliveryId,
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
                                        orderPlacedDate = d.Order.OrderDate
                                    })
                           select c;
                ProductInventory_VM productInventory_VM = new ProductInventory_VM();
                List<ProductInventoryVM> productInventoryVMs = new List<ProductInventoryVM>();
                foreach (var item in pass)
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
                        deliveryVM.productInventory_VM.productInventoryVMs.Add(productInventoryVM);
                    }
                    deliveryVMs.Add(deliveryVM);
                }
            }
            return View(deliveryVMs);
        }

        public IActionResult PendingReturnRefundList(int? Page)
        {
            var pageNumber = Page ?? 1;
            int pageSize = 5;
            int sl = 1;
            List<DeliveryVM> deliveryVMs = new List<DeliveryVM>();
            var orders = orderService.PendingReturnRefundList();
            if (orders != null)
            {
                var pass = from a in orders
                           group a by new { a.Order.HiddenPKId } into b
                           orderby b.Key.HiddenPKId
                           let c = (from d in b
                                    select new
                                    {
                                        orderId = d.OrderId,
                                        hiddenPKId = b.Key.HiddenPKId,
                                        customerId = d.Order.CustomerId,
                                        customerName = d.Order.Customer.CustomerName,
                                        district=d.Order.Customer.District,
                                        subDistrict=d.Order.Customer.SubDistrict,
                                        area = d.Order.Customer.Area,
                                        houseNo=d.Order.Customer.HouseNo,
                                        roadNo=d.Order.Customer.RoadNo,
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
                                    })
                           select c;
                ProductInventory_VM productInventory_VM = new ProductInventory_VM();
                List<ProductInventoryVM> productInventoryVMs = new List<ProductInventoryVM>();
                foreach (var item in pass)
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
                        deliveryVM.SerialNo = sl;
                        deliveryVM.OrderVMId = i.orderId;
                        deliveryVM.HiddenPKVMId = i.hiddenPKId;
                        deliveryVM.CustomerVMId = i.customerId;
                        deliveryVM.CustomerVMName = i.customerName;
                        deliveryVM.CustomerVMDistrict = i.district;
                        deliveryVM.CustomerVMSubDistrict = i.subDistrict;
                        deliveryVM.CustomerVMArea = i.area;
                        deliveryVM.CustomerVMHouseNo = i.houseNo;
                        deliveryVM.CustomerVMRoadNo = i.roadNo;
                        deliveryVM.CustomerVMContactNo = i.contact;
                        deliveryVM.ShippingVMId = i.shippingId;
                        deliveryVM.ShippingVMMethod = i.shipping;
                        deliveryVM.PaymentVMId = i.payementId;
                        deliveryVM.PaymentVMMethod = i.payement;
                        deliveryVM.ProductVMId = i.productId;
                        if (deliveryService.DoneReturnedandRefunded(i.hiddenPKId) != null)
                        {
                            deliveryVM.StringReturnedRefundedVMStatus = "Done";
                        }
                        else if (deliveryService.PendingReturnedandRefunded(i.hiddenPKId) != null)
                        {
                            deliveryVM.StringReturnedRefundedVMStatus = "Pending";
                        }
                        deliveryVM.OrderPlacedVMDate = i.orderPlacedDate;
                        deliveryVM.DeliveredVMDate = i.orderDeliveredDate;
                        if (deliveryService.GetReturnRefundListbyHiddenId(i.hiddenPKId).Count != 0)
                        {
                            if (deliveryService.TobeReturned(i.orderId) != null)
                            {
                                productInventoryVM.StringStatusVM = "Return";
                            }
                            else if (deliveryService.TobeRefunded(i.orderId) != null)
                            {
                                productInventoryVM.StringStatusVM = "Refund";
                            }
                            else if (deliveryService.TobeReturnedandRefunded(i.orderId) != null)
                            {
                                productInventoryVM.StringStatusVM = "Return & Refund";
                            }
                            //else
                            //{
                            //    productInventoryVM.StringStatusVM = "Delivered";
                            //}
                        }
                        deliveryVM.productInventory_VM.productInventoryVMs.Add(productInventoryVM);
                    }
                    deliveryVMs.Add(deliveryVM);
                    sl++;
                }
            }
            return View(deliveryVMs.ToPagedList(pageNumber, pageSize));

        }

        public IActionResult ConfirmReturnRefund(int id)
        {
            List<Delivery> tobereturnrefunds = deliveryService.GetTobeReturnedRefundedListbyHiddenIdtoConfirm(id);
            if (tobereturnrefunds.Count != 0)
            {
                for (int i = 0; i < tobereturnrefunds.Count; i++)
                {
                    tobereturnrefunds[i].ReturnedRefundedStatus = true;
                    deliveryService.UpdateReturnedRefundedStatusofDelivery(tobereturnrefunds[i]);                    
                }
                //for product quantity increase after return done by delivery staff
                var returnedOrders = deliveryService.GetReturnedDeliveryListbyHiddenIdforProductQuantityUpdate(id);
                if (returnedOrders.Count != 0)
                {
                    for (int j = 0; j < returnedOrders.Count; j++)
                    {
                        var products = productInventoryService
                            .GetProductListtoMatchtheProductInventoryId(returnedOrders[j].Order.ProductInventoryId);
                        if (products.Count != 0)
                        {
                            for (int k = 0; k < products.Count; k++)
                            {
                                products[k].AvailableQuantity += returnedOrders[j].Order.Quantity;
                                productInventoryService.UpdateProduct(products[k]);
                            }
                        }
                    }
                }
                return Json(new { sms = "Saved" });
            }
            else if (tobereturnrefunds.Count == 0)
            {
                List<Delivery> returnrefunds = deliveryService.GetReturnedRefundedListbyHiddenIdtoConfirm(id);
                if (returnrefunds.Count != 0)
                {
                    for (int i = 0; i < returnrefunds.Count; i++)
                    {
                        returnrefunds[i].ReturnedRefundedStatus = false;
                        deliveryService.UpdateReturnedRefundedStatusofDelivery(returnrefunds[i]);                       
                    }
                    //for product quantity decrease after a done return made pending by delivery staff
                    var returnedOrders = deliveryService.GetReturnedDeliveryListbyHiddenIdforProductQuantityUpdate(id);
                    if (returnedOrders.Count != 0)
                    {
                        for (int j = 0; j < returnedOrders.Count; j++)
                        {
                            var products = productInventoryService
                                .GetProductListtoMatchtheProductInventoryId(returnedOrders[j].Order.ProductInventoryId);
                            if (products.Count != 0)
                            {
                                for (int k = 0; k < products.Count; k++)
                                {
                                    products[k].AvailableQuantity -= returnedOrders[j].Order.Quantity;
                                    productInventoryService.UpdateProduct(products[k]);
                                }
                            }
                        }
                    }
                }
                return Json(new { sms = "Deleted" });
            }
            else
               return RedirectToAction("CustomerList", "Admin");
        }
        public IActionResult PendingReturnRefundIndividualInfo(int id)
        {
            List<DeliveryVM> deliveryVMs = new List<DeliveryVM>();
            var details = deliveryService.GetInfobyHiddenIdforReturnRefundIndividualInfo(id);
            if (details.Count != 0)
            {
                var pass = from a in details
                           group a by a.Order.CustomerId into b
                           let c = (from d in b
                                    select new
                                    {
                                        orderId = d.OrderId,
                                        deliveryId = d.DeliveryId,
                                        hiddenPkId=d.Order.HiddenPKId,
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
                foreach (var item in pass)
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
                        if (deliveryService.GetReturnRefundListbyHiddenId(i.hiddenPkId).Count != 0)
                        {
                            if (deliveryService.TobeReturned(i.orderId) != null || deliveryService.Returned(i.orderId) != null)
                            {
                                productInventoryVM.StringStatusVM = "Return";
                            }
                            else if (deliveryService.TobeRefunded(i.orderId) != null || deliveryService.Refunded(i.orderId) != null)
                            {
                                productInventoryVM.StringStatusVM = "Refund";
                            }
                            else if (deliveryService.TobeReturnedandRefunded(i.orderId) != null || deliveryService.ReturnedandRefunded(i.orderId) != null)
                            {
                                productInventoryVM.StringStatusVM = "Return & Refund";
                            }
                        }
                        deliveryVM.OrderPlacedVMDate = i.orderPlacedDate;
                        deliveryVM.DeliveredVMDate = i.orderDeliveredDate;
                        if (deliveryService.GetReturnRefundListbyHiddenId(i.hiddenPkId).Count != 0)
                        {
                            if (deliveryService.ReturnRefundwithComplaintDescription(i.orderId) != null)
                            {
                                productInventoryVM.ComplaintDescriptionVM = i.complaintDescription;
                            }
                        }
                        deliveryVM.productInventory_VM.productInventoryVMs.Add(productInventoryVM);
                    }
                    deliveryVMs.Add(deliveryVM);
                }
            }
            return View(deliveryVMs);
        }
    }
    }

