#pragma checksum "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\CourseInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8492a497f142f6c4dddecf653b1f2327be7094b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(YHMer.Pages.Profiles.Organizer.Pages_Profiles_Organizer_CourseInfo), @"mvc.1.0.razor-page", @"/Pages/Profiles/Organizer/CourseInfo.cshtml")]
namespace YHMer.Pages.Profiles.Organizer
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8492a497f142f6c4dddecf653b1f2327be7094b0", @"/Pages/Profiles/Organizer/CourseInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e68a82e306fd292509d86295eeb0b27c64aba7f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Profiles_Organizer_CourseInfo : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""container"">
    <div class=""row"">
        <div class=""col-xs-12 col-sm-9"">

            <!-- User profile -->
            <div class=""panel panel-default"">
                <div class=""panel-heading"">
                    <h4 class=""panel-title"">
");
            WriteLiteral("\r\n");
            WriteLiteral("                    </h4>\r\n                </div>\r\n                <div class=\"panel-body\">\r\n");
            WriteLiteral("                    <div class=\"profile__header\">\r\n                        <h4>");
#nullable restore
#line 30 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\CourseInfo.cshtml"
                       Write(Model.CourseModel.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <small>");
            WriteLiteral("</small></h4>\r\n                        <p class=\"text-muted\">\r\n                            ");
#nullable restore
#line 32 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\CourseInfo.cshtml"
                       Write(Model.CourseModel.About);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n");
            WriteLiteral(@"                    </div>
                </div>
            </div>

            <!-- User info -->
            <div class=""panel panel-default"">
                <div class=""panel-heading"">
                    <h4 class=""panel-title"">Kurs information</h4>
                </div>
                <div class=""panel-body"">
                    <table class=""table profile__table"">
                        <tbody>
                            <tr>
                                <th>Poäng</th>
                                <td>");
#nullable restore
#line 51 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\CourseInfo.cshtml"
                               Write(Model.CourseModel.Points);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <th>LIA</th>\r\n                                <td>");
#nullable restore
#line 55 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\CourseInfo.cshtml"
                               Write(Model.LIAStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <th>Start datum</th>\r\n                                <td>");
#nullable restore
#line 59 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\CourseInfo.cshtml"
                               Write(Model.CourseModel.StartDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <th>Slut datum</th>\r\n                                <td>");
#nullable restore
#line 63 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\CourseInfo.cshtml"
                               Write(Model.CourseModel.EndDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <th>Söker gäst föreläsare</th>\r\n                                <td>");
#nullable restore
#line 67 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\CourseInfo.cshtml"
                               Write(Model.LookingForGuestLecturers);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <th>Söker utbildare</th>\r\n                                <td>");
#nullable restore
#line 71 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\CourseInfo.cshtml"
                               Write(Model.LookingForEducators);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n\r\n           \r\n        </div>\r\n    </div>\r\n    <div>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 3254, "\"", 3343, 4);
            WriteAttributeValue("", 3261, "../Organizer/EducationInfo?SchoolId=", 3261, 36, true);
#nullable restore
#line 82 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\CourseInfo.cshtml"
WriteAttributeValue("", 3297, Model.SchoolId, 3297, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3312, "&EducationId=", 3312, 13, true);
#nullable restore
#line 82 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\CourseInfo.cshtml"
WriteAttributeValue("", 3325, Model.EducationId, 3325, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Tillbaka</a>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<YHmer.Pages.Profiles.Organizer.CourseInfoModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<YHmer.Pages.Profiles.Organizer.CourseInfoModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<YHmer.Pages.Profiles.Organizer.CourseInfoModel>)PageContext?.ViewData;
        public YHmer.Pages.Profiles.Organizer.CourseInfoModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
