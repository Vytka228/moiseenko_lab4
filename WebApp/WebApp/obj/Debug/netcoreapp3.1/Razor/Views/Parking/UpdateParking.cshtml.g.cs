#pragma checksum "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12ef045aebc906a28a681293244ce96b6ba055f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Parking_UpdateParking), @"mvc.1.0.view", @"/Views/Parking/UpdateParking.cshtml")]
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
#line 1 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12ef045aebc906a28a681293244ce96b6ba055f6", @"/Views/Parking/UpdateParking.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Parking_UpdateParking : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApp.Models.ParkingUpdateViewModel>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h3>\r\n    Изменение записи\r\n</h3>\r\n");
#nullable restore
#line 5 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
 using (Html.BeginForm("UpdateParking", "Parking", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        ");
#nullable restore
#line 8 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
   Write(Html.LabelFor(m => m.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            <select name=\"Id\">\r\n");
#nullable restore
#line 11 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
                 foreach (var id in Model.IdList)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12ef045aebc906a28a681293244ce96b6ba055f64055", async() => {
#nullable restore
#line 13 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
                       Write(id);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </select>\r\n        </div>\r\n    </div>\r\n    <div>\r\n        ");
#nullable restore
#line 19 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
   Write(Html.LabelFor(m => m.TypeParking));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
#nullable restore
#line 21 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
       Write(Html.TextBoxFor(m => m.TypeParking));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div>\r\n        ");
#nullable restore
#line 25 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
   Write(Html.LabelFor(m => m.Dateentry));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            <input type=\"date\" id=\"datepicker\" name=\"Dateentry\" min=\"2000-01-01\" max=\"2022-01-01\" />\r\n        </div>\r\n    </div>\r\n    <div>\r\n        ");
#nullable restore
#line 31 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
   Write(Html.LabelFor(m => m.Datedeparture));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            <input type=\"date\" id=\"datepicker\" name=\"Datedeparture\" min=\"2000-01-01\" max=\"2022-01-01\" />\r\n        </div>\r\n    </div>\r\n    <div>\r\n        ");
#nullable restore
#line 37 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
   Write(Html.LabelFor(m => m.CarsNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            <select name=\"CarsNumber\">\r\n");
#nullable restore
#line 40 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
                 foreach (var number in Model.CarsNumbers)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12ef045aebc906a28a681293244ce96b6ba055f67606", async() => {
#nullable restore
#line 42 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
                       Write(number);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 43 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </select>\r\n        </div>\r\n    </div>\r\n    <div>\r\n        ");
#nullable restore
#line 48 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
   Write(Html.LabelFor(m => m.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
#nullable restore
#line 50 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
       Write(Html.TextBoxFor(m => m.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div>\r\n        <div>\r\n            <input type=\"submit\" class=\"btn btn-default\" value=\"Изменить\" />\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 58 "C:\Users\GIMIDO\Downloads\WebApp (1)\WebApp\WebApp\Views\Parking\UpdateParking.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.Models.ParkingUpdateViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591