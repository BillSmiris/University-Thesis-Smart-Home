#pragma checksum "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\App.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39b2620bd15f03f6254cbebc3dd3ad3012e4ad66"
// <auto-generated/>
#pragma warning disable 1591
namespace SmartHome.Client
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using SmartHome.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using SmartHome.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using SmartHome.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Blazored;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using SmartHome.Client.Services;

#line default
#line hidden
#nullable disable
    public partial class App : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState>(0);
            __builder.AddAttribute(1, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Blazored.Modal.CascadingBlazoredModal>(2);
                __builder2.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Microsoft.AspNetCore.Components.Routing.Router>(4);
                    __builder3.AddAttribute(5, "AppAssembly", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Reflection.Assembly>(
#nullable restore
#line 3 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\App.razor"
                              typeof(Program).Assembly

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(6, "PreferExactMatches", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 3 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\App.razor"
                                                                             true

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(7, "Found", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.RouteData>)((routeData) => (__builder4) => {
                        __builder4.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView>(8);
                        __builder4.AddAttribute(9, "RouteData", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.RouteData>(
#nullable restore
#line 5 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\App.razor"
                                                routeData

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(10, "DefaultLayout", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Type>(
#nullable restore
#line 5 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\App.razor"
                                                                           typeof(MainLayout)

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.AddAttribute(11, "NotFound", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<Microsoft.AspNetCore.Components.LayoutView>(12);
                        __builder4.AddAttribute(13, "Layout", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Type>(
#nullable restore
#line 8 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\App.razor"
                                     typeof(MainLayout)

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(14, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddMarkupContent(15, "<p>Sorry, there\'s nothing at this address.</p>");
                        }
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
