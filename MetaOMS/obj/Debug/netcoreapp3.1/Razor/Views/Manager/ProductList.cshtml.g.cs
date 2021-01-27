#pragma checksum "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02e5caab95ad90607daa59b1135f6f1747dcb4a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_ProductList), @"mvc.1.0.view", @"/Views/Manager/ProductList.cshtml")]
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
#nullable restore
#line 2 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
using X.PagedList.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
using MetaOMS.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02e5caab95ad90607daa59b1135f6f1747dcb4a8", @"/Views/Manager/ProductList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"030d4dd93e812b805bc2ff9335704f93868d8937", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_ProductList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<MetaOMS.ViewModels.ProductInventoryVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 6 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
  
    ViewData["Title"] = "ProductList-";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-10 offset-1 mt-5 text-center"">
    <h1 class=""text-center mt-3 mb-3"">Product List</h1>
    <div class=""search-form mb-2"">
        <div class=""input-group"">
            <div class=""input-group-prepend"">
                <div class=""input-group-text"">
                    <i class=""ti-search""></i>
                </div>
            </div>
            <input id=""myCustomSearch"" type=""text"" class=""form-control"" placeholder=""Type here to search..."">
        </div>
    </div>
    <div class=""table-responsive"">
        <table class=""table"" id=""example"">
            <thead class=""thead-light"">
                <tr>
                    <th>#</th>
                    <th>Product</th>
                    <th>Category</th>
                    <th>Brand</th>
                    <th>Color</th>
                    <th>Size</th>
                    <th>Material</th>
                    <th>Sell price</th>
                    <th>Last Stocked In</th>
                    <th>Total Availa");
            WriteLiteral("ble</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 39 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 42 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
                       Write(item.SerialNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 43 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
                       Write(item.NameVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 44 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
                       Write(item.ProductCategoryTitleVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 45 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
                       Write(item.BrandNameVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 46 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
                        Write((ColorEnum)Convert.ToInt32(item.ColorVM));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 47 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
                        Write((SizeEnum)Convert.ToInt32(item.SizeVM));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 48 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
                        Write((MaterialEnum)Convert.ToInt32(item.MaterialVM));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 49 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
                       Write(item.SellPriceVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 50 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
                       Write(item.StockInQuantityVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 51 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
                       Write(item.AvailableQuantityVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 53 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    ");
#nullable restore
#line 57 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ProductList.cshtml"
Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("ProductList", new { page = page }),
     new X.PagedList.Mvc.Core.Common.PagedListRenderOptions
     {
         DisplayItemSliceAndTotal = true,
         ContainerDivClasses = new[] { "navigation" },
         LiElementClasses = new[] { "page-item" },
         PageClasses = new[] { "page-link" },
     }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js""></script>
    <script>
        $(document).ready(function () {
            $('#example').DataTable({
                ""dom"": 'lrtip',
                ""info"": false,
                ""lengthChange"": false,
                ""paging"": false,
            });
            var table = $('#example').DataTable();
            $('#myCustomSearch').on('keyup', function () {
                table.search($(this).val()).draw();
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $('ul.pagination > li.disabled > a').addClass('page-link');
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.IPagedList<MetaOMS.ViewModels.ProductInventoryVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
