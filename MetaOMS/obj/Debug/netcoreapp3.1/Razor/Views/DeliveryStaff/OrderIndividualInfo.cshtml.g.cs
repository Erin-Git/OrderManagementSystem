#pragma checksum "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3118f898cc975b9a6d642b7c141c5701614faf0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DeliveryStaff_OrderIndividualInfo), @"mvc.1.0.view", @"/Views/DeliveryStaff/OrderIndividualInfo.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\MetaOrderManagementSystem\MetaOMS\Views\_ViewImports.cshtml"
using MetaOMS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\MetaOrderManagementSystem\MetaOMS\Views\_ViewImports.cshtml"
using MetaOMS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3118f898cc975b9a6d642b7c141c5701614faf0b", @"/Views/DeliveryStaff/OrderIndividualInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"030d4dd93e812b805bc2ff9335704f93868d8937", @"/Views/_ViewImports.cshtml")]
    public class Views_DeliveryStaff_OrderIndividualInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MetaOMS.ViewModels.DeliveryVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
  
    ViewData["Title"] = "OrderIndividualInfo-";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-6\">\r\n            <ul class=\"list-group\">\r\n");
#nullable restore
#line 10 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                 for (int i = 0; i < Model.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"list-group-item active font-weight-bold border-right\"><i class=\"mdi mdi-account-circle\"></i>&nbsp;Customer Info</li>\r\n                    <li class=\"list-group-item\"><h6 class=\"font-weight-bold\">Name:</h6>");
#nullable restore
#line 13 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                                                                                  Write(Model[i].CustomerVMName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><h6 class=\"font-weight-bold\">Contact:</h6>");
#nullable restore
#line 14 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                                                                                     Write(Model[i].CustomerVMContactNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\">\r\n                        <h6 class=\"font-weight-bold\">Address:</h6>\r\n                        ");
#nullable restore
#line 17 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                   Write(Model[i].CustomerVMDistrict);

#line default
#line hidden
#nullable disable
            WriteLiteral(" , ");
#nullable restore
#line 17 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                                                  Write(Model[i].CustomerVMSubDistrict);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ,\r\n                        ");
#nullable restore
#line 18 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                   Write(Model[i].CustomerVMArea);

#line default
#line hidden
#nullable disable
            WriteLiteral(" , Road- ");
#nullable restore
#line 18 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                                                    Write(Model[i].CustomerVMRoadNo);

#line default
#line hidden
#nullable disable
            WriteLiteral(" , House- ");
#nullable restore
#line 18 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                                                                                        Write(Model[i].CustomerVMRoadNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </li>\r\n");
#nullable restore
#line 20 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </div>\r\n        <div class=\"col-6\">\r\n            <ul class=\"list-group\">\r\n");
#nullable restore
#line 25 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                 for (int i = 0; i < Model.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"list-group-item active font-weight-bold border-right\"><i class=\"mdi mdi-truck-delivery\"></i>&nbsp;Order Info</li>\r\n");
            WriteLiteral("                    <li class=\"list-group-item\"><h6 class=\"font-weight-bold\">Shipping by:</h6>");
#nullable restore
#line 29 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                                                                                         Write(Model[i].ShippingVMMethod);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><h6 class=\"font-weight-bold\">Payment by:</h6>");
#nullable restore
#line 30 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                                                                                        Write(Model[i].PaymentVMMethod);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\">\r\n                        <h6 class=\"font-weight-bold\">Ordered date:</h6>");
#nullable restore
#line 32 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                                                                  Write(Model[i].OrderPlacedVMDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </li>\r\n");
#nullable restore
#line 34 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </div>\r\n        <div class=\"col-12 mt-2\">\r\n            <ul class=\"list-group\">\r\n");
#nullable restore
#line 39 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                 for (int i = 0; i < Model.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"list-group-item active font-weight-bold border-right text-center\"><i class=\"mdi mdi-shopping\"></i>&nbsp;Product Details</li>\r\n");
            WriteLiteral(@"                    <li class=""list-group-item"">
                        <div class=""table-responsive text-center"">
                            <table class=""table"">
                                <thead class=""thead-light"">
                                    <tr>
                                        <th>Product</th>
                                        <th>Quanity</th>
                                        <th>Sub-total</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 54 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                                     foreach (var item in Model[i].productInventory_VM.productInventoryVMs)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td class=\"align-middle\">");
#nullable restore
#line 57 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                                                                Write(item.NameVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"align-middle\">");
#nullable restore
#line 58 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                                                                Write(item.QuantityVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"align-middle\">");
#nullable restore
#line 59 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                                                                Write(item.EachPriceVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n");
#nullable restore
#line 61 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </li>\r\n");
#nullable restore
#line 66 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\OrderIndividualInfo.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MetaOMS.ViewModels.DeliveryVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
