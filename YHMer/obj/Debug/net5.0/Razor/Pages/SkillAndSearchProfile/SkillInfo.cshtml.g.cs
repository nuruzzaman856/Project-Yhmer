#pragma checksum "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SkillInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72ada10f3a5e1073f960b85bff5d80f738dd0bab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(YHMer.Pages.SkillAndSearchProfile.Pages_SkillAndSearchProfile_SkillInfo), @"mvc.1.0.razor-page", @"/Pages/SkillAndSearchProfile/SkillInfo.cshtml")]
namespace YHMer.Pages.SkillAndSearchProfile
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72ada10f3a5e1073f960b85bff5d80f738dd0bab", @"/Pages/SkillAndSearchProfile/SkillInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e68a82e306fd292509d86295eeb0b27c64aba7f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_SkillAndSearchProfile_SkillInfo : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""container"">
    <div class=""row"">
        <div class=""col-xs-12 col-sm-9"">


            <div class=""panel panel-default"">
                <div class=""panel-heading"">
                    <h4 class=""panel-title"">
                    </h4>
                </div>
                <div class=""panel-body"">

                    <div class=""profile__header"">
                        <h4>");
#nullable restore
#line 20 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SkillInfo.cshtml"
                       Write(Model.SkillModel.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h4>
                    </div>
                </div>
            </div>


            <div class=""panel panel-default"">
                <div class=""panel-heading"">
                    <h4 class=""panel-title"">Kunskap information</h4>
                </div>
                <div class=""panel-body"">
                    <table class=""table profile__table"">
                        <tbody>
                            <tr>
                                <th>Kunskap Nivå</th>
                                <td>");
#nullable restore
#line 35 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SkillInfo.cshtml"
                               Write(Model.SkillModel.SkillLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <th>Är verifierad</th>\r\n                                <td>");
#nullable restore
#line 39 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SkillInfo.cshtml"
                               Write(Model.IsVerified);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <th>År av erfarenhet</th>\r\n                                <td>");
#nullable restore
#line 43 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SkillInfo.cshtml"
                               Write(Model.SkillModel.YearsOfSkill);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <th>Skapad</th>\r\n                                <td>");
#nullable restore
#line 47 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SkillInfo.cshtml"
                               Write(Model.SkillModel.Created.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                            </tr>


                        </tbody>
                    </table>
                </div>
            </div>


        </div>


    </div>
    <div>
        <a href=""../SkillAndSearchProfile/Skills"">Tillbaka</a>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<YHmer.Pages.SkillAndSearchProfile.SkillInfoModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<YHmer.Pages.SkillAndSearchProfile.SkillInfoModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<YHmer.Pages.SkillAndSearchProfile.SkillInfoModel>)PageContext?.ViewData;
        public YHmer.Pages.SkillAndSearchProfile.SkillInfoModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
