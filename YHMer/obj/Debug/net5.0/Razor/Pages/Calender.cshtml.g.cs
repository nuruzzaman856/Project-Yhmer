#pragma checksum "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Calender.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b7d529517f67bdcbaf962bbde71a3c31e9c7ea3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(YHMer.Pages.Pages_Calender), @"mvc.1.0.razor-page", @"/Pages/Calender.cshtml")]
namespace YHMer.Pages
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
#line 1 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\_ViewImports.cshtml"
using YHMer;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b7d529517f67bdcbaf962bbde71a3c31e9c7ea3", @"/Pages/Calender.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e68a82e306fd292509d86295eeb0b27c64aba7f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Calender : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""container"">
    <div class=""card mb-3"">
        <div class=""card-body"">
            <div class=""row"">
                <div class=""col-sm-3"">
                    <h6 class=""mb-0"">Meetings Details</h6>
                </div>
            </div>
            <hr>
            <div class=""row"">
                <div class=""col-sm-3"">
                    <h6 class=""mb-0"">Meeting</h6>
                </div>
                <div class=""col-sm-6 text-secondary"">
                    2019-01-12
                </div>
                <div class=""col-sm-9"" style=""margin-top:-2rem;"">
                    <div style=""width : 1.5625rem; height: 1.5625rem; float:right"">
                        <input class=""form-check-input"" type=""checkbox"" style=""width : 1.5625rem; height: 1.5625rem; float:right""");
            BeginWriteAttribute("value", " value=\"", 831, "\"", 839, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckChecked"" checked>
                    </div>
                    <label for=""website"" class=""col-4 col-form-label""style=""float:right"">Remaind Me</label>
                </div>
            </div>
            <hr>
            <div class=""row"">
                <div class=""col-sm-3"">
                    <h6 class=""mb-0"">Meeting</h6>
                </div>
                <div class=""col-sm-6 text-secondary"">
                    2019-01-12
                </div>
                <div class=""col-sm-9"" style=""margin-top:-2rem;"">
                    <div style=""width : 1.5625rem; height: 1.5625rem; float:right"">
                        <input class=""form-check-input"" type=""checkbox"" style=""width : 1.5625rem; height: 1.5625rem; float:right""");
            BeginWriteAttribute("value", " value=\"", 1609, "\"", 1617, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckChecked"" checked>
                    </div>
                    <label for=""website"" class=""col-4 col-form-label"" style=""float:right"">Remaind Me</label>
                </div>
            </div>
            <hr>

        </div>
    </div>
    <hr>
    <div class=""form-group row"">
    </div>
</div>
<div id=""calendar""></div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.10.2/fullcalendar.min.css"" />
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.27.0/moment.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.10.2/fullcalendar.min.js""></script>
    <script>
        $(function () {
            $('#calendar').fullCalendar({
                defaultDate: '2019-01-12',
                editable: true,
                eventLimit: true,
                events: [
                    {
                        title: 'All Day Event',
                        start: '2019-01-01'
                    },
                    {
                        title: 'Long Event',
                        start: '2019-01-07',
                        end: '2019-01-10'
                    },
                    {
                        id: 999,
                        title: 'Repeating Event',
                        start: '2019-01-09T16");
                WriteLiteral(@":00:00'
                    },
                    {
                        id: 999,
                        title: 'Repeating Event',
                        start: '2019-01-16T16:00:00'
                    },
                    {
                        title: 'Conference',
                        start: '2019-01-11',
                        end: '2019-01-13'
                    },
                    {
                        title: 'Meeting',
                        start: '2019-01-12T10:30:00',
                        end: '2019-01-12T12:30:00'
                    },
                    {
                        title: 'Lunch',
                        start: '2019-01-12T12:00:00'
                    },
                    {
                        title: 'Meeting',
                        start: '2019-01-12T14:30:00'
                    },
                    {
                        title: 'Happy Hour',
                        start: '2019-01-12T17:30:00'
                 ");
                WriteLiteral(@"   },
                    {
                        title: 'Dinner',
                        start: '2019-01-12T20:00:00'
                    },
                    {
                        title: 'Birthday Party',
                        start: '2019-01-13T07:00:00'
                    },
                    {
                        title: 'Click for Google',
                        url: 'http://google.com/',
                        start: '2019-01-28'
                    }
                ]
            });
        });
    </script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_Calender> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Calender> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Calender>)PageContext?.ViewData;
        public Pages_Calender Model => ViewData.Model;
    }
}
#pragma warning restore 1591
