#pragma checksum "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "696c09be8376a9712edd6435620738f04f74b1ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ProductListforReport), @"mvc.1.0.view", @"/Views/Admin/ProductListforReport.cshtml")]
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
#line 2 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
using MetaOMS.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"696c09be8376a9712edd6435620738f04f74b1ba", @"/Views/Admin/ProductListforReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"030d4dd93e812b805bc2ff9335704f93868d8937", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ProductListforReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MetaOMS.ViewModels.ProductInventoryVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
  
    ViewData["Title"] = "ProductListforReport-";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-2 text-left mt-5 mb-3\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "696c09be8376a9712edd6435620738f04f74b1ba4592", async() => {
                WriteLiteral("<i class=\"mdi mdi-keyboard-backspace\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
        <div class=""col-8 text-center mt-5 mb-3"">
            <h2 class=""mt-3 mb-3"">Generate Stock Report</h2>
        </div>
        <div class=""col-2 text-right mt-5 mb-3"">
            <button type=""button"" id=""print"" class=""btn btn-dark""><i class=""mdi mdi-printer""></i></button>
        </div>
    </div>
    <div class=""col-12 text-center bg-light"" id=""stockReport"">
        <div class=""table-responsive"">
            <h3 class=""pt-5 pb-5""><strong>Stock Report</strong></h3>
            <table class=""table"" id=""example"">
                <thead class=""thead-dark"">
                    <tr>
                        <th>#</th>
                        <th>Product</th>
                        <th>Category</th>
                        <th>Brand</th>
                        <th>Other Details</th>
                        <th>Last Stocked In</th>
                        <th>Total Available</th>
                        <th>Purchase price</th>
                        <th>Sell price</t");
            WriteLiteral("h>\r\n                        <th>Stocked In Date</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 38 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 41 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                           Write(item.SerialNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 42 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                           Write(item.NameVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 43 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                           Write(item.ProductCategoryTitleVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 44 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                           Write(item.BrandNameVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                Color- ");
#nullable restore
#line 46 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                                   Write((ColorEnum)Convert.ToInt32(item.ColorVM));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <br />Size- ");
#nullable restore
#line 47 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                                        Write((SizeEnum)Convert.ToInt32(item.SizeVM));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <br />Material- ");
#nullable restore
#line 48 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                                            Write((MaterialEnum)Convert.ToInt32(item.MaterialVM));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>");
#nullable restore
#line 50 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                           Write(item.StockInQuantityVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 51 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                           Write(item.AvailableQuantityVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 52 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                           Write(item.PurchasePriceVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 53 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                           Write(item.SellPriceVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 54 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                           Write(item.StockInDateVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 56 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\ProductListforReport.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            $(""#print"").click(function () {
                var element = document.getElementById('stockReport');
                // Generate PDF.
                const options = {
                    filename: 'StockReport.pdf',
                    image: { type: 'jpeg' },
                    html2canvas: {},
                    jsPDF: { orientation: 'Landscape', unit: 'in', format: 'letter', compressPDF: true }
                };
                html2pdf().from(element).set(options).save();
            });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MetaOMS.ViewModels.ProductInventoryVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591