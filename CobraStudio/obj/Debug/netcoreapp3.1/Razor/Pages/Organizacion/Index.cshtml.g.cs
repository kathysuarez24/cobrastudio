#pragma checksum "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\Organizacion\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37580788b1d422207793d1177c2695312701d394"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CobraStudio.Pages.Organizacion.Pages_Organizacion_Index), @"mvc.1.0.razor-page", @"/Pages/Organizacion/Index.cshtml")]
namespace CobraStudio.Pages.Organizacion
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
#line 1 "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\_ViewImports.cshtml"
using CobraStudio;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37580788b1d422207793d1177c2695312701d394", @"/Pages/Organizacion/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b3772b8f6ed82560cc6eb2948edc6125c33e592", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Organizacion_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\Organizacion\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>Organización</h4>\r\n<hr />\r\n<div>\r\n    <ul>\r\n");
#nullable restore
#line 12 "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\Organizacion\Index.cshtml"
         foreach (var jefe in @Model.OtraLista)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"jefe\">");
#nullable restore
#line 14 "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\Organizacion\Index.cshtml"
                        Write(jefe.NombreCompleto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 15 "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\Organizacion\Index.cshtml"
            if (jefe.InverseIdJefeNavigation != null && jefe.InverseIdJefeNavigation.Any())
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <ul>\r\n");
#nullable restore
#line 18 "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\Organizacion\Index.cshtml"
                     foreach (var empleado in jefe.InverseIdJefeNavigation)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"empleado\">");
#nullable restore
#line 20 "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\Organizacion\Index.cshtml"
                                        Write(empleado.NombreCompleto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 21 "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\Organizacion\Index.cshtml"
                        if (empleado.InverseIdJefeNavigation != null & empleado.InverseIdJefeNavigation.Any())
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <ul>\r\n");
#nullable restore
#line 24 "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\Organizacion\Index.cshtml"
                                 foreach (var item in empleado.InverseIdJefeNavigation)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"subordinado\">");
#nullable restore
#line 26 "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\Organizacion\Index.cshtml"
                                                   Write(item.NombreCompleto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 27 "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\Organizacion\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </ul>\r\n");
#nullable restore
#line 29 "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\Organizacion\Index.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n");
#nullable restore
#line 32 "C:\Users\Daniel\source\repos\CobraStudio\CobraStudio\Pages\Organizacion\Index.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </ul>
</div>

<style>
    ul {
        //list-style-type: none;
        margin: 0;
        padding: 0;
    }

    li {
        margin: 0;
        padding: 0;
    }

    .jefe {
        font-weight: bold;
    }

    .empleado {
        margin-left: 30px;
    }

    .subordinado {
        margin-left: 60px;
    }
</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CobraStudio.Pages.Organizacion.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CobraStudio.Pages.Organizacion.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CobraStudio.Pages.Organizacion.IndexModel>)PageContext?.ViewData;
        public CobraStudio.Pages.Organizacion.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
