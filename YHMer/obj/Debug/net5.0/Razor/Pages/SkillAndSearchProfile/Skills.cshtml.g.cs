#pragma checksum "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c73ae4b7552f1f0388b3320f16617da3cd0bc91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(YHMer.Pages.SkillAndSearchProfile.Pages_SkillAndSearchProfile_Skills), @"mvc.1.0.razor-page", @"/Pages/SkillAndSearchProfile/Skills.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c73ae4b7552f1f0388b3320f16617da3cd0bc91", @"/Pages/SkillAndSearchProfile/Skills.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e68a82e306fd292509d86295eeb0b27c64aba7f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_SkillAndSearchProfile_Skills : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_StudentSideBarPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("minibuttons"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("DeleteCourse"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-2 \">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4c73ae4b7552f1f0388b3320f16617da3cd0bc914692", async() => {
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
            WriteLiteral(@"
        </div>
        <div class=""box"">
            <h1>Kunskap</h1>
            <p class=""helptext"">Se mer om specifik Kunskap via knappval.</p>
            <div class=""col-lg-12"">
                <div class=""main-box clearfix"">
                    <div class=""table-responsive"">

                        <table class=""table user-list"">
                            <thead>
                                <tr>
                                    <th><span>Namn</span></th>
                                    <th><span>Kunskap Nivå</span></th>
                                    <th><span>År av erfarenhet</span></th>
                                    <th><span>Är verifierad</span></th>
                                    <th><span>Skapad</span></th>
                                </tr>
                            </thead>
");
#nullable restore
#line 28 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml"
                             foreach (var skill in Model.receivedSkills)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tbody>\r\n                                    <tr>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 33 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml"
                                       Write(skill.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 36 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml"
                                       Write(skill.SkillLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 39 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml"
                                       Write(skill.YearsOfSkill);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n");
#nullable restore
#line 41 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml"
                                         if (skill.IsVerified)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>\r\n                                                Ja\r\n                                            </td>\r\n");
#nullable restore
#line 46 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>\r\n                                                Nej\r\n                                            </td>\r\n");
#nullable restore
#line 52 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>\r\n                                            ");
#nullable restore
#line 54 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml"
                                       Write(skill.Created);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c73ae4b7552f1f0388b3320f16617da3cd0bc919996", async() => {
                WriteLiteral("\r\n                                                <input");
                BeginWriteAttribute("value", " value=\"", 2663, "\"", 2680, 1);
#nullable restore
#line 58 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml"
WriteAttributeValue("", 2671, skill.Id, 2671, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" hidden name=""SelectButton"" />
                                                <input value=""RedirectToInfo"" hidden name=""ReDirectToInfo"" />
                                                <a class=""table-link info"" onclick=""this.parentElement.submit()"">
                                                    <span class=""fa-stack"" style=""color: #0366d6;"">
                                                        <i class=""fa fa-square fa-stack-2x""></i>
                                                        <i class=""fa fa-info-circle fa-stack-1x fa-inverse""></i>
                                                    </span>
                                                </a>

                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 68 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml"
                                             if (Model.ProfileRole == "root")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c73ae4b7552f1f0388b3320f16617da3cd0bc9113155", async() => {
                WriteLiteral("\r\n                                                    <input");
                BeginWriteAttribute("value", " value=\"", 3696, "\"", 3713, 1);
#nullable restore
#line 71 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml"
WriteAttributeValue("", 3704, skill.Id, 3704, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" hidden name=""SelectButton"" />
                                                    <a onclick=""this.parentElement.submit()"" href=""#"" class=""table-link danger"">
                                                        <span class=""fa-stack"">
                                                            <i class=""fa fa-square fa-stack-2x""></i>
                                                            <i class=""fa fa-times fa-stack-1x fa-inverse""></i>
                                                        </span>
                                                    </a>
                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 79 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n\r\n                                    </tr>\r\n                                </tbody>\r\n");
#nullable restore
#line 84 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\SkillAndSearchProfile\Skills.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c73ae4b7552f1f0388b3320f16617da3cd0bc9116533", async() => {
                WriteLiteral("\r\n        <button type=\"submit\" name=\"AddSkillDirector\" class=\"btn btn-primary\" value=\"AddSkill\">Lägg till Kunskup</button>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <hr />\r\n    <div>\r\n        <a href=\"../Profiles/Profile\">Tillbaka</a>\r\n    </div>\r\n\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<YHmer.Pages.SkillAndSearchProfile.SkillsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<YHmer.Pages.SkillAndSearchProfile.SkillsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<YHmer.Pages.SkillAndSearchProfile.SkillsModel>)PageContext?.ViewData;
        public YHmer.Pages.SkillAndSearchProfile.SkillsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
