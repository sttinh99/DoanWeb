#pragma checksum "C:\Users\Quang Tinh\Desktop\WebBanGiay\TestCase11\TestCase\Views\Shared\_TableButtonPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b3ab0b0c255fcc6480b67651a81b7aa60efb4e93"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TableButtonPartial), @"mvc.1.0.view", @"/Views/Shared/_TableButtonPartial.cshtml")]
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
#line 1 "C:\Users\Quang Tinh\Desktop\WebBanGiay\TestCase11\TestCase\Views\_ViewImports.cshtml"
using TestCase;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Quang Tinh\Desktop\WebBanGiay\TestCase11\TestCase\Views\_ViewImports.cshtml"
using TestCase.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3ab0b0c255fcc6480b67651a81b7aa60efb4e93", @"/Views/Shared/_TableButtonPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"008400a0d54467f317cd45d1ebdd761865b28c43", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TableButtonPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <td style=\"width:150px\">\r\n        <div class=\"btn-group\" role=\"group\">\r\n            <a type=\"button\" class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 262, "\"", 314, 1);
#nullable restore
#line 7 "C:\Users\Quang Tinh\Desktop\WebBanGiay\TestCase11\TestCase\Views\Shared\_TableButtonPartial.cshtml"
WriteAttributeValue("", 269, Url.Action("Edit/"+Model).Replace("%2F","/"), 269, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fas fa-edit\"></i>\r\n            </a>\r\n");
            WriteLiteral("            <a type=\"button\" class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 595, "\"", 649, 1);
#nullable restore
#line 13 "C:\Users\Quang Tinh\Desktop\WebBanGiay\TestCase11\TestCase\Views\Shared\_TableButtonPartial.cshtml"
WriteAttributeValue("", 602, Url.Action("Delete/"+Model).Replace("%2F","/"), 602, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fas fa-trash-alt\"></i>\r\n            </a>\r\n        </div>\r\n    </td>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
