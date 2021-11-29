#pragma checksum "/Users/nicolaiskat/Projects/vagtplanen/Client/Components/AvailableShifts.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7077d0f9e02d8931d9b1cc2a2c0dd5e77306efeb"
// <auto-generated/>
#pragma warning disable 1591
namespace vagtplanen.Client.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/nicolaiskat/Projects/vagtplanen/Client/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/nicolaiskat/Projects/vagtplanen/Client/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/nicolaiskat/Projects/vagtplanen/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/nicolaiskat/Projects/vagtplanen/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/nicolaiskat/Projects/vagtplanen/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/nicolaiskat/Projects/vagtplanen/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/nicolaiskat/Projects/vagtplanen/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/nicolaiskat/Projects/vagtplanen/Client/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/nicolaiskat/Projects/vagtplanen/Client/_Imports.razor"
using vagtplanen.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/nicolaiskat/Projects/vagtplanen/Client/_Imports.razor"
using vagtplanen.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/nicolaiskat/Projects/vagtplanen/Client/_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/nicolaiskat/Projects/vagtplanen/Client/_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/availableshifts")]
    public partial class AvailableShifts : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Alle ledige vagter</h3>");
#nullable restore
#line 6 "/Users/nicolaiskat/Projects/vagtplanen/Client/Components/AvailableShifts.razor"
 if (shifts == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<p><em>Loading...</em></p>");
#nullable restore
#line 9 "/Users/nicolaiskat/Projects/vagtplanen/Client/Components/AvailableShifts.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Radzen.Blazor.RadzenDataGrid<Shift>>(2);
            __builder.AddAttribute(3, "AllowFiltering", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 12 "/Users/nicolaiskat/Projects/vagtplanen/Client/Components/AvailableShifts.razor"
                                    true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "AllowPaging", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 12 "/Users/nicolaiskat/Projects/vagtplanen/Client/Components/AvailableShifts.razor"
                                                       true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "AllowSorting", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 12 "/Users/nicolaiskat/Projects/vagtplanen/Client/Components/AvailableShifts.razor"
                                                                           true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "FilterCaseSensitivity", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterCaseSensitivity>(
#nullable restore
#line 12 "/Users/nicolaiskat/Projects/vagtplanen/Client/Components/AvailableShifts.razor"
                                                                                                        FilterCaseSensitivity.CaseInsensitive

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "Data", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<Shift>>(
#nullable restore
#line 13 "/Users/nicolaiskat/Projects/vagtplanen/Client/Components/AvailableShifts.razor"
                            shifts.Where(x => x.getTaken() == false)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "ColumnWidth", "300px");
            __builder.AddAttribute(9, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<Shift>>(10);
                __builder2.AddAttribute(11, "Property", "shift_id");
                __builder2.AddAttribute(12, "Title", "ID");
                __builder2.AddAttribute(13, "Width", "70px");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(14, "\n            ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<Shift>>(15);
                __builder2.AddAttribute(16, "Property", "description");
                __builder2.AddAttribute(17, "Title", "Beskrivelse");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(18, "\n            ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<Shift>>(19);
                __builder2.AddAttribute(20, "Property", "start_time");
                __builder2.AddAttribute(21, "Title", "Start tidspunkt");
                __builder2.AddAttribute(22, "FormatString", "{0:P}");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(23, "\n            ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<Shift>>(24);
                __builder2.AddAttribute(25, "Property", "end_time");
                __builder2.AddAttribute(26, "Title", "Slut tidspunkt");
                __builder2.AddAttribute(27, "FormatString", "{0:P}");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(28, "\n            ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<Shift>>(29);
                __builder2.AddAttribute(30, "Property", "job.area");
                __builder2.AddAttribute(31, "Title", "Jobområde");
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 22 "/Users/nicolaiskat/Projects/vagtplanen/Client/Components/AvailableShifts.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 24 "/Users/nicolaiskat/Projects/vagtplanen/Client/Components/AvailableShifts.razor"
       

    public Shift[] shifts;

    protected async override Task OnInitializedAsync()
    {
        shifts = await Http.GetFromJsonAsync<Shift[]>("api/shift");
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
