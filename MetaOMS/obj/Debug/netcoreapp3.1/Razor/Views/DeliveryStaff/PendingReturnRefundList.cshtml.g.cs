#pragma checksum "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0ba84940b632481b9eb1caac01c32f3e7290b0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DeliveryStaff_PendingReturnRefundList), @"mvc.1.0.view", @"/Views/DeliveryStaff/PendingReturnRefundList.cshtml")]
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
#line 2 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
using X.PagedList.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0ba84940b632481b9eb1caac01c32f3e7290b0b", @"/Views/DeliveryStaff/PendingReturnRefundList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"030d4dd93e812b805bc2ff9335704f93868d8937", @"/Views/_ViewImports.cshtml")]
    public class Views_DeliveryStaff_PendingReturnRefundList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<MetaOMS.ViewModels.DeliveryVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Toastr/toastr.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/sweetalert2/sweetalert2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-check"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("status_deliverable"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Toastr/toastr.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/sweetalert2/sweetalert2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
  
    ViewData["Title"] = "PendingReturnRefundList- ";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b0ba84940b632481b9eb1caac01c32f3e7290b0b6958", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b0ba84940b632481b9eb1caac01c32f3e7290b0b8072", async() => {
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
    <h2 class=""text-center mt-5 mb-3"">Pending Returns & Refunds</h2>
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
                    <th>Deliver</th>
                    <th>Customer</th>
                    <th>Contact</th>
");
            WriteLiteral(@"                    <th>Products</th>
                    <th>Product quantity</th>
                    <th>Action</th>
                    <th>Total price</th>
                    <th>Status</th>
                    <th>Details</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 42 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                 for (int i = 0; i < Model.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"align-middle\">");
#nullable restore
#line 45 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                        Write(Model[i].SerialNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b0ba84940b632481b9eb1caac01c32f3e7290b0b11051", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 47 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model[i].ReturnedRefundedVMStatus);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 48 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                   Write(Model[i].HiddenPKVMId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"align-middle\">");
#nullable restore
#line 50 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                        Write(Model[i].CustomerVMName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle\">");
#nullable restore
#line 51 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                        Write(Model[i].CustomerVMContactNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                    <td>\r\n                        <table class=\"d-flex justify-content-center table-borderless\">\r\n");
#nullable restore
#line 58 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                             foreach (var item in Model[i].productInventory_VM.productInventoryVMs)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td class=\"align-middle\">");
#nullable restore
#line 61 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                                        Write(item.NameVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 63 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </table>\r\n                    </td>\r\n                    <td>\r\n                        <table class=\"d-flex justify-content-center table-borderless\">\r\n");
#nullable restore
#line 68 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                             foreach (var item in Model[i].productInventory_VM.productInventoryVMs)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td class=\"align-middle\">");
#nullable restore
#line 71 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                                        Write(item.QuantityVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 73 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </table>\r\n                    </td>\r\n                    <td>\r\n                        <table class=\"d-flex justify-content-center table-borderless\">\r\n");
#nullable restore
#line 78 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                             foreach (var item in Model[i].productInventory_VM.productInventoryVMs)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n");
#nullable restore
#line 81 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                 if (item.StringStatusVM == "Return")
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td class=\"font-weight-bold text-info align-middle\">");
#nullable restore
#line 83 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                                                                   Write(item.StringStatusVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 84 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                }
                                else if (item.StringStatusVM == "Refund")
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td class=\"font-weight-bold text-primary align-middle\">");
#nullable restore
#line 87 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                                                                      Write(item.StringStatusVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 88 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                }
                                else if (item.StringStatusVM == "Return & Refund")
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td class=\"font-weight-bold text-warning align-middle\">");
#nullable restore
#line 91 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                                                                      Write(item.StringStatusVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 92 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tr>\r\n");
#nullable restore
#line 98 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </table>\r\n                    </td>\r\n                    <td class=\"align-middle\">");
#nullable restore
#line 101 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                        Write(Model[i].TotalPriceVM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"font-weight-bold align-middle\" id=\"status\">");
#nullable restore
#line 102 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                                                                     Write(Model[i].StringReturnedRefundedVMStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle\">\r\n                        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 5015, "\"", 5170, 3);
            WriteAttributeValue("", 5025, "showInPopup(\'", 5025, 13, true);
#nullable restore
#line 104 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
WriteAttributeValue("", 5038, Url.Action("PendingReturnRefundIndividualInfo","DeliveryStaff",new {id=@Model[i].HiddenPKVMId },Context.Request.Scheme), 5038, 120, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5158, "\',\'Details\')", 5158, 12, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                           class=\"btn btn-orange text-white\"><i class=\"mdi mdi-information-outline\"></i></a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 108 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    ");
#nullable restore
#line 112 "E:\MetaOrderManagementSystem\MetaOMS\Views\DeliveryStaff\PendingReturnRefundList.cshtml"
Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("PendingReturnRefundList", new { page = page }),
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
        $(""input[type=checkbox]"").click(function () {
            var THIS = $(this);

            var hiddenPkId = $(this).data(""id"");
            console.log($(this).prop(""checked""))
            if ($(this).prop(""checked"")) {
                Swal.fire({
                    title: 'Are you sure?',
                    text: ""You want to complete this action !"",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes, Do it!'
                }).then((result) => {
                    if (result.isConfirmed) {
                        try {
                            var url = ""/DeliveryStaff/ConfirmReturnRefund"";
                            $.getJSON(url, { id: hiddenPkId }, function (data) {
                                if (data.sms === ""Saved"") {
                                    toastr[""success""](""Succes");
                WriteLiteral(@"sful"")

                                    THIS.closest(""tr"").find('#status').text(""Done"");
                                }
                                else {
                                    toastr[""info""](""Pending"")
                                    THIS.closest(""tr"").find('#status').text(""Pending"");
                                }
                            });
                        } catch (ex) {
                            console.log(ex)
                        }
                    }
                    else {
                        $(this).prop(""checked"", false);
                    }
                });
            }
            else {
                Swal.fire({
                    title: 'Are you sure?',
                    text: ""You want to keep this action pending !"",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
        ");
                WriteLiteral(@"            confirmButtonText: 'Yes, Do it!'
                }).then((result) => {
                    if (result.isConfirmed) {
                        try {
                            var url = ""/DeliveryStaff/ConfirmReturnRefund"";
                            $.getJSON(url, { id: hiddenPkId }, function (data) {
                                if (data.sms === ""Saved"") {
                                    toastr[""success""](""Successful"")
                                    THIS.closest(""tr"").find('#status').text(""Done""); console.log(hiddenPkId);
                                }
                                else {
                                    toastr[""info""](""Pending"")
                                    THIS.closest(""tr"").find('#status').text(""Pending"");
                                }
                            });
                        } catch (ex) {
                            console.log(ex)
                        }
                    }
                    else {
   ");
                WriteLiteral(@"                     $(this).prop(""checked"", true);
                    }
                });
            }
        });
    </script>
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0ba84940b632481b9eb1caac01c32f3e7290b0b26456", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script src=\"https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0ba84940b632481b9eb1caac01c32f3e7290b0b27652", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
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
