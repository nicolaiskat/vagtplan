#pragma checksum "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d68aae616ce86032aeb6a96bea56056d1946485"
// <auto-generated/>
#pragma warning disable 1591
namespace vagtplanen.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 2 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/_Imports.razor"
using vagtplanen.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/_Imports.razor"
using vagtplanen.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
using vagtplanen.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
using BlazorPro.Spinkit;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 7 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
 if (page_access == -1)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<h1>Login her</h1>\n    ");
            __builder.OpenComponent<Radzen.Blazor.RadzenCard>(1);
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __Blazor.vagtplanen.Client.Pages.Login.TypeInference.CreateRadzenTemplateForm_0(__builder2, 3, 4, 
#nullable restore
#line 11 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
                                   "SimpleLogin"

#line default
#line hidden
#nullable disable
                , 5, (context) => (__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLogin>(6);
                    __builder3.AddAttribute(7, "AllowRegister", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 12 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
                                        false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(8, "AllowResetPassword", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 12 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
                                                                   false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(9, "Login", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Radzen.LoginArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Radzen.LoginArgs>(this, 
#nullable restore
#line 12 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
                                                                                  args => OnLogin(args)

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(10, "Style", "margin-bottom: 20px;");
                    __builder3.CloseComponent();
#nullable restore
#line 13 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
             if (isLoading) {

#line default
#line hidden
#nullable disable
                    __builder3.OpenComponent<BlazorPro.Spinkit.Chase>(11);
                    __builder3.CloseComponent();
#nullable restore
#line 13 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
                                        }

#line default
#line hidden
#nullable disable
                }
                );
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 16 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"

}
else if (page_access == 0)
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<vagtplanen.Client.Pages.VolunteerPage>(12);
            __builder.AddAttribute(13, "vol", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Volunteer>(
#nullable restore
#line 20 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
                         vol

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
#nullable restore
#line 21 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
}
else if (page_access == 1)
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<vagtplanen.Client.Pages.CoordinatorPage>(14);
            __builder.AddAttribute(15, "coor", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Coordinator>(
#nullable restore
#line 24 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
                            coor

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
#nullable restore
#line 25 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 27 "/Users/nicolaiskat/Projects/vagtplanen/vagtplanen/Client/Pages/Login.razor"
       
    public int page_access = -1;
    public bool isLoading = false;

    public Volunteer vol = new();
    public Coordinator coor = new();

    async Task OnLogin(LoginArgs args)
    {
        isLoading = true;
        try
        {
            int res = await Http.GetFromJsonAsync<int>($"api/method/login/{args.Username}/{args.Password}");
            if (res == 0)
            {
                vol = await Http.GetFromJsonAsync<Volunteer>($"api/volunteer/{args.Username}");
                isLoading = false;
                page_access = vol.access;
            }
            else if (res == 1)
            {
                coor = await Http.GetFromJsonAsync<Coordinator>($"api/coordinator/{args.Username}");
                page_access = coor.access;
                isLoading = false;
            }
        }
        catch (Exception e)
        {
            isLoading = false;
            Console.WriteLine(e.Message);
        }

    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
namespace __Blazor.vagtplanen.Client.Pages.Login
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateRadzenTemplateForm_0<TItem>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TItem __arg0, int __seq1, global::Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext> __arg1)
        {
        __builder.OpenComponent<global::Radzen.Blazor.RadzenTemplateForm<TItem>>(seq);
        __builder.AddAttribute(__seq0, "Data", __arg0);
        __builder.AddAttribute(__seq1, "ChildContent", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
