#pragma checksum "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd45f24cd8df23a483855a2edf3586195506df4a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_ManageReturn), @"mvc.1.0.view", @"/Views/Manager/ManageReturn.cshtml")]
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
#line 2 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
using X.PagedList.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd45f24cd8df23a483855a2edf3586195506df4a", @"/Views/Manager/ManageReturn.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"030d4dd93e812b805bc2ff9335704f93868d8937", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_ManageReturn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<MetaOMS.ViewModels.DeliveryVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Toastr/toastr.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/sweetalert2/sweetalert2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Toastr/toastr.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/sweetalert2/sweetalert2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
  
    ViewData["Title"] = "ManageReturn";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dd45f24cd8df23a483855a2edf3586195506df4a5660", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dd45f24cd8df23a483855a2edf3586195506df4a6774", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<div class=""col-10 offset-1 text-center"">
    <h2 class=""text-center mt-5 mb-3"">Manage Return & Refund from Here</h2>
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
                    <th>Customer</th>
                    <th>Contact</th>
                    <th>Ordered products</th>
                    <th>Product quantity</th>
                    <th>Total price</th>
                    <th>Status</th>
                    <th>Delivered on</th>
                    <th>Action</th>");
            WriteLiteral("\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 40 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                 for (int i = 0; i < Model.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td class=\"align-middle\">");
#nullable restore
#line 43 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                                            Write(Model[i].SerialNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"align-middle\">");
#nullable restore
#line 44 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                                            Write(Model[i].CustomerVMName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"align-middle\">");
#nullable restore
#line 45 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                                            Write(Model[i].CustomerVMContactNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td width=\"20%\">\r\n                            <table class=\"d-flex justify-content-center table-borderless\">\r\n");
#nullable restore
#line 48 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                                 foreach (var item in Model[i].productInventory_VM.productInventoryVMs)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 51 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                                       Write(item.NameVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 53 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </table>\r\n                        </td>\r\n                        <td>\r\n                            <table class=\"d-flex justify-content-center table-borderless\">\r\n");
#nullable restore
#line 58 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                                 foreach (var item in Model[i].productInventory_VM.productInventoryVMs)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 61 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                                       Write(item.QuantityVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 63 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </table>\r\n                        </td>\r\n                        <td class=\"align-middle\">");
#nullable restore
#line 66 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                                            Write(Model[i].TotalPriceVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"align-middle\" id=\"status\">\r\n                            <span class=\"font-weight-bold badge badge-success\">");
#nullable restore
#line 68 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                                                                          Write(Model[i].StringStatusVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </td>\r\n                        <td class=\"align-middle\" id=\"status\">");
#nullable restore
#line 70 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                                                        Write(Model[i].DeliveredVMDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"align-middle\" id=\"status\">\r\n                            <a");
            BeginWriteAttribute("onclick", " onclick=\"", 3257, "\"", 3414, 8);
            WriteAttributeValue("", 3267, "showInPopup(\'", 3267, 13, true);
#nullable restore
#line 72 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
WriteAttributeValue("", 3280, Url.Action("ReturnProduct","Manager",new {id=@Model[i].HiddenPKVMId },Context.Request.Scheme), 3280, 94, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3374, "\',\'Select", 3374, 9, true);
            WriteAttributeValue(" ", 3383, "products", 3384, 9, true);
            WriteAttributeValue(" ", 3392, "to", 3393, 3, true);
            WriteAttributeValue(" ", 3395, "return", 3396, 7, true);
            WriteAttributeValue(" ", 3402, "or", 3403, 3, true);
            WriteAttributeValue(" ", 3405, "refund\')", 3406, 9, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                               class=\" btn btn-tumblr text-white\">\r\n                                <i class=\"mdi mdi-loop\"></i>\r\n                            </a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 78 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    ");
#nullable restore
#line 82 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\ManageReturn.cshtml"
Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("ManageReturn", new { page = page }),
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
    <script>
        $(document).ready(function () {
            $('ul.pagination > li.disabled > a').addClass('page-link');
        });
    </script>
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
");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd45f24cd8df23a483855a2edf3586195506df4a16585", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script src=\"https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd45f24cd8df23a483855a2edf3586195506df4a17781", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.IPagedList<MetaOMS.ViewModels.DeliveryVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
