#pragma checksum "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\CustomerIndividualInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0187d756bae395e0d61e56fffc52ce74ea2485a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_CustomerIndividualInfo), @"mvc.1.0.view", @"/Views/Admin/CustomerIndividualInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0187d756bae395e0d61e56fffc52ce74ea2485a5", @"/Views/Admin/CustomerIndividualInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"030d4dd93e812b805bc2ff9335704f93868d8937", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_CustomerIndividualInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MetaOMS.ViewModels.CustomerVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-twitter"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PlaceNewOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\CustomerIndividualInfo.cshtml"
  
    ViewData["Title"] = "CustomerIndividualInfo";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-10  offset-1 text-center bg-light p-10"">
            <table class=""table table-active"">
                <tbody>
                    <tr>
                        <td class=""thead-dark text-dark"">Name:</td>
                        <td>");
#nullable restore
#line 14 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\CustomerIndividualInfo.cshtml"
                       Write(Model.CustomerVMName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td class=\"thead-dark text-dark\">Contact:</td>\r\n                        <td>");
#nullable restore
#line 18 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\CustomerIndividualInfo.cshtml"
                       Write(Model.ContactNoVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            WriteLiteral("                    <tr>\r\n                        <td class=\"thead-dark text-dark\">District:</td>\r\n                        <td>");
#nullable restore
#line 26 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\CustomerIndividualInfo.cshtml"
                       Write(Model.DistrictVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td class=\"thead-dark text-dark\">Sub-district:</td>\r\n                        <td>");
#nullable restore
#line 30 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\CustomerIndividualInfo.cshtml"
                       Write(Model.SubDistrictVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td class=\"thead-dark text-dark\">Area:</td>\r\n                        <td>");
#nullable restore
#line 34 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\CustomerIndividualInfo.cshtml"
                       Write(Model.AreaVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td class=\"thead-dark text-dark\">House No:</td>\r\n                        <td>");
#nullable restore
#line 38 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\CustomerIndividualInfo.cshtml"
                       Write(Model.HouseNoVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td class=\"thead-dark text-dark\">Road No:</td>\r\n                        <td>");
#nullable restore
#line 42 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\CustomerIndividualInfo.cshtml"
                       Write(Model.RoadNoVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        <div>\r\n            <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1847, "\"", 1990, 5);
            WriteAttributeValue("", 1857, "showInPopup(\'", 1857, 13, true);
#nullable restore
#line 47 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\CustomerIndividualInfo.cshtml"
WriteAttributeValue("", 1870, Url.Action("AddOrUpdateCustomer","Admin",new {id=@Model.CustomerVMId },Context.Request.Scheme), 1870, 95, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1965, "\',\'Update", 1965, 9, true);
            WriteAttributeValue(" ", 1974, "Customer", 1975, 9, true);
            WriteAttributeValue(" ", 1983, "Info\')", 1984, 7, true);
            EndWriteAttribute();
            WriteLiteral("\r\n               class=\"btn btn-dropbox text-white\">Edit</a>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0187d756bae395e0d61e56fffc52ce74ea2485a58319", async() => {
                WriteLiteral("Create Order");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 49 "E:\MetaOrderManagementSystem\MetaOMS\Views\Admin\CustomerIndividualInfo.cshtml"
                                                                                          WriteLiteral(Model.CustomerVMId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MetaOMS.ViewModels.CustomerVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
