#pragma checksum "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ca0019b0eba30e1293a8b4b9732396c55a5baba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(YHMer.Pages.SkillAndSearchProfile.Pages_SkillAndSearchProfile_SearchProfileInfoStudent), @"mvc.1.0.razor-page", @"/Pages/SkillAndSearchProfile/SearchProfileInfoStudent.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ca0019b0eba30e1293a8b4b9732396c55a5baba", @"/Pages/SkillAndSearchProfile/SearchProfileInfoStudent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e68a82e306fd292509d86295eeb0b27c64aba7f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_SkillAndSearchProfile_SearchProfileInfoStudent : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_StudentSideBarPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n\r\n    <div class=\"main-body\">\r\n        <div class=\"row \">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8ca0019b0eba30e1293a8b4b9732396c55a5baba4085", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            <div class=\"col-lg-6  mb-auto\">\r\n                <h4>Sök Profilinformation</h4>\r\n                <div class=\"card\">\r\n                    <div class=\"col-md-12\">\r\n\r\n                        <div class=\"panel panel-default\">\r\n");
            WriteLiteral(@"
                            <div class=""panel-body"">
                                <table class=""table profile__table"">
                                    <tbody>
                                        <tr>
                                            <th>Gör profil sökbar för LIA:</th>
                                            <td>");
#nullable restore
#line 27 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
                                           Write(Model.MakeProfileSearchable);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th>Söker anställning efter examen:</th>\r\n                                            <td>");
#nullable restore
#line 31 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
                                           Write(Model.LookingForEmploymentAfterExam);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n\r\n");
            WriteLiteral("                                        <tr>\r\n                                            <th>Visa mina betyg från anordnare:</th>\r\n                                            <td>");
#nullable restore
#line 40 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
                                           Write(Model.ViewMyGradsFromOrganizers);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th>Ort:</th>\r\n                                            <td>");
#nullable restore
#line 44 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
                                           Write(Model.searchProfileInfoModel.Area);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <th>Om:</th>\r\n                                            <td>");
#nullable restore
#line 48 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
                                           Write(Model.searchProfileInfoModel.freeTextDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n");
#nullable restore
#line 50 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
                                         if (Model.ResponseSkills != null)
                                        {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <tr>
                                                <th><span>Kunskap namn</span></th>
                                                <th><span>Verifierad</span></th>
                                                <th><span>Antal år</span></th>
                                                <th><span>Kunskap nivå</span></th>

                                            </tr>
");
#nullable restore
#line 60 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"

                                            foreach (var skill in Model.ResponseSkills)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n\r\n                                                    <td>");
#nullable restore
#line 65 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
                                                   Write(skill.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 67 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
                                                     if (skill.IsVerified)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td>Ja</td>\r\n");
#nullable restore
#line 70 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td>Nej</td>\r\n");
#nullable restore
#line 74 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                                    <td>");
#nullable restore
#line 77 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
                                                   Write(skill.yearsOfExperience);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                                    <td>");
#nullable restore
#line 79 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
                                                   Write(skill.skillLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                </tr>\r\n");
#nullable restore
#line 81 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"

                                            }
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                    </tbody>\r\n                                </table>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n\r\n                </div>\r\n\r\n\r\n            </div>\r\n\r\n");
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n        </div>\r\n\r\n\r\n        <div class=\"split left\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ca0019b0eba30e1293a8b4b9732396c55a5baba12605", async() => {
                WriteLiteral("\r\n                <input");
                BeginWriteAttribute("value", " value=\"", 4833, "\"", 4873, 1);
#nullable restore
#line 121 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
WriteAttributeValue("", 4841, Model.searchProfileInfoModel.id, 4841, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" hidden name=\"SelectButton\" />\r\n                <button type=\"submit\" name=\"UpdateSearchProfile\" class=\"btn btn-primary\" value=\"UpdateSearchProfile\">Update SökProfil Info</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"split right\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ca0019b0eba30e1293a8b4b9732396c55a5baba14764", async() => {
                WriteLiteral("\r\n                <input");
                BeginWriteAttribute("value", " value=\"", 5185, "\"", 5225, 1);
#nullable restore
#line 128 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
WriteAttributeValue("", 5193, Model.searchProfileInfoModel.id, 5193, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" hidden name=\"SelectButton\" />\r\n                <button type=\"submit\" name=\"DeleteSearchProfile\" class=\"btn btn-danger\"");
                BeginWriteAttribute("value", " value=\"", 5345, "\"", 5385, 1);
#nullable restore
#line 129 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\SearchProfileInfoStudent.cshtml"
WriteAttributeValue("", 5353, Model.searchProfileInfoModel.id, 5353, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Delete Sök Profile</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n\r\n\r\n\r\n\r\n\r\n    <hr />\r\n    <div>\r\n        <a href=\"../Profiles/Profile\" style=\" margin-left :auto\">Tillbaka</a>\r\n    </div>\r\n\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<YHmer.Pages.SkillAndSearchProfile.SearchProfileInfoStudentModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<YHmer.Pages.SkillAndSearchProfile.SearchProfileInfoStudentModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<YHmer.Pages.SkillAndSearchProfile.SearchProfileInfoStudentModel>)PageContext?.ViewData;
        public YHmer.Pages.SkillAndSearchProfile.SearchProfileInfoStudentModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
