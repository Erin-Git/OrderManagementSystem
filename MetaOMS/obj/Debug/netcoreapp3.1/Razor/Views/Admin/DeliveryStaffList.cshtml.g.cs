#pragma checksum "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7467cf2f835256a567d5fa3c59c8e289783a3c28"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_DeliveryStaffList), @"mvc.1.0.view", @"/Views/Admin/DeliveryStaffList.cshtml")]
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
#line 3 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
using X.PagedList.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7467cf2f835256a567d5fa3c59c8e289783a3c28", @"/Views/Admin/DeliveryStaffList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"030d4dd93e812b805bc2ff9335704f93868d8937", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_DeliveryStaffList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<MetaOMS.ViewModels.DeliveryStaffVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/sweetalert2/sweetalert2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/sweetalert2/sweetalert2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7467cf2f835256a567d5fa3c59c8e289783a3c284736", async() => {
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
#nullable restore
#line 6 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
  
    ViewData["Title"] = "DeliveryStaffList-";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-8 offset-2 mt-5\">\r\n    <h2 class=\"text-center mt-3 mb-3\">\r\n        List of Delivery Staffs &nbsp; &nbsp;<a");
            BeginWriteAttribute("onclick", " onclick=\"", 389, "\"", 521, 6);
            WriteAttributeValue("", 399, "showInPopup(\'", 399, 13, true);
#nullable restore
#line 12 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
WriteAttributeValue("", 412, Url.Action("AddorUpdateDeliveryStaff","Admin",new {id=0 },Context.Request.Scheme), 412, 82, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 494, "\',\'Add", 494, 6, true);
            WriteAttributeValue(" ", 500, "New", 501, 4, true);
            WriteAttributeValue(" ", 504, "Delivery", 505, 9, true);
            WriteAttributeValue(" ", 513, "Staff\')", 514, 8, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-success text-white""><i class=""mdi mdi-plus""></i></a>
    </h2>
    <div class=""table-responsive"">
        <table class=""table"">
            <thead class=""thead-light"">
                <tr>
                    <th>
                        #
                    </th>
                    <th>
                        Delivery Staff Name
                    </th>
                    <th>
                        Contact No
                    </th>
                    <th>
                        Email Address
                    </th>
                    <th>
                        Actions
                    </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 36 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 40 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
                       Write(Html.DisplayFor(modelItem => item.SerialNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 43 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DeliveryStaffVMName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 46 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ContactVMNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 49 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
                       Write(Html.DisplayFor(modelItem => item.EmailVMAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1955, "\"", 2113, 6);
            WriteAttributeValue("", 1965, "showInPopup(\'", 1965, 13, true);
#nullable restore
#line 52 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
WriteAttributeValue("", 1978, Url.Action("AddorUpdateDeliveryStaff","Admin",new {id=@item.DeliveryStaffVMId },Context.Request.Scheme), 1978, 104, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2082, "\',\'Update", 2082, 9, true);
            WriteAttributeValue(" ", 2091, "Delivery", 2092, 9, true);
            WriteAttributeValue(" ", 2100, "Staff", 2101, 6, true);
            WriteAttributeValue(" ", 2106, "Info\')", 2107, 7, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                               class=\"btn btn-dropbox text-white\"><i class=\"mdi mdi-pencil\"></i></a>\r\n");
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 58 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
#nullable restore
#line 62 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
     if (Model.Count > 0)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
   Write(Html.PagedListPager((IPagedList)Model, c => Href("~/Admin/DeliveryStaffList?page=" + c),
        new X.PagedList.Mvc.Core.Common.PagedListRenderOptions
        {
            PageClasses = new string[] { "page-link" },
            UlElementClasses = new string[] { "pagination" },
            LiElementClasses = new string[] { "page-item" },
            MaximumPageNumbersToDisplay = 5,
        }
        ));

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\DeliveryStaffList.cshtml"
         }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7467cf2f835256a567d5fa3c59c8e289783a3c2811805", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.IPagedList<MetaOMS.ViewModels.DeliveryStaffVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
