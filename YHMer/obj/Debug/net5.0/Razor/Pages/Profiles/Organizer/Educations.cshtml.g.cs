#pragma checksum "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d0a049b201143e38b3be48e1d7c66cc51426c2f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(YHMer.Pages.Profiles.Organizer.Pages_Profiles_Organizer_Educations), @"mvc.1.0.razor-page", @"/Pages/Profiles/Organizer/Educations.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d0a049b201143e38b3be48e1d7c66cc51426c2f", @"/Pages/Profiles/Organizer/Educations.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e68a82e306fd292509d86295eeb0b27c64aba7f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Profiles_Organizer_Educations : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_OrganizerSideBarPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("minibuttons"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
  
    int counter = 0;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\">\r\n\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-2 \">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4d0a049b201143e38b3be48e1d7c66cc51426c2f4665", async() => {
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
            <h1>Utbildningar</h1>
            <p class=""helptext"">Se mer om specifik utbildning via knappval.</p>
            <div class=""col-lg-12"">
                <div class=""main-box clearfix"">
                    <div class=""table-responsive"">

                        <table class=""table user-list"">
                            <thead>
                                <tr>
                                    <th><span>Namn</span></th>
                                    <th><span>Start datum</span></th>
                                    <th><span>Slut datum</span></th>
                                    <th><span>YH-Poäng</span></th>
                                    <th><span>LIA Kurs</span></th>
                                    <th><span>Söker styrelsemedlem</span></th>
                                    <th><span>Plats</span></th>
                                </tr>
                            </thead>
");
#nullable restore
#line 34 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                             foreach (var education in Model.recivedlistofEdu)
                            {
                                string ModalName = "MyName";
                                counter++;
                                string ModalId = $"{ModalName}{counter}";

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tbody>\r\n                                    <tr>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 42 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                                       Write(education.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 45 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                                       Write(education.StartDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 48 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                                       Write(education.EndDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 51 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                                       Write(education.Points);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n");
#nullable restore
#line 53 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                                         if (education.IsLiaCourses)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>\r\n                                                Ja\r\n                                            </td>\r\n");
#nullable restore
#line 58 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>\r\n                                                Nej\r\n                                            </td>\r\n");
#nullable restore
#line 64 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                                         if (education.SearchingForBoardMembers)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>\r\n                                                Ja\r\n                                            </td>\r\n");
#nullable restore
#line 70 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>\r\n                                               Nej\r\n                                            </td>\r\n");
#nullable restore
#line 76 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>\r\n                                            ");
#nullable restore
#line 78 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                                       Write(education.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d0a049b201143e38b3be48e1d7c66cc51426c2f11965", async() => {
                WriteLiteral("\r\n                                                <a");
                BeginWriteAttribute("href", " href=\"", 3928, "\"", 4019, 4);
                WriteAttributeValue("", 3935, "/Profiles/Organizer/EducationInfo?EducationId=", 3935, 46, true);
#nullable restore
#line 82 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
WriteAttributeValue("", 3981, education.ID, 3981, 13, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3994, "&SchoolId=", 3994, 10, true);
#nullable restore
#line 82 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
WriteAttributeValue("", 4004, Model.SchoolId, 4004, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""table-link strong"">
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d0a049b201143e38b3be48e1d7c66cc51426c2f14904", async() => {
                WriteLiteral("\r\n                                                <a");
                BeginWriteAttribute("href", " href=\"", 4668, "\"", 4758, 4);
                WriteAttributeValue("", 4675, "/Profiles/Organizer/AddEducation?EducationId=", 4675, 45, true);
#nullable restore
#line 91 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
WriteAttributeValue("", 4720, education.ID, 4720, 13, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4733, "&SchoolId=", 4733, 10, true);
#nullable restore
#line 91 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
WriteAttributeValue("", 4743, Model.SchoolId, 4743, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""table-link strong"">
                                                    <span class=""fa-stack"">
                                                        <i class=""fa fa-square fa-stack-2x""></i>
                                                        <i class=""fa fa-pencil fa-stack-1x fa-inverse""></i>
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
            WriteLiteral("\r\n\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d0a049b201143e38b3be48e1d7c66cc51426c2f17811", async() => {
                WriteLiteral("\r\n                                                <input");
                BeginWriteAttribute("value", " value=\"", 5382, "\"", 5403, 1);
#nullable restore
#line 100 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
WriteAttributeValue("", 5390, education.ID, 5390, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" hidden name=""SelectedEducationID"" />
                                                <input value=""Delete"" hidden name=""deleteeducation"" />

                                                <a href=""#"" class=""table-link danger"" data-toggle=""modal"" data-target=""#");
#nullable restore
#line 103 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                                                                                                                   Write(ModalId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""">
                                                    <span class=""fa-stack"">
                                                        <i class=""fa fa-square fa-stack-2x""></i>
                                                        <i class=""fa fa-times fa-stack-1x fa-inverse""></i>
                                                    </span>
                                                </a>

                                                <div class=""modal fade""");
                BeginWriteAttribute("id", " id=\"", 6152, "\"", 6165, 1);
#nullable restore
#line 110 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
WriteAttributeValue("", 6157, ModalId, 6157, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
                                                    <div class=""modal-dialog"" role=""document"">
                                                        <div class=""modal-content"">
                                                            <div class=""modal-header"">
                                                                <h5 class=""modal-title"" id=""exampleModalLabel"">Ta bort utbildning?</h5>
                                                                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                                                    <span aria-hidden=""true"">&times;</span>
                                                                </button>
                                                            </div>
                                                            <div class=""modal-body"">
                                                    ");
                WriteLiteral("            Vill du ta bort utbildningen \"");
#nullable restore
#line 120 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                                                                                         Write(education.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"""?
                                                            </div>
                                                            <div class=""modal-footer"">
                                                                <button type=""button"" class=""btn btn-primary"" data-dismiss=""modal"">Nej</button>
                                                                <button name=""delete"" type=""submit"" value=""Ja"" class=""btn btn-danger"">Ja</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n                                </tbody>\r\n");
#nullable restore
#line 134 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n    \r\n        <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 8343, "\"", 8407, 2);
            WriteAttributeValue("", 8350, "/Profiles/Organizer/AddEducation?SchoolId=", 8350, 42, true);
#nullable restore
#line 144 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
WriteAttributeValue("", 8392, Model.SchoolId, 8392, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Lägg till utbildning</a>\r\n    \r\n\r\n    <div class=\"box\">\r\n        <div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 152 "C:\Users\nuruz\Desktop\YHMERGitRep\yhmer\YHMer\Pages\Profiles\Organizer\Educations.cshtml"
                  await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("            ");
            }
            );
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<YHmer.Pages.Profiles.Organizer.EducationsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<YHmer.Pages.Profiles.Organizer.EducationsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<YHmer.Pages.Profiles.Organizer.EducationsModel>)PageContext?.ViewData;
        public YHmer.Pages.Profiles.Organizer.EducationsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
