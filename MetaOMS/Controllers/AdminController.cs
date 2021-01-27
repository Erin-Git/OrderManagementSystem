using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Services.Interfaces;
using MetaOMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using X.PagedList;

namespace MetaOMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBrandService brandService;
        private readonly IDeliveryService deliveryService;
        private readonly IDeliveryStaffService deliveryStaffService;
        private readonly IStaffService staffService;
        private readonly IShippingService shippingService;
        private readonly IPaymentService paymentService;
        private readonly IProductCategoryService productCategoryService;
        private readonly IProductInventoryService productInventoryService;
        private readonly ICustomerService customerService;
        private readonly IOrderService orderService;
        private readonly IUserService userService;
        public AdminController(IBrandService _brandService, IShippingService _shippingService,
            IPaymentService _paymentService, IProductCategoryService _productCategoryService,
            IProductInventoryService _productInventoryService, ICustomerService _customerService,
            IOrderService _orderService, IDeliveryStaffService _deliveryStaffService,
            IStaffService _staffService, IDeliveryService _deliveryService, IUserService _userService)
        {
            brandService = _brandService;
            deliveryService = _deliveryService;
            deliveryStaffService = _deliveryStaffService;
            staffService = _staffService;
            shippingService = _shippingService;
            paymentService = _paymentService;
            productCategoryService = _productCategoryService;
            productInventoryService = _productInventoryService;
            customerService = _customerService;
            orderService = _orderService;
            userService = _userService;
        }
        public IActionResult Index()
        {
            var totalOrders = orderService.CountOrders().GroupBy(q=>q.HiddenPKId);
            var successfulDeliveries = deliveryService.CountDeliveries().GroupBy(q=>q.Order.HiddenPKId);
           // var happyCustomers = customerService.CustomerList().GroupBy(q=>q.CustomerId);
            var products = productInventoryService.ProductList().Sum(q => q.AvailableQuantity);
            var profit = deliveryService.DeliveredOrderforProfit().Sum(q=>
                            (q.Order.ProductInventory.SellPrice - q.Order.ProductInventory.PurchasePrice) * q.Order.Quantity);
          
            DeliveryVM deliveryVM = new DeliveryVM()
            {
                TotalOrderVMCount = totalOrders.Count(),
                TotalDeliveryVMCount = successfulDeliveries.Count(),
                //TotalCustomerVMCount = happyCustomers.Count(),
                TotalAvaiableProductVMCount = products,
                ProfitVM=profit/100
            };
            return View(deliveryVM);
        }
        public JsonResult GetDataforProductChart()
        {
            //var query = deliveryService.DeliveredProductListforChart()
            //          .GroupBy(q => q.Order.ProductInventory.Name)
            //          .Select(q => new { name = q.Key, count = q.Sum(t => t.Order.Quantity) }).ToList();
            var query = productInventoryService.ProductList().GroupBy(q=>q.Name)
                        .Select(q=> new { name = q.Key, available = q.Sum(t => t.AvailableQuantity), 
                            sold = q.Sum(t => t.StockInQuantity-t.AvailableQuantity) }).ToList();
            return Json(query);
        }
        //public JsonResult GetDataforStatusChart()
        //{
        //    var query = deliveryService.DeliveriesforChart()

                          // .GroupBy(q => q.Order.HiddenPKId)
                           //.GroupBy(q => q.Status)

                           //.Select(q => new
                           //{

                           //    name = q.Key,

                           //    delivered = q.Where(t => t.Status == true && t.ReturnRefundStatus == false && t.ReturnedRefundedStatus == false).Count(),

                           //    cancelled = q.Where(t => t.Order.CancelStatus == true).Count(),

                           //    returnedrefunded = q.Where(t => t.ReturnRefundStatus == true && t.ReturnedRefundedStatus == true).Count()

            //               }).ToList();

            //return Json(query);


            //int CountOnlyDeliveredforChart = deliveryService.CountDeliveries()
            // //.GroupBy(q => q.Order.HiddenPKId)
            // // .Select(q => new { name = "Delivered" })
            //                    .Count();

            //int CountOnlyCancelledforChart = orderService.CancelledOrdersforChart()
            // //.GroupBy(q=>q.HiddenPKId)
            // //.Select(q => new { name = "Cancelled" })
            //                     .Count();

            //int CountOnlyReturnedRefundedforChart = deliveryService.ReturnedRefundedListforChart()
            // //.GroupBy(q => q.Order.HiddenPKId)
            // //.Select(q => new { name = "Returned/Refunded" })
            //                     .Count();
            ////List<DeliveryVM> deliveryVMs = new List<DeliveryVM>();
            //DeliveryVM deliveryVM = new DeliveryVM();
            //deliveryVM.CountOnlyDeliveredforChart = CountOnlyDeliveredforChart;
            //deliveryVM.CountOnlyCancelledforChart = CountOnlyCancelledforChart;
            //deliveryVM.CountOnlyReturnedRefundedforChart = CountOnlyReturnedRefundedforChart;
            ////deliveryVMs.Add(deliveryVM);
            //return Json(deliveryVM);

      //  }
        public IActionResult BrandList(int Page=1)
        {
            return View(ConvertListofBrandVMmodeltoModelType(Page));
        }
        [HttpGet]
        public IActionResult AddorUpdateBrand(int id = 0)
        {
            if (id == 0)
            {
                return View(new BrandVM());
            }
            else
            {
                return View(GetVMTypeBrand(id));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorUpdateBrandAsync(int id, BrandVM brandVM)
        {
            if (ModelState.IsValid)
            {
                Brand brand = new Brand();

                if (id == 0)
                {
                    brand.BrandName = brandVM.BrandVMName;
                    brandService.AddorUpdateBrand(brand);
                }
                else
                {
                    brand.BrandId = brandVM.BrandVMId;
                    brand.BrandName = brandVM.BrandVMName;
                    brandService.AddorUpdateBrand(brand);
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "BrandList", ConvertListofBrandVMmodeltoModelType(brandVM.CurrentPage)) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorUpdateBrand", brandVM) });
        }
        public IActionResult DeleteBrand(int id,int Page)
        {
            brandService.DeleteBrandById(id);
            return Json(new { data = true, html = Helper.RenderRazorViewToString(this, "BrandList", ConvertListofBrandVMmodeltoModelType(Page)) });
        }
        public BrandVM GetVMTypeBrand(int id)
        {
            var brand = brandService.GetBrandByID(id);
            BrandVM brandVM = new BrandVM();
            brandVM.BrandVMId = id;
            brandVM.BrandVMName = brand.BrandName;
            return brandVM;
        }
        private IPagedList<BrandVM> ConvertListofBrandVMmodeltoModelType(int Page)
        {
            int count = 1;
            List<BrandVM> brandVMs = new List<BrandVM>();
            foreach (var item in brandService.BrandList())
            {
                BrandVM brandVM = new BrandVM()
                {
                    SerialNo = count,
                    BrandVMId = item.BrandId,
                    BrandVMName = item.BrandName
                };
                count++;
                brandVMs.Add(brandVM);
            }
            return brandVMs.ToPagedList(Page,5);
        }


        public IActionResult StaffList(int Page = 1)
        {
            return View(ConvertVMtypetoListVMtypeStaff(Page));
        }
        private IPagedList<StaffVM> ConvertVMtypetoListVMtypeStaff(int Page)
        {
            int count = 1;
            List<StaffVM> staffVMs = new List<StaffVM>();
            foreach (var item in staffService.StaffList())
            {
                StaffVM staffVM = new StaffVM()
                {
                    SerialNo = count,
                    StaffVMId = item.StaffId,
                    StaffVMName = item.StaffName,
                    ContactVMNo = item.ContactNo,
                    EmailVMAddress = item.EmailAddress,
                };
                count++;
                staffVMs.Add(staffVM);
            }
            return staffVMs.ToPagedList(Page, 5);
        }
        public StaffVM GetVMTypeStaff(int id)
        {
            var staff = staffService.GetStaffbyId(id);
            StaffVM staffVM = new StaffVM();
            staffVM.StaffVMId = id;
            staffVM.StaffVMName = staff.StaffName;
            staffVM.ContactVMNo = staff.ContactNo;
            staffVM.EmailVMAddress = staff.EmailAddress;
            staffVM.UserVMId = staff.UserId;
            return staffVM;
        }
        public IActionResult AddorUpdateStaff(int id = 0)
        {
            if (id == 0)
            {
                return View(new StaffVM());
            }
            else
            {
                return View(GetVMTypeStaff(id));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorUpdateStaffAsync(int id, StaffVM staffVM)
        {
            if (ModelState.IsValid)
            {
                Staff staff = new Staff();
                User user = new User();
                if (id == 0)
                {
                    //new edit for user
                    user.UserName = staffVM.EmailVMAddress;
                    user.Password = staffVM.StaffVMName + (Convert.ToInt64(staffVM.ContactVMNo) % 1000);
                    user.UserRoleId = 3;
                    userService.AddorUpdateUser(user);

                    staff.StaffName = staffVM.StaffVMName;
                    staff.ContactNo = staffVM.ContactVMNo;
                    staff.EmailAddress = staffVM.EmailVMAddress; 
                    staff.UserId = user.UserId;
                    staffService.AddorUpdateStaff(staff);
                }
                else
                {
                    staff.StaffId = staffVM.StaffVMId;
                    staff.StaffName = staffVM.StaffVMName;
                    staff.ContactNo = staffVM.ContactVMNo;
                    staff.EmailAddress = staffVM.EmailVMAddress;
                    staff.UserId = staffVM.UserVMId;
                    staffService.AddorUpdateStaff(staff);

                    //new edit for user
                    user.UserId = staffVM.UserVMId;
                    user.UserName = staffVM.EmailVMAddress;
                    user.Password = staffVM.StaffVMName + (Convert.ToInt64(staffVM.ContactVMNo) % 1000);
                    user.UserRoleId = 3;
                    userService.AddorUpdateUser(user);
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "StaffList", ConvertVMtypetoListVMtypeStaff(staffVM.CurrentPage)) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorUpdateStaff", staffVM) });
        }
        public IActionResult DeliveryStaffList(int Page = 1)
        {
            return View(ConvertVMtypetoListVMtypeDeliveryStaff(Page));
        }
        public DeliveryStaffVM GetVMTypeDeliveryStaff(int id)
        {
            var deliveryStaff = deliveryStaffService.GetDeliveryStaffbyId(id);
            DeliveryStaffVM deliveryStaffVM = new DeliveryStaffVM();
            deliveryStaffVM.DeliveryStaffVMId = id;
            deliveryStaffVM.DeliveryStaffVMName = deliveryStaff.DeliveryStaffName;
            deliveryStaffVM.ContactVMNo = deliveryStaff.ContactNo;
            deliveryStaffVM.EmailVMAddress = deliveryStaff.EmailAddress;
            deliveryStaffVM.UserVMId = deliveryStaff.UserId;
            return deliveryStaffVM;
        }
        private IPagedList<DeliveryStaffVM> ConvertVMtypetoListVMtypeDeliveryStaff(int Page)
        {
            int count = 1;
            List<DeliveryStaffVM> deliveryStaffVMs = new List<DeliveryStaffVM>();
            foreach (var item in deliveryStaffService.DeliveryStaffList())
            {
                DeliveryStaffVM deliveryStaffVM = new DeliveryStaffVM()
                {
                    SerialNo = count,
                    DeliveryStaffVMId = item.DeliveryStaffId,
                    DeliveryStaffVMName = item.DeliveryStaffName,
                    ContactVMNo = item.ContactNo,
                    EmailVMAddress = item.EmailAddress,
                };
                count++;
                deliveryStaffVMs.Add(deliveryStaffVM);
            }
            return deliveryStaffVMs.ToPagedList(Page, 5);
        }
        [HttpGet]
        public IActionResult AddorUpdateDeliveryStaff(int id = 0)
        {
            if (id == 0)
            {
                return View(new DeliveryStaffVM());
            }
            else
            {
                return View(GetVMTypeDeliveryStaff(id));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorUpdateDeliveryStaffAsync(int id, DeliveryStaffVM deliveryStaffVM)
        {
            if (ModelState.IsValid)
            {
                DeliveryStaff deliveryStaff = new DeliveryStaff();
                User user = new User();
                if (id == 0)
                {
                    //new edit for user
                    user.UserName = deliveryStaffVM.EmailVMAddress;
                    user.Password = deliveryStaffVM.DeliveryStaffVMName + (Convert.ToInt64(deliveryStaffVM.ContactVMNo) % 1000);
                    user.UserRoleId = 4;
                    userService.AddorUpdateUser(user);

                    deliveryStaff.DeliveryStaffName = deliveryStaffVM.DeliveryStaffVMName;
                    deliveryStaff.ContactNo = deliveryStaffVM.ContactVMNo;
                    deliveryStaff.EmailAddress = deliveryStaffVM.EmailVMAddress;
                    deliveryStaff.UserId = user.UserId;
                    deliveryStaffService.AddorUpdateDeliveryStaff(deliveryStaff);
                }
                else
                {
                    deliveryStaff.DeliveryStaffId = deliveryStaffVM.DeliveryStaffVMId;
                    deliveryStaff.DeliveryStaffName = deliveryStaffVM.DeliveryStaffVMName;
                    deliveryStaff.ContactNo = deliveryStaffVM.ContactVMNo;
                    deliveryStaff.EmailAddress = deliveryStaffVM.EmailVMAddress;
                    deliveryStaff.UserId = deliveryStaffVM.UserVMId;
                    deliveryStaffService.AddorUpdateDeliveryStaff(deliveryStaff);

                    //new edit for user
                    user.UserId = deliveryStaffVM.UserVMId;
                    user.UserName = deliveryStaffVM.EmailVMAddress;
                    user.Password = deliveryStaffVM.DeliveryStaffVMName + (Convert.ToInt64(deliveryStaffVM.ContactVMNo) % 1000);
                    user.UserRoleId = 4;
                    userService.AddorUpdateUser(user);
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "DeliveryStaffList", ConvertVMtypetoListVMtypeDeliveryStaff(deliveryStaffVM.CurrentPage))});
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorUpdateDeliveryStaff", deliveryStaffVM) });
        }
        public IActionResult DeleteDeliveryStaff(int id, int Page)
        {
            deliveryStaffService.DeleteDeliveryStaffById(id);
            return Json(new { data = true, html = Helper.RenderRazorViewToString(this, "DeliveryStaffList", ConvertVMtypetoListVMtypeDeliveryStaff(Page)) });
        }
        public IActionResult ShippingMethodList(int Page=1)
        {
             return View(ConvertListofShippingMethodVMtoModelType(Page));
        }
        [HttpGet]
        public IActionResult AddorUpdateShippingMethod(int id = 0)
        {
            if (id == 0)
            {
                return View(new ShippingVM());
            }
            else
            {
                return View(GetVMTypeShippingMethod(id));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorUpdateShippingMethodAsync(int id, ShippingVM shippingVM)
        {
            if (ModelState.IsValid)
            {
                Shipping shipping = new Shipping();

                if (id == 0)
                {
                    shipping.ShippingMethod = shippingVM.ShippingVMMethod;
                    shippingService.AddorUpdateShippingMethod(shipping);
                }
                else
                {
                    shipping.ShippingId = shippingVM.ShippingVMId;
                    shipping.ShippingMethod = shippingVM.ShippingVMMethod;
                    shippingService.AddorUpdateShippingMethod(shipping);
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ShippingMethodList", ConvertListofShippingMethodVMtoModelType(shippingVM.CurrentPage)) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorUpdateShippingMethod", shippingVM) });
        }
        public IActionResult DeleteShippingMethod(int id,int Page)
        {
            shippingService.DeleteShippingMethodById(id);
            return Json(new { data = true, html = Helper.RenderRazorViewToString(this, "ShippingMethodList", ConvertListofShippingMethodVMtoModelType(Page)) });
        }
        public ShippingVM GetVMTypeShippingMethod(int id)
        {
            var shipping = shippingService.GetShippingMethodById(id);
            ShippingVM shippingVM = new ShippingVM();
            shippingVM.ShippingVMId = id;
            shippingVM.ShippingVMMethod = shipping.ShippingMethod;
            return shippingVM;
        }
        private IPagedList<ShippingVM> ConvertListofShippingMethodVMtoModelType(int Page)
        {
            int count = 1;
            List<ShippingVM> shippingVMs = new List<ShippingVM>();
            foreach (var item in shippingService.ShippingMethodList())
            {
                ShippingVM shippingVM = new ShippingVM()
                {
                    SerialNo = count,
                    ShippingVMId = item.ShippingId,
                    ShippingVMMethod = item.ShippingMethod
                };
                count++;
                shippingVMs.Add(shippingVM);
            }
            return shippingVMs.ToPagedList(Page,5);
        }
        public IActionResult PaymentMethodList(int Page=1)
        {
            return View(ConvertListofPaymentMethodVMtoModelType(Page));
        }
        [HttpGet]
        public IActionResult AddorUpdatePaymentMethod(int id = 0)
        {
            if (id == 0)
            {
                return View(new PaymentVM());
            }
            else
            {
                return View(GetVMTypePaymentMethod(id));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorUpdatePaymentMethodAsync(int id, PaymentVM paymentVM)
        {
            if (ModelState.IsValid)
            {
                Payment payment = new Payment();

                if (id == 0)
                {
                    payment.PaymentMethod = paymentVM.PaymentVMMethod;
                    paymentService.AddorUpdatePaymentMethod(payment);
                }
                else
                {
                    payment.PaymentId = paymentVM.PaymentVMId;
                    payment.PaymentMethod = paymentVM.PaymentVMMethod;
                    paymentService.AddorUpdatePaymentMethod(payment);
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "PaymentMethodList", ConvertListofPaymentMethodVMtoModelType(paymentVM.CurrentPage)) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorUpdateShippingMethod", paymentVM) });
        }
        public IActionResult DeletePaymentMethod(int id,int Page)
        {
            paymentService.DeletePaymentMethodById(id);
            return Json(new { data = true, html = Helper.RenderRazorViewToString(this, "PaymentMethodList", ConvertListofPaymentMethodVMtoModelType(Page)) });
        }
        public PaymentVM GetVMTypePaymentMethod(int id)
        {
            var payment = paymentService.GetPaymentMethodById(id);
            PaymentVM paymentVM = new PaymentVM();
            paymentVM.PaymentVMId = id;
            paymentVM.PaymentVMMethod = payment.PaymentMethod;
            return paymentVM;
        }
        private IPagedList<PaymentVM> ConvertListofPaymentMethodVMtoModelType(int Page)
        {
            int count = 1;
            List<PaymentVM> paymentVMs = new List<PaymentVM>();
            foreach (var item in paymentService.PaymentMethodList())
            {
                PaymentVM paymentVM = new PaymentVM()
                {
                    SerialNo = count,
                    PaymentVMId = item.PaymentId,
                    PaymentVMMethod = item.PaymentMethod
                };
                count++;
                paymentVMs.Add(paymentVM);
            }
            return paymentVMs.ToPagedList(Page,5);
        }
        public IActionResult ProductCategoryList(int Page=1)
        {
            return View(ConvertListofProductCategoryVMtoModelType(Page));
        }
        [HttpGet]
        public IActionResult AddorUpdateProductCategory(int id = 0)
        {
            if (id == 0)
            {
                return View(new ProductCategoryVM());
            }
            else
            {
                return View(GetVMTypeProductCategory(id));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorUpdateProductCategoryAsync(int id, ProductCategoryVM productCategoryVM)
        {
            if (ModelState.IsValid)
            {
                ProductCategory productCategory = new ProductCategory();

                if (id == 0)
                {
                    productCategory.ProductCategoryTitle = productCategoryVM.ProductCategoryVMTitle;
                    productCategoryService.AddorUpdateProductCategory(productCategory);
                }
                else
                {
                    productCategory.ProductCategoryId = productCategoryVM.ProductCategoryVMId;
                    productCategory.ProductCategoryTitle = productCategoryVM.ProductCategoryVMTitle;
                    productCategoryService.AddorUpdateProductCategory(productCategory);
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ProductCategoryList", ConvertListofProductCategoryVMtoModelType(productCategoryVM.CurrentPage)) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorUpdateProductCategory", productCategoryVM) });
        }
        public IActionResult DeleteProductCategory(int id,int Page)
        {
            productCategoryService.DeleteProductCategoryById(id);
            return Json(new { data = true, html = Helper.RenderRazorViewToString(this, "ProductCategoryList", ConvertListofProductCategoryVMtoModelType(Page)) });
        }
        public ProductCategoryVM GetVMTypeProductCategory(int id)
        {
            var productCategory = productCategoryService.GetProductCategoryById(id);
            ProductCategoryVM productCategoryVM = new ProductCategoryVM();
            productCategoryVM.ProductCategoryVMId = id;
            productCategoryVM.ProductCategoryVMTitle = productCategory.ProductCategoryTitle;
            return productCategoryVM;
        }
        private IPagedList<ProductCategoryVM> ConvertListofProductCategoryVMtoModelType(int Page)
        {
            int count = 1;
            List<ProductCategoryVM> productCategoryVMs = new List<ProductCategoryVM>();
            foreach (var item in productCategoryService.ProductCategoryList())
            {
                ProductCategoryVM productCategoryVM = new ProductCategoryVM()
                {
                    SerialNo = count,
                    ProductCategoryVMId = item.ProductCategoryId,
                    ProductCategoryVMTitle = item.ProductCategoryTitle
                };
                count++;
                productCategoryVMs.Add(productCategoryVM);
            }
            return productCategoryVMs.ToPagedList(Page,5);
        }
        public IActionResult ProductList(int? Page)
        {
            var pageNumber = Page ?? 1;
            int pageSize = 5;
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
            return View(productInventoryVMs.ToPagedList(pageNumber,pageSize));
        }
        public IActionResult ProductListforReport()
        {           
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
                    productInventoryVM.StockInDateVM = item.StockInDate;
                    productInventoryVM.SellPriceVM = item.SellPrice;
                    productInventoryVM.StockInDateVM = item.StockInDate;
                    productInventoryVM.BrandNameVM = item.Brand.BrandName;
                    productInventoryVM.BrandVMId = item.Brand.BrandId;
                    productInventoryVM.ProductCategoryTitleVM = item.ProductCategory.ProductCategoryTitle;
                    productInventoryVM.ProductCategoryIdVM = item.ProductCategory.ProductCategoryId;
                }
                sl++;
                productInventoryVMs.Add(productInventoryVM);
            }
            return View(productInventoryVMs);
        }
        public IActionResult ProductIndividualInfo(int id)
        {
            var product = productInventoryService.GetProductById(id);
            ProductInventoryVM productInventoryVM = new ProductInventoryVM();
            productInventoryVM.ProductVMId = product.ProductInventoryId;
            productInventoryVM.NameVM = product.Name;
            productInventoryVM.ProductCategoryIdVM = product.ProductCategoryId;
            productInventoryVM.ProductCategoryTitleVM = product.ProductCategory.ProductCategoryTitle;
            productInventoryVM.BrandVMId = product.BrandId;
            productInventoryVM.BrandNameVM = product.Brand.BrandName;
            productInventoryVM.ColorVM = product.Color;
            productInventoryVM.SizeVM = product.Size;
            productInventoryVM.MaterialVM = product.Material;
            productInventoryVM.DescriptionVM = product.Description;
            productInventoryVM.PurchasePriceVM = product.PurchasePrice;
            productInventoryVM.SellPriceVM = product.SellPrice;
            productInventoryVM.StockInQuantityVM = product.StockInQuantity;
            //will change this after order
            productInventoryVM.AvailableQuantityVM = product.AvailableQuantity;
            productInventoryVM.StockInDateVM = product.StockInDate;
            return View(productInventoryVM);
        }
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct(ProductInventory_VM productInventoryVM)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < productInventoryVM.productInventoryVMs.Count; i++)
                {
                    ProductInventory productInventory = new ProductInventory();
                    productInventory.Name = productInventoryVM.productInventoryVMs[i].NameVM;
                    productInventory.ProductCategoryId = productInventoryVM.productInventoryVMs[i].ProductCategoryIdVM;
                    productInventory.BrandId = productInventoryVM.productInventoryVMs[i].BrandVMId;
                    productInventory.Color = productInventoryVM.productInventoryVMs[i].ColorVM;
                    productInventory.Size = productInventoryVM.productInventoryVMs[i].SizeVM;
                    productInventory.Material = productInventoryVM.productInventoryVMs[i].MaterialVM;
                    productInventory.Description = productInventoryVM.productInventoryVMs[i].DescriptionVM;
                    productInventory.PurchasePrice = productInventoryVM.productInventoryVMs[i].PurchasePriceVM;
                    productInventory.SellPrice = productInventoryVM.productInventoryVMs[i].SellPriceVM;
                    //productInventory.StockInQuantity = productInventoryVM.productInventoryVMs[i].StockInQuantityVM;
                    //will change after order
                    //productInventory.AvailableQuantity = productInventoryVM.productInventoryVMs[i].StockInQuantityVM;
                    //productInventory.StockInDate = DateTime.Now;
                    productInventoryService.AddNewProduct(productInventory);
                }
            }
            else
            {
                return View();
            }
            //return View();
            return RedirectToAction("ProductList","Admin");
        }
        
        //get product category list in dropdown
        public JsonResult GetProductCategories()
        {
            var productCategories = productCategoryService.ProductCategoryList();
            return Json(productCategories);
        }
        //get brand list in dropdown
        public JsonResult GetBrands()
        {
            var brands = brandService.BrandList();
            return Json(brands);
        }
        //get product color list in dropdown
        public JsonResult GetProductColors()
        {
            //List<ColorEnum> productColors = Enum.GetValues(typeof(ColorEnum)).Cast<ColorEnum>().ToList();
            var statuses = from ColorEnum s in Enum.GetValues(typeof(ColorEnum))
                           select new
                           {
                               Text = (int)Enum.Parse(typeof(ColorEnum), s.ToString()),
                               Value = s.ToString()
                           };
            var productColors = new SelectList(statuses, "Text", "Value");
            return Json(productColors);
        }
        //get product size list in dropdown
        public JsonResult GetProductSizes()
        {
            var ps = from SizeEnum se in Enum.GetValues(typeof(SizeEnum))
                     select new
                     {
                         Text = (int)Enum.Parse(typeof(SizeEnum), se.ToString()),
                         Value = se.ToString()
                     };
            var productSizes = new SelectList(ps, "Text", "Value");
            return Json(productSizes);
        }
        //get product material list in dropdown
        public JsonResult GetProductMaterials()
        {
            var pm = from MaterialEnum me in Enum.GetValues(typeof(MaterialEnum))
                     select new
                     {
                         Text = (int)Enum.Parse(typeof(MaterialEnum), me.ToString()),
                         Value = me.ToString()
                     };
            var productMaterials = new SelectList(pm, "Text", "Value");
            return Json(productMaterials);
        }
        public ProductInventoryVM GetVMTypeProduct(int id)
        {
            var product = productInventoryService.GetProductById(id);
            ProductInventoryVM productInventoryVM = new ProductInventoryVM();
            productInventoryVM.ProductVMId = id;
            productInventoryVM.NameVM = product.Name;
            productInventoryVM.ProductCategoryIdVM = product.ProductCategoryId;
            productInventoryVM.ProductCategoryTitleVM = product.ProductCategory.ProductCategoryTitle;
            productInventoryVM.BrandVMId = product.BrandId;
            productInventoryVM.BrandNameVM = product.Brand.BrandName;
            productInventoryVM.ColorVM = product.Color;
            productInventoryVM.SizeVM = product.Size;
            productInventoryVM.MaterialVM = product.Material;
            productInventoryVM.DescriptionVM = product.Description;
            productInventoryVM.PurchasePriceVM = product.PurchasePrice;
            productInventoryVM.SellPriceVM = product.SellPrice;
            productInventoryVM.StockInQuantityVM = product.StockInQuantity;
            productInventoryVM.StockInDateVM = product.StockInDate;
            productInventoryVM.AvailableQuantityVM = product.AvailableQuantity;
            return productInventoryVM;
        }
        public IActionResult UpdateProduct(int id)
        {
            ViewBag.ProductCategory = new SelectList( productCategoryService.ProductCategoryList(), "ProductCategoryId", "ProductCategoryTitle");
            ViewBag.ProductBrand = new SelectList( brandService.BrandList(), "BrandId", "BrandName");
            if (id != 0)
            {
                return View(GetVMTypeProduct(id));
            }
            return View();
        }
        [HttpPost]
        public IActionResult UpdateProduct(int id, ProductInventoryVM productInventoryVM)
        {
            //var products=productInventoryService.GetProductById(id);
            if (ModelState.IsValid)
            {
                ProductInventory productInventory = new ProductInventory();
                productInventory.ProductInventoryId = id;
                productInventory.Name = productInventoryVM.NameVM;
                productInventory.ProductCategoryId = productInventoryVM.ProductCategoryIdVM;
                productInventory.BrandId = productInventoryVM.BrandVMId;
                productInventory.Color = productInventoryVM.ColorVM;
                productInventory.Size = productInventoryVM.SizeVM;
                productInventory.Material = productInventoryVM.MaterialVM;
                productInventory.Description = productInventoryVM.DescriptionVM;
                productInventory.PurchasePrice = productInventoryVM.PurchasePriceVM;
                productInventory.SellPrice = productInventoryVM.SellPriceVM;
                productInventory.StockInQuantity = productInventoryVM.StockInQuantityVM;
                productInventory.AvailableQuantity = productInventoryVM.AvailableQuantityVM;
                productInventory.StockInDate = productInventoryVM.StockInDateVM;
                productInventoryService.UpdateProduct(productInventory);
                return RedirectToAction("ProductList");
            }
            else
            {
                return View();
            }           
        }
        public IActionResult StockInProduct(int id)
        {
            if (id != 0)
            {
                return View(GetVMTypeProductInventory(id));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StockInProductAsync(int id, ProductInventoryVM productInventoryVM)
        {
            if (ModelState.IsValid)
            {
                ProductInventory productInventory = new ProductInventory();
                if (id != 0)
                {
                    productInventory.ProductInventoryId = id;
                    productInventory.Name = productInventoryVM.NameVM;
                    productInventory.Color = productInventoryVM.ColorVM;
                    productInventory.Size = productInventoryVM.SizeVM;
                    productInventory.Material = productInventoryVM.MaterialVM;
                    productInventory.Description = productInventoryVM.DescriptionVM;
                    productInventory.BrandId = productInventoryVM.BrandVMId;
                    productInventory.ProductCategoryId = productInventoryVM.ProductCategoryIdVM;
                    productInventory.SellPrice = productInventoryVM.SellPriceVM;
                    productInventory.PurchasePrice = productInventoryVM.PurchasePriceVM;
                    productInventory.StockInQuantity = productInventoryVM.StockInQuantityVM;
                    productInventory.AvailableQuantity = productInventoryVM.StockInQuantityVM+ productInventoryVM.AvailableQuantityVM;
                    productInventory.StockInDate = DateTime.Now;
                    productInventoryService.UpdateProduct(productInventory);
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ProductList", ProductList(productInventoryVM.CurrentPage)) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "StockInProduct", productInventoryVM) });
        }
        public ProductInventoryVM GetVMTypeProductInventory(int id)
        {
            var product = productInventoryService.GetProductById(id);
            ProductInventoryVM ProductInventoryVM = new ProductInventoryVM();
            ProductInventoryVM.ProductVMId = id;
            ProductInventoryVM.NameVM = product.Name;
            ProductInventoryVM.ColorVM = product.Color;
            ProductInventoryVM.SizeVM = product.Size;
            ProductInventoryVM.MaterialVM = product.Material;
            ProductInventoryVM.DescriptionVM = product.Description;
            ProductInventoryVM.SellPriceVM = product.SellPrice;
            ProductInventoryVM.PurchasePriceVM = product.PurchasePrice;
            ProductInventoryVM.BrandVMId = product.BrandId;
            ProductInventoryVM.BrandNameVM = product.Brand.BrandName;
            ProductInventoryVM.ProductCategoryIdVM = product.ProductCategoryId;
            ProductInventoryVM.ProductCategoryTitleVM = product.ProductCategory.ProductCategoryTitle;
            ProductInventoryVM.StockInQuantityVM = product.StockInQuantity;
            ProductInventoryVM.AvailableQuantityVM = product.AvailableQuantity;
            ProductInventoryVM.StockInDateVM = product.StockInDate;
            return ProductInventoryVM;
        }
        public IActionResult CustomerList(int Page=1)
        {
            return View(GetListVMTypeCustomerList(Page));
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
            return customerVMs.ToPagedList(Page,10);
        }
        public IActionResult CustomerListReport()
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
            return View(customerVMs);
        }
        public IActionResult CustomerIndividualInfo(int id)
        {
            var customer = customerService.GetCustomerById(id);
            CustomerVM customerVM = new CustomerVM();
            customerVM.CustomerVMId = customer.CustomerId;
            customerVM.CustomerVMName = customer.CustomerName;
            customerVM.ContactNoVM = customer.ContactNo;
            customerVM.AreaVM = customer.Area;
            customerVM.DistrictVM = customer.District;
            customerVM.SubDistrictVM = customer.SubDistrict;
            customerVM.HouseNoVM = customer.HouseNo;
            customerVM.RoadNoVM = customer.RoadNo;
            customerVM.GoogleMapAddressVM = customer.GoogleMapAddress;
            return View(customerVM);
        }
        public CustomerVM GetVMTypeCustomer(int id)
        {
            var customer = customerService.GetCustomerById(id);
            CustomerVM customerVM = new CustomerVM();
            customerVM.CustomerVMId = customer.CustomerId;
            customerVM.CustomerVMName = customer.CustomerName;
            customerVM.ContactNoVM = customer.ContactNo;
            customerVM.AreaVM = customer.Area;
            customerVM.DistrictVM = customer.District;
            customerVM.SubDistrictVM = customer.SubDistrict;
            customerVM.HouseNoVM = customer.HouseNo;
            customerVM.RoadNoVM = customer.RoadNo;
            customerVM.GoogleMapAddressVM = customer.GoogleMapAddress;
            return customerVM;
        }
        [HttpGet]
        public IActionResult AddOrUpdateCustomer(int id=0)
        {
            if (id == 0)
            {
                return View(new CustomerVM());
            }
            else
            {
                return View(GetVMTypeCustomer(id));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdateCustomer(int id, CustomerVM customerVM)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer();
                if (id == 0)
                {
                    customer.CustomerName = customerVM.CustomerVMName;
                    customer.ContactNo = customerVM.ContactNoVM;
                    customer.District = customerVM.DistrictVM;
                    customer.SubDistrict = customerVM.SubDistrictVM;
                    customer.Area = customerVM.AreaVM;
                    customer.HouseNo = customerVM.HouseNoVM;
                    customer.RoadNo = customerVM.RoadNoVM;
                    customer.GoogleMapAddress = customerVM.GoogleMapAddressVM;
                    customerService.AddorUpdateCustomer(customer);
                }
                else
                {
                    customer.CustomerId = customerVM.CustomerVMId;
                    customer.CustomerName = customerVM.CustomerVMName;
                    customer.ContactNo = customerVM.ContactNoVM;
                    customer.District = customerVM.DistrictVM;
                    customer.SubDistrict = customerVM.SubDistrictVM;
                    customer.Area = customerVM.AreaVM;
                    customer.HouseNo = customerVM.HouseNoVM;
                    customer.RoadNo = customerVM.RoadNoVM;
                    customer.GoogleMapAddress = customerVM.GoogleMapAddressVM;
                    customerService.AddorUpdateCustomer(customer);
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "CustomerList", GetListVMTypeCustomerList(customerVM.CurrentPage)) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorUpdateCustomer", customerVM) });
        }
        private List<CustomerVM> ConvertVMTypeCustomertoListVMTypeCustomer()
        {
            int count = 1;
            List<CustomerVM> customerVMs = new List<CustomerVM>();
            foreach (var item in customerService.CustomerList())
            {
                CustomerVM customerVM = new CustomerVM()
                {
                    SerialNo = count,
                    CustomerVMId = item.CustomerId,
                    CustomerVMName = item.CustomerName,
                    ContactNoVM=item.ContactNo,
                    AreaVM=item.Area,
                    DistrictVM=item.District,
                    SubDistrictVM=item.SubDistrict,
                    HouseNoVM=item.HouseNo,
                    RoadNoVM=item.RoadNo,
                    GoogleMapAddressVM=item.GoogleMapAddress
                };
                count++;
                customerVMs.Add(customerVM);
            }
            return customerVMs;
        }
        public IActionResult PlaceNewOrder(int id)
        {
            var w = orderService.GetOrderbyId(id);
            if (w == null) //for new customer & exisiting customer whose product has been delivered
            {
                ViewBag.productSelectList = new SelectList(
                productInventoryService.ProductList(),
                "ProductInventoryId", "Name");
                ViewBag.Searched = false;
                ViewBag.shippingMethodSelectList = new SelectList(
                    shippingService.ShippingMethodList(),
                    "ShippingId", "ShippingMethod");
                ViewBag.Searched = false;
                ViewBag.paymentMethodSelectList = new SelectList(
                    paymentService.PaymentMethodList(),
                    "PaymentId", "PaymentMethod");
                ViewBag.Searched = false;
                var customerInfo = orderService.GetCustomerbyId(id);
                OrderVM orderVM = new OrderVM();
                orderVM.CustomerVMId = customerInfo.CustomerId;
                orderVM.CustomerVMName = customerInfo.CustomerName;
                orderVM.CustomerVMContactNo = customerInfo.ContactNo;
                orderVM.CustomerVMArea = customerInfo.Area;
                return View(orderVM);
            }
            else //for customers whose order is still pending/to-be delivered
                return RedirectToAction("PendingOrderList", "Admin"); //will go to update order
        }
       [HttpPost]
        public IActionResult PlaceNewOrder(OrderVM orderVM)
        {
            var orderdetails = HttpContext.Session.Get<List<OrderVM>>("CustomerOrderCache");

            if (orderdetails != null)
            {
                for (int i = 0; i < orderdetails.Count; i++)
                {
                    Order order = new Order()
                    {
                        //OrderId = item.OrderVMId,
                        OrderDate = DateTime.Now,
                        CustomerId = orderVM.CustomerVMId,
                        ShippingId = orderVM.ShippingVMId,
                        PaymentId = orderVM.PaymentVMId,
                        ProductInventoryId = orderdetails[i].ProductVMId,
                        Quantity = orderdetails[i].QuantityVM,
                        Status = false,
                        CancelStatus=false,
                        HiddenPKId=0
                    };
                    orderService.PlaceNewOrder(order);                    
                }
                var hidden = orderService.GetListtypeCustomerforUpdatingHiddenPKId(orderVM.CustomerVMId);
                if (hidden.Count != 0)
                {
                    for (int j = 0; j < hidden.Count; j++)
                    {
                        hidden[j].HiddenPKId = hidden[0].OrderId;
                        orderService.UpdateHiddenPKId(hidden[j]);
                    }
                }
                HttpContext.Session.Remove("CustomerOrderCache");
            }
            return RedirectToAction("CustomerList", "Admin");
        }
       
        //save info in browser's cache
        public IActionResult SetOrderedProduct(int productId)
        {
            var listOfOrderVm = HttpContext.Session.Get<List<OrderVM>>("CustomerOrderCache");
            if(listOfOrderVm==null)
            {
                listOfOrderVm = new List<OrderVM>();
                var productDetails = productInventoryService.GetProductById(productId);
                if (productDetails.AvailableQuantity >=1)
                {
                    OrderVM orderVM = new OrderVM();
                    orderVM.ProductVMId = productDetails.ProductInventoryId;
                    orderVM.ProductVMName = productDetails.Name;
                    orderVM.ProductVMColor = ((ColorEnum)Convert.ToInt32(productDetails.Color)).ToString();
                    orderVM.ProductVMSize = ((SizeEnum)Convert.ToInt32(productDetails.Size)).ToString();
                    orderVM.ProductVMMaterial = ((MaterialEnum)Convert.ToInt32(productDetails.Material)).ToString();
                    orderVM.ProductVMCategory = productDetails.ProductCategory.ProductCategoryTitle;
                    orderVM.ProductVMBrand = productDetails.Brand.BrandName;
                    orderVM.ProductVMEachPrice = productDetails.SellPrice;
                    orderVM.QuantityVM = 1;
                    listOfOrderVm.Add(orderVM);
                    var productDetailsUpdate = productInventoryService.GetProductById(productId);
                    productDetailsUpdate.AvailableQuantity -= 1;
                    productInventoryService.UpdateProduct(productDetailsUpdate);
                    
                    HttpContext.Session.Set("CustomerOrderCache", listOfOrderVm);
                    if (HttpContext.Session.Get<List<OrderVM>>("CustomerOrderCache").Count() > 0)
                    {
                        return Json(new { saveStatus = true, savedData = listOfOrderVm });
                    }
                    return Json(new { saveStatus = false });
                }
                return Json(new { saveStatus = false });
            }
            else
            {
                var existsAlready = listOfOrderVm.Where(s => s.ProductVMId == productId).FirstOrDefault();
                if(existsAlready!=null)
                {
                    var productDetails = productInventoryService.GetProductById(productId);
                    if (productDetails.AvailableQuantity >= 1)
                    {
                        listOfOrderVm.Remove(existsAlready);
                        existsAlready.QuantityVM += 1;
                        listOfOrderVm.Add(existsAlready);
                        var productDetailsUpdate = productInventoryService.GetProductById(productId);
                        productDetailsUpdate.AvailableQuantity -= 1;
                        productInventoryService.UpdateProduct(productDetailsUpdate);

                        HttpContext.Session.Set("CustomerOrderCache", listOfOrderVm);
                        if (HttpContext.Session.Get<List<OrderVM>>("CustomerOrderCache").Count() > 0)
                        {
                            return Json(new { saveStatus = true, savedData = listOfOrderVm });
                        }
                        return Json(new { saveStatus = false });
                    }
                    return Json(new { saveStatus = false });
                }
                else
                {
                    var productDetails = productInventoryService.GetProductById(productId);
                    if (productDetails.AvailableQuantity >= 1)
                    {
                        OrderVM orderVM = new OrderVM();
                        orderVM.ProductVMId = productDetails.ProductInventoryId;
                        orderVM.ProductVMName = productDetails.Name;
                        orderVM.ProductVMColor = ((ColorEnum)Convert.ToInt32(productDetails.Color)).ToString();
                        orderVM.ProductVMSize = ((SizeEnum)Convert.ToInt32(productDetails.Size)).ToString();
                        orderVM.ProductVMMaterial = ((MaterialEnum)Convert.ToInt32(productDetails.Material)).ToString();
                        orderVM.ProductVMCategory = productDetails.ProductCategory.ProductCategoryTitle;
                        orderVM.ProductVMBrand = productDetails.Brand.BrandName;
                        orderVM.ProductVMEachPrice = productDetails.SellPrice;
                        orderVM.QuantityVM = 1;
                        listOfOrderVm.Add(orderVM);
                        var productDetailsUpdate = productInventoryService.GetProductById(productId);
                        productDetailsUpdate.AvailableQuantity -= 1;
                        productInventoryService.UpdateProduct(productDetailsUpdate);

                        HttpContext.Session.Set("CustomerOrderCache", listOfOrderVm);
                        if (HttpContext.Session.Get<List<OrderVM>>("CustomerOrderCache").Count() > 0)
                        {
                            return Json(new { saveStatus = true, savedData = listOfOrderVm });
                        }
                        return Json(new { saveStatus = false });
                    }
                    return Json(new { saveStatus = false });
                }             
            }          
        }
        public IActionResult RemoveOrderedProduct(int productId)
        {
            var listOfOrderVm = HttpContext.Session.Get<List<OrderVM>>("CustomerOrderCache");
            var ordervm = listOfOrderVm.Where(s => s.ProductVMId == productId).FirstOrDefault();
            if (ordervm != null)
            {

                var productDetailsUpdate = productInventoryService.GetProductById(productId);
                productDetailsUpdate.AvailableQuantity +=1;
                productInventoryService.UpdateProduct(productDetailsUpdate);

               
                if (ordervm.QuantityVM == 1)
                {
                    listOfOrderVm.Remove(ordervm);
                }
                else
                {
                    listOfOrderVm.Remove(ordervm);
                    ordervm.QuantityVM -= 1;
                    listOfOrderVm.Add(ordervm);
                }
            }
           
            HttpContext.Session.Set("CustomerOrderCache", listOfOrderVm);
            return Json(new { saveStatus = true});
        }
        public IActionResult RemoveOrderedProductAll(int productId) 
        {
            var listOfOrderVm = HttpContext.Session.Get<List<OrderVM>>("CustomerOrderCache");
            var ordervm = listOfOrderVm.Where(s => s.ProductVMId == productId).FirstOrDefault();
            if (ordervm != null)
            {
                var productDetailsUpdate = productInventoryService.GetProductById(productId);
                productDetailsUpdate.AvailableQuantity += ordervm.QuantityVM;
                productInventoryService.UpdateProduct(productDetailsUpdate);

                listOfOrderVm.Remove(ordervm);
            }

            HttpContext.Session.Set("CustomerOrderCache", listOfOrderVm);
            return Json(new { saveStatus = true });
        }     
        public IActionResult ClearCacheStorage()
        {
            var listOfOrderVm = HttpContext.Session.Get<List<OrderVM>>("CustomerOrderCache");          
            if(listOfOrderVm!=null)
            {
                foreach (var item in listOfOrderVm)
                {
                    var productDetailsUpdate = productInventoryService.GetProductById(item.ProductVMId);
                    productDetailsUpdate.AvailableQuantity += item.QuantityVM;
                    productInventoryService.UpdateProduct(productDetailsUpdate);
                }
                HttpContext.Session.Remove("CustomerOrderCache");
            }          
            return Json(true);
        }
        public IActionResult SetPaymentMethod(int paymentMethodId)
        {
            //THis is for clearing previous PaymentMethod(all time history)
            HttpContext.Session.Remove("CustomerPaymentMethod");
            //This code is for newly set method
            HttpContext.Session.Set("CustomerPaymentMethod", paymentMethodId);

            return Json(true);
                        
        }
        public IActionResult SetShippingMethod(int shippingMethod) 
        {
            //THis is for clear to previous ShippingMethod(all TIme history)
            HttpContext.Session.Remove("CustomerShippingMethod");
            //This code is for newly setted method
            HttpContext.Session.Set("CustomerShippingMethod", shippingMethod);

            return Json(true);

        }
        //Get Summary
        public IActionResult GetOrderedItemSummary()
        {
            List<OrderVM> orderVMs = new List<OrderVM>();
            var listOfOrderVm = HttpContext.Session.Get<List<OrderVM>>("CustomerOrderCache");
            foreach (var item in listOfOrderVm)
            {
                OrderVM orderVM = new OrderVM()
                { 
                   ProductVMName=item.ProductVMName,
                   QuantityVM=item.QuantityVM,
                   ProductVMEachPrice=item.ProductVMEachPrice,
                   TotalPriceVM=item.ProductVMEachPrice*item.QuantityVM
                };
                orderVMs.Add(orderVM);
            }
            if(orderVMs.Count>0)
            {
                return Json(new { hasValue = true, savedValue = orderVMs });
            }
            return Json(new { hasValue = false });

        }
        //public IActionResult OrderList(int? Page)
        //{
        //    var pageNumber = Page ?? 1;
        //    int pageSize = 5;
        //    int sl = 1;
        //    List<OrderVM> orderVMs = new List<OrderVM>();
        //    var orders = orderService.OrderList();
        //    if (orders != null)
        //    {
        //        var pass = from a in orders
        //                   group a by a.CustomerId into b
        //                   let c = (from d in b
        //                            select new
        //                            {
        //                                orderId = d.OrderId,
        //                                customerId = b.Key,
        //                                customerName = d.Customer.CustomerName,
        //                                area = d.Customer.Area,
        //                                contact = d.Customer.ContactNo,
        //                                shippingId = d.ShippingId,
        //                                shipping = d.Shipping.ShippingMethod,
        //                                payementId = d.PaymentId,
        //                                payement = d.Payment.PaymentMethod,
        //                                productId = d.ProductInventoryId,
        //                                product = d.ProductInventory.Name,
        //                                quantity = d.Quantity,
        //                                totalPrice = d.ProductInventory.SellPrice,
        //                                status = d.Status,
        //                                orderPlacedDate = d.OrderDate
        //                            })
        //                   select c;
        //        ProductInventory_VM productInventory_VM = new ProductInventory_VM();
        //        List<ProductInventoryVM> productInventoryVMs = new List<ProductInventoryVM>();
        //        foreach (var item in pass)
        //        {
        //            var orderVM = new OrderVM();

        //            foreach (var i in item)
        //            {
        //                ProductInventoryVM productInventoryVM = new ProductInventoryVM();
        //                productInventoryVM.NameVM = i.product;
        //                productInventoryVM.QuantityVM = i.quantity;
        //                productInventoryVM.EachPriceVM = i.totalPrice * i.quantity;
        //                orderVM.TotalPriceVM += productInventoryVM.EachPriceVM;
        //                productInventoryVM.StatusVM = i.status;
        //                orderVM.SerialNo = sl;
        //                orderVM.OrderVMId = i.orderId;
        //                orderVM.CustomerVMId = i.customerId;
        //                orderVM.CustomerVMName = i.customerName;
        //                orderVM.CustomerVMArea = i.area;
        //                orderVM.CustomerVMContactNo = i.contact;
        //                orderVM.ShippingVMId = i.shippingId;
        //                orderVM.ShippingVMMethod = i.shipping;
        //                orderVM.PaymentVMId = i.payementId;
        //                orderVM.PaymentVMMethod = i.payement;
        //                orderVM.ProductVMId = i.productId;
        //                if (orderService.GetDeliveryInfobyOrderId(i.orderId) != null)
        //                {
        //                    if (orderService.GetTrueStatusDeliveryInfobyOrderId(i.orderId) != null)
        //                    {
        //                        orderVM.StatusVM = true;
        //                        orderVM.StringStatusVM = "Delivered";
        //                    }
        //                    else if (orderService.GetFalseStatusDeliveryInfobyOrderId(i.orderId) != null)
        //                    {
        //                        orderVM.StatusVM = true;
        //                        orderVM.StringStatusVM = "To-be delivered";
        //                    }
        //                    else
        //                    {
        //                        orderVM.StatusVM = false;
        //                        orderVM.StringStatusVM = "Pending";
        //                    }
        //                }
        //                else
        //                {
        //                    orderVM.StatusVM = false;
        //                    orderVM.StringStatusVM = "Pending";
        //                }
        //                orderVM.OrderVMDate = i.orderPlacedDate;
        //                orderVM.productInventory_VM.productInventoryVMs.Add(productInventoryVM);
        //            }
        //            orderVMs.Add(orderVM);
        //            sl++;
        //        }
        //    }
        //    return View(orderVMs.ToPagedList(pageNumber, pageSize));
        //}        
        public IActionResult PendingOrderList(int? Page) //pending order list
        {
            var pageNumber = Page ?? 1;
            int pageSize = 5;
            int sl = 1;
            List<OrderVM> orderVMs = new List<OrderVM>();
            var orders = orderService.PendingOrderList();
            if (orders != null)
            {
                var pass = from a in orders
                           //group a by new { a.CustomerId, a.Status,a.OrderDate } into b
                           group a by new { a.CustomerId, a.Status, a.HiddenPKId } into b
                           orderby b.Key.CustomerId
                           let c = (from d in b
                                    select new
                                    {
                                        orderId = d.OrderId,
                                        customerId = b.Key.CustomerId,
                                        hiddenPKId=b.Key.HiddenPKId,
                                        customerName = d.Customer.CustomerName,
                                        //customerName = b.Key.Customer.CustomerName,
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
                                        //status = d.Status,
                                        status = b.Key.Status,
                                        //orderPlacedDate = b.Key.OrderDate
                                        orderPlacedDate = d.OrderDate
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
                        productInventoryVM.StatusVM = i.status;
                        orderVM.SerialNo = sl;
                        orderVM.OrderVMId = i.orderId;
                        orderVM.CustomerVMId = i.customerId;
                        orderVM.HiddenPKVMId = i.hiddenPKId;
                        orderVM.CustomerVMName = i.customerName;
                        orderVM.CustomerVMArea = i.area;
                        orderVM.CustomerVMContactNo = i.contact;
                        orderVM.ShippingVMId = i.shippingId;
                        orderVM.ShippingVMMethod = i.shipping;
                        orderVM.PaymentVMId = i.payementId;
                        orderVM.PaymentVMMethod = i.payement;
                        orderVM.ProductVMId = i.productId;
                        if (orderService.GetCancelStatusOrderInfobyOrderId(i.hiddenPKId) != null)
                        {
                            orderVM.StatusVM = true;
                            orderVM.StringStatusVM = "Cancelled";
                        }
                        else if (orderService.GetDeliveryInfobyOrderId(i.orderId) != null)
                        {
                            //if (orderService.GetTrueStatusDeliveryInfobyOrderId(i.orderId) != null)
                            //{
                            //    orderVM.StatusVM = true;
                            //    orderVM.StringStatusVM = "Delivered";
                            //}
                            if(orderService.GetFalseStatusDeliveryInfobyOrderId(i.orderId) != null)
                            {
                                orderVM.StatusVM = true;
                                orderVM.StringStatusVM = "To-be delivered";
                            }
                            else
                            {
                                orderVM.StatusVM = false;
                                orderVM.StringStatusVM = "Pending";
                            }
                        }                    
                        else
                        {
                            orderVM.StatusVM = false;
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
       
        public OrderVM GetVMTypeOrder(int id)
        {
            var orderInfo = orderService.GetCustomerbyIdforFurtherOrderPurpose(id);
            List<OrderVM> orderVMs = new List<OrderVM>();
            int sl = 1;
            if (orderInfo.Count != 0)
            {
                for (int i = 0; i < orderInfo.Count; i++)
                {
                    OrderVM orderVM = new OrderVM()
                    {
                        SerialNo=sl,
                        OrderVMId = orderInfo[i].OrderId,
                        CustomerVMId = orderInfo[i].CustomerId,
                        CustomerVMName = orderInfo[i].Customer.CustomerName,
                        ShippingVMId = orderInfo[i].ShippingId,
                        ShippingVMMethod = orderInfo[i].Shipping.ShippingMethod,
                        PaymentVMId = orderInfo[i].PaymentId,
                        PaymentVMMethod = orderInfo[i].Payment.PaymentMethod,
                        ProductVMId = orderInfo[i].ProductInventoryId,
                        ProductVMName = orderInfo[i].ProductInventory.Name,
                        ProductVMColor = orderInfo[i].ProductInventory.Color,
                        ProductVMSize = orderInfo[i].ProductInventory.Size,
                        //ProductVMBrand=orderInfo.ProductInventory.Brand.BrandId,
                        ProductVMBrand = orderInfo[i].ProductInventory.Brand.BrandName,
                        ProductVMMaterial = orderInfo[i].ProductInventory.Material,
                        //ProductVMCategory=orderInfo.ProductInventory.ProductCategory.ProductCategoryTitle,
                        ProductVMCategory = orderInfo[i].ProductInventory.ProductCategory.ProductCategoryTitle,
                        QuantityVM = orderInfo[i].Quantity,
                        ProductVMEachPrice=orderInfo[i].ProductInventory.SellPrice,
                        TotalPriceVM= orderInfo[i].Quantity * orderInfo[i].ProductInventory.SellPrice,
                    };
                    sl++;
                    orderVMs.Add(orderVM);
                }
                foreach (var item in orderVMs)
                {
                    OrderVM orderVM = new OrderVM()
                    {
                        SerialNo=item.SerialNo,
                        OrderVMId=item.OrderVMId,
                        CustomerVMId=item.CustomerVMId,
                        CustomerVMName = item.CustomerVMName,
                        ShippingVMId = item.ShippingVMId,
                        ShippingVMMethod = item.ShippingVMMethod,
                        PaymentVMId = item.PaymentVMId,
                        PaymentVMMethod = item.PaymentVMMethod,
                        ProductVMId = item.ProductVMId,
                        ProductVMName = item.ProductVMName,
                        ProductVMColor = item.ProductVMColor,
                        ProductVMSize = item.ProductVMSize,
                        ProductVMBrand = item.ProductVMBrand,
                        ProductVMMaterial = item.ProductVMMaterial,
                        ProductVMCategory = item.ProductVMCategory,
                        QuantityVM = item.QuantityVM,
                        ProductVMEachPrice=item.ProductVMEachPrice,
                        TotalPriceVM=item.TotalPriceVM,
                        //TotalPriceVM += orderVM.ProductVMEachPrice
                    };
                    return orderVM;
                }
            }           
            return new OrderVM();
        }
        //public IActionResult DeliveredOrder(int id)
        //{
        //    List <Delivery> deliveries= orderService.GetListofCustomerstoMakeOrderDelivered(id);
        //    if (deliveries.Count != 0)
        //    {
        //        List<Order> orders = orderService.GetListofCustomerstoCheckIfExists(id);
        //        if (orders.Count != 0)
        //        {
        //            for (int i = 0; i < deliveries.Count; i++)

        //            {
        //                deliveries[i].Status = true;
        //                orders[i].Status = true;
        //                orderService.UpdateStausofDeliveryforDeliveredOrder(orders[i]);
        //                deliveryService.UpdateStausofDeliveryforDeliveredOrder(deliveries[i]);                        
        //            }
        //            return Json(new { sms = "Saved" });
        //        }
        //        else
        //        {
        //            for (int i = 0; i < deliveries.Count; i++)
        //            {
        //                deliveries[i].Status = false;
        //                orders[i].Status = false;
        //                orderService.UpdateStausofDeliveryforDeliveredOrder(orders[i]);
        //                deliveryService.UpdateStausofDeliveryforDeliveredOrder(deliveries[i]);
        //            }
        //            return Json(new { sms = "Deleted" });
        //        }
        //    }
        //    else
        //        return RedirectToAction("CustomerList", "Admin");
        //}
        public IActionResult DeliveredOrder(int id) //no view, only does CRUD
        {
            List<Order> orders = orderService.GetListofCustomerstoCheckIfExists(id);
            List<Order> ordersTrue = orderService.GetListofCustomerstoCheckIfExistsTrue(id); //get true status values
            if (orders.Count != 0) //has value with false status
            {
                List<Delivery> deliveries = orderService.GetListofCustomerstoMakeOrderDelivered(id);
                if (deliveries.Count != 0) //has value with false status
                {
                    for (int i = 0; i < deliveries.Count; i++)
                    {
                        deliveries[i].Status = true;
                        orders[i].Status = true;
                        orderService.UpdateStausofDeliveryforDeliveredOrder(orders[i]);
                        deliveryService.UpdateStausofDeliveryforDeliveredOrder(deliveries[i]);
                    }
                    return Json(new { sms = "Saved" });
                }               
            }
            else if (orders.Count == 0) //neither id nor status has been matched
            {               
                List<Delivery> deliveries = orderService.GetListofCustomerstoMakeOrderDelivered(id);
                if (deliveries.Count == 0) //neither id nor status has been matched
                {
                    if (ordersTrue.Count != 0)
                    {
                        List<Delivery> deliveriesTrue = orderService.GetListofCustomerstoMakeOrderDeliveredTrue(id); //get true status values
                        if (deliveriesTrue.Count != 0)
                        {
                            for (int i = 0; i < deliveriesTrue.Count; i++)
                            {
                                deliveriesTrue[i].Status = false;
                                ordersTrue[i].Status = false;
                                orderService.UpdateStausofDeliveryforDeliveredOrder(ordersTrue[i]);
                                deliveryService.UpdateStausofDeliveryforDeliveredOrder(deliveriesTrue[i]);
                            }
                            return Json(new { sms = "Deleted" });
                        }
                    }                    
                }
            }            
            return RedirectToAction("CustomerList", "Admin");
        }
        public IActionResult CancelOrder(int id) //updates false CancelStatus to true; no view, only does CRUD
        {
            // contains matched hiddenPKId & false CancelStatus
            var cancelationOrderList = orderService.GetListofOrderforCancelation(id);
            // contains matched hiddenPKId & productinventory
            var productListfromOrder = orderService.GetOrderListtoUpdateProductQuantityAfterOrderCancel(id);
            //contains cancelled orders (to-be-delivered in order & pending in delivery)
            //var cancelledOrders = deliveryService.GetDeliveryListbyHiddenPKIdforDeletingCancelledOrder(id);
            if (cancelationOrderList.Count != 0)
            {
                for (int i = 0; i < cancelationOrderList.Count; i++)
                {
                    cancelationOrderList[i].CancelStatus = true;                    
                    orderService.CancelOrderbyHiddenPKId(cancelationOrderList[i]);                    
                }
                //if (cancelledOrders.Count != 0)
                //{

                //}
                if (productListfromOrder.Count != 0)
                {
                    for (int j = 0; j < productListfromOrder.Count; j++)
                    {
                        var a = productInventoryService.GetProductListtoMatchtheProductInventoryId
                            (productListfromOrder[j].ProductInventoryId);
                        if (a.Count != 0)
                        {
                            for (int k = 0; k < a.Count; k++)
                            {                                
                                a[k].AvailableQuantity += productListfromOrder[j].Quantity;
                                //productInventoryService.UpdateProductQuantityafterOrdercancel(a[k]);
                                //changed cause both are same methods
                                productInventoryService.UpdateProduct(a[k]);
                            }
                        }
                    }
                }
                return Json(new { sms = "Saved" });
            }
            return View();
        }

        public IActionResult ComplaintList(int? Page)
        {
            var pageNumber = Page ?? 1;
            int pageSize = 10;
            int sl = 1;
            List<DeliveryVM> deliveryVMs = new List<DeliveryVM>();
            var orders = orderService.ComplaintListofTobeReturnedRefunded();
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
                        deliveryVM.HiddenPKVMId = i.hiddenPKId;
                        deliveryVM.CustomerVMId = i.customerId;
                        deliveryVM.CustomerVMName = i.customerName;
                        deliveryVM.CustomerVMArea = i.area;
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
                        else if(deliveryService.PendingReturnedandRefunded(i.hiddenPKId) != null)
                        {
                            deliveryVM.StringReturnedRefundedVMStatus = "Pending";
                        }
                        deliveryVM.OrderPlacedVMDate = i.orderPlacedDate;
                        deliveryVM.DeliveredVMDate = i.orderDeliveredDate;
                        if (deliveryService.GetReturnRefundListbyHiddenId(i.hiddenPKId).Count != 0)
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
    
        public IActionResult ComplaintIndividualInfo(int id)
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
                                        complaintDescription=d.ComplaintDescription
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

        public IActionResult AllOrders(int? Page)
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
                                         brand=d.ProductInventory.Brand.BrandName,
                                         category=d.ProductInventory.ProductCategory.ProductCategoryTitle,
                                         color= d.ProductInventory.Color,
                                         size= d.ProductInventory.Size,
                                         material= d.ProductInventory.Material,
                                         status = d.Status,
                                         orderPlacedDate = d.OrderDate,
                                         productUnitCost=d.ProductInventory.SellPrice,
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
    
        public IActionResult ComplaintReport()
        {
            int sl = 1;
            List<DeliveryVM> deliveryVMs = new List<DeliveryVM>();
            var details = deliveryService.ReturnedRefundedListforChart();
            if (details.Count != 0)
            {
                var pass = from a in details
                           group a by a.Order.HiddenPKId into b
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
                        deliveryVM.ProductVMId = i.productId;
                        deliveryVM.SerialNo = sl;
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

        public IActionResult ProfitReport()
        {
            List<ProductInventoryVM> productInventoryVMs = new List<ProductInventoryVM>();
            int sl = 1;
            var profit = deliveryService.DeliveredOrderforProfit();
            var pass=from a in profit
                     group a by new { a.Order.ProductInventoryId } into b
                     orderby b.Key.ProductInventoryId
                     let c = (from d in b
                              select new
                              { 
                                  name=d.Order.ProductInventory.Name,
                                  profitEach=(d.Order.Quantity*(d.Order.ProductInventory.SellPrice- d.Order.ProductInventory.PurchasePrice)/100),
                                  category=d.Order.ProductInventory.ProductCategory.ProductCategoryTitle,
                                  brand=d.Order.ProductInventory.Brand.BrandName,
                                  soldQuantity=d.Order.Quantity
                              })
                     select c;
            foreach (var item in pass)
            {
                ProductInventoryVM productInventoryVM = new ProductInventoryVM();
                foreach (var i in item)
                {
                    productInventoryVM.SerialNo = sl;
                    productInventoryVM.NameVM = i.name;
                    productInventoryVM.ProfitEachVM = i.profitEach;
                    productInventoryVM.ProductCategoryTitleVM = i.category;
                    productInventoryVM.BrandNameVM = i.brand;
                    productInventoryVM.QuantityVM = i.soldQuantity;
                    
                }
                productInventoryVMs.Add(productInventoryVM); 
                sl++;

            }
            return View(productInventoryVMs);
        }
    }
}