#pragma checksum "E:\c#\Asp.NetCoreTrnning\PowerShop\PowerShop\PowerShop\Views\Components\ProductGroupsComponent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5ec1da30d9a20a459f9eb36937f1f25c286dcc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Components_ProductGroupsComponent), @"mvc.1.0.view", @"/Views/Components/ProductGroupsComponent.cshtml")]
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
#line 1 "E:\c#\Asp.NetCoreTrnning\PowerShop\PowerShop\PowerShop\Views\_ViewImports.cshtml"
using PowerShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\c#\Asp.NetCoreTrnning\PowerShop\PowerShop\PowerShop\Views\_ViewImports.cshtml"
using PowerShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5ec1da30d9a20a459f9eb36937f1f25c286dcc6", @"/Views/Components/ProductGroupsComponent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a48506d65321d993f662b340320aab65d44f5114", @"/Views/_ViewImports.cshtml")]
    public class Views_Components_ProductGroupsComponent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShowGroupViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<ul class=\"list-group\">\r\n");
#nullable restore
#line 4 "E:\c#\Asp.NetCoreTrnning\PowerShop\PowerShop\PowerShop\Views\Components\ProductGroupsComponent.cshtml"
    foreach (var item in Model)
   {

#line default
#line hidden
#nullable disable
            WriteLiteral("       <li class=\"list-group-item d-flex justify-content-between align-items-center\">\r\n           <a");
            BeginWriteAttribute("href", " href=\"", 206, "\"", 244, 4);
            WriteAttributeValue("", 213, "/Group/", 213, 7, true);
#nullable restore
#line 7 "E:\c#\Asp.NetCoreTrnning\PowerShop\PowerShop\PowerShop\Views\Components\ProductGroupsComponent.cshtml"
WriteAttributeValue("", 220, item.GroupId, 220, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 233, "/", 233, 1, true);
#nullable restore
#line 7 "E:\c#\Asp.NetCoreTrnning\PowerShop\PowerShop\PowerShop\Views\Components\ProductGroupsComponent.cshtml"
WriteAttributeValue("", 234, item.Name, 234, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 7 "E:\c#\Asp.NetCoreTrnning\PowerShop\PowerShop\PowerShop\Views\Components\ProductGroupsComponent.cshtml"
                                                Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n           <span class=\"badge badge-primary badge-pill\">");
#nullable restore
#line 8 "E:\c#\Asp.NetCoreTrnning\PowerShop\PowerShop\PowerShop\Views\Components\ProductGroupsComponent.cshtml"
                                                   Write(item.productCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n       </li>\r\n");
#nullable restore
#line 10 "E:\c#\Asp.NetCoreTrnning\PowerShop\PowerShop\PowerShop\Views\Components\ProductGroupsComponent.cshtml"
       
   }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShowGroupViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
