#pragma checksum "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a037cdeee89d0ad001f428b2c592e223646be81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_Index), @"mvc.1.0.view", @"/Views/Manager/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a037cdeee89d0ad001f428b2c592e223646be81", @"/Views/Manager/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"030d4dd93e812b805bc2ff9335704f93868d8937", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MetaOMS.ViewModels.DeliveryVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\Index.cshtml"
  
    ViewData["Title"] = "Dashboard-";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <div class=""row mt-5"">
        <div class=""col-sm-6 col-lg-3"">
            <div class=""bg-info card card-hover rounded"">
                <div class=""box text-center text-white"">
                    <h1 class=""font-light"">
                        <i class=""mdi mdi-clipboard""></i>
                    </h1>
                    <h6>Total Orders</h6>
                    <h3 class=""font-weight-bold"">");
#nullable restore
#line 15 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\Index.cshtml"
                                            Write(Model.TotalOrderVMCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                </div>
            </div>
        </div>
        <div class=""col-sm-6 col-lg-3"">
            <div class=""bg-success card card-hover rounded"">
                <div class=""box text-center text-white"">
                    <h1 class=""font-light"">
                        <i class=""mdi mdi-clipboard-check""></i>
                    </h1>
                    <h6>Successful Deliveries</h6>
                    <h3 class=""font-weight-bold"">");
#nullable restore
#line 26 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\Index.cshtml"
                                            Write(Model.TotalDeliveryVMCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                </div>
            </div>
        </div>
        <div class=""col-sm-6 col-lg-3"">
            <div class=""bg-danger card card-hover rounded"">
                <div class=""box text-center text-white"">
                    <h1 class=""font-light"">
                        <i class=""mdi mdi-close-circle""></i>
                    </h1>
                    <h6>Cancelled Orders</h6>
                    <h3 class=""font-weight-bold"">");
#nullable restore
#line 37 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\Index.cshtml"
                                            Write(Model.TotalCancelledOrderVMCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                </div>
            </div>
        </div>
        <div class=""col-sm-6 col-lg-3"">
            <div class=""bg-warning card card-hover rounded"">
                <div class=""box text-center text-white"">
                    <h1 class=""font-light"">
                        <i class=""mdi mdi-loop""></i>
                    </h1>
                    <h6>Returns/Refunds</h6>
                    <h3 class=""font-weight-bold"">");
#nullable restore
#line 48 "E:\MetaOrderManagementSystem\MetaOMS\Views\Manager\Index.cshtml"
                                            Write(Model.TotalReturnedRefundedOrderVMCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""container mt-4"">
    <div class=""row"">
        <div class=""col-12"">
            <div id=""productChartContainer"" style=""min-width: 310px; height: 400px; margin: 0 auto""></div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $.getJSON(""/Manager/GetDataforProductChart"", function (data) {
                var Names = []
                var Qts = []
                for (var i = 0; i < data.length; i++) {
                    Names.push(data[i].name);
                    Qts.push(data[i].count);
                }

                Highcharts.chart('productChartContainer', {
                    chart: {
                        type: 'line'
                    },
                    title: {
                        text: 'Successful Product Consumption'
                    },
                    subtitle: {
                        text: 'Graph showing product consumption of successful deliveries along with avilable products'
                    },
                    xAxis: {
                        categories: Names
                    },
                    yAxis: {
                        title: {
                            text: 'Sold quantity");
                WriteLiteral(@"'
                        }
                    },
                    plotOptions: {
                        line: {
                            dataLabels: {
                                enabled: true
                            },
                            enableMouseTracking: false
                        }
                    },
                    series: [{
                        name: 'Products',
                        data: Qts
                    }]
                });
            });
        });</script>


");
                WriteLiteral(@"

    <script src=""https://code.highcharts.com/highcharts.js""></script>
    <script src=""https://code.highcharts.com/modules/exporting.js""></script>
    <script src=""https://code.highcharts.com/modules/export-data.js""></script>
    <script src=""https://code.highcharts.com/modules/accessibility.js""></script>

    <script src=""https://code.highcharts.com/modules/data.js""></script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MetaOMS.ViewModels.DeliveryVM> Html { get; private set; }
    }
}
#pragma warning restore 1591