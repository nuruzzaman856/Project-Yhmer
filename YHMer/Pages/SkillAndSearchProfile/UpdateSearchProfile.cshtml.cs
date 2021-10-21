using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using YHmer.Models;

namespace YHmer.Pages.SkillAndSearchProfile
{
    public class UpdateSearchProfileModel : PageModel
    {
        [BindProperty]
        public int Area { get; set; }
        [BindProperty]
        public bool MakeProfileSearchable { get; set; }
        [BindProperty]
        public bool LookingForEmploymentAfterExam { get; set; }
        [BindProperty]
        public bool ViewMyGradsFromOrganizers { get; set; }
        [BindProperty]
        public string FreeTextDescription { get; set; }
        [BindProperty]
        public int YearsOfExprienceInCompany { get; set; }
        [BindProperty]
        public string SkillName { get; set; }
        [BindProperty]
        public string SkillLevel { get; set; }
        [BindProperty]
        public int YearsOfExperience { get; set; }
        public List<SkillModel> Skills { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string SearchProfilesId { get; set; }


        public List<SearchSkillInfoModel> ResponseSkills = new List<SearchSkillInfoModel>();
       

        public SearchProfileInfoModel searchProfileInfoModel { get; set; }

        public List<Models.SkillModel> VerifiedSkills { get; set; }

        //public async Task<ActionResult> OnGetAsync()
        //{
        //    SearchProfilesId = HttpContext.Session.GetString("SearchProfileId");

        //    searchProfileInfoModel = new SearchProfileInfoModel();

        //    string token = HttpContext.Session.GetString("_Token");
        //    var handler = new JwtSecurityTokenHandler();

        //    var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

        //    string url = "https://localhost:44309/SearchProfile/Student/Get";
        //    var values = new Dictionary<string, string>
        //         {
        //            {"UserId", _token.unique_name }
        //         };
        //    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
        //    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        //    var request = new HttpRequestMessage(HttpMethod.Post, url);
        //    HttpClient client = new HttpClient();
        //    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        //    request.Content = stringContent;
        //    HttpResponseMessage responseMessage = await client.SendAsync(request);

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var SearchProfile = await responseMessage.Content.ReadFromJsonAsync<SearchProfileInfoModel>();


        //        searchProfileInfoModel.id = SearchProfile.id;
        //        searchProfileInfoModel.yearsOfExprienceInCompany = SearchProfile.yearsOfExprienceInCompany;
        //        //searchProfileInfoModel.SkillLevel = SearchProfile.Result.SkillLevel;
        //        //searchProfileInfoModel.SkillName = SearchProfile.Result.SkillName;
        //        searchProfileInfoModel.freeTextDescription = SearchProfile.freeTextDescription;
        //        MakeProfileSearchable = SearchProfile.makeProfileSearchable ? "Ja" : "Nej";
        //        LookingForEmploymentAfterExam = SearchProfile.lookingForEmploymentAfterExam ? "Ja" : "Nej";
        //        ViewMyGradsFromOrganizers = SearchProfile.viewMyGradsFromOrganizers ? "Ja" : "Nej";
        //        // searchProfileInfoModel.Skills = SearchProfile.Result.Skills;
        //        if (SearchProfile.skills != null || SearchProfile.skills.Length != 0)
        //        {
        //            //foreach (var skill in SearchProfile.skills)
        //            //{
        //            //    ResponseSkills.Add(new SearchSkillInfoModel
        //            //    {
        //            //        name = skill.name,
        //            //        skillLevel = skill.skillLevel,
        //            //        yearsOfExperience = skill.yearsOfExperience


        //            //    });
        //            //}
        //            for (int i = 0; i < SearchProfile.skills.Length; i++)
        //            {
        //                ResponseSkills.Add(new SearchSkillInfoModel
        //                {
        //                    name = SearchProfile.skills[i].name,
        //                    skillLevel = SearchProfile.skills[i].skillLevel,
        //                    yearsOfExperience = SearchProfile.skills[i].yearsOfExperience


        //                });

        //            }

        //        }
        //        //ResponseSkillList.Add(new SearchSkillInfoModel
        //        //{
        //        //    Name = SearchProfile.Result.SkillName,
        //        //    SkillLevel = SearchProfile.Result.SkillLevel,
        //        //    YearsOfExperience = SearchProfile.Result.YearsOfExperience
        //        //});

        //        return Page();
        //    }
        //    else
        //    {
        //        return RedirectToPage("../SkillAndSearchProfile/SearchProfile");
        //    }

        //}

        public async Task<ActionResult> OnGetAsync()
        {
            VerifiedSkills = new List<Models.SkillModel>();
            string token = HttpContext.Session.GetString("_Token");

            var url = "https://localhost:44309/Skill/GetAllVerifed";
            var values = new Dictionary<string, string>
                 {
                 };
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, stringContent);
            if (responseMessage.IsSuccessStatusCode == true)
            {
                var skills = responseMessage.Content.ReadFromJsonAsync<List<SkillModel>>();

                foreach (var skill in skills.Result)
                {
                    VerifiedSkills.Add(skill);
                }
            }


            Skills = new List<SkillModel>();
            searchProfileInfoModel = new SearchProfileInfoModel();

     
            url = "https://localhost:44309/SearchProfile/Student/Get";
            values = new Dictionary<string, string>
                 {
                 };
            json = JsonConvert.SerializeObject(values, Formatting.Indented);
            stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = stringContent;
            responseMessage = await client.SendAsync(request);

            if (responseMessage.IsSuccessStatusCode)
            {
                var SearchProfile = await responseMessage.Content.ReadFromJsonAsync<SearchProfileInfoModel>();
                searchProfileInfoModel.yearsOfExprienceInCompany = SearchProfile.yearsOfExprienceInCompany;
                searchProfileInfoModel.freeTextDescription = SearchProfile.freeTextDescription;
                MakeProfileSearchable = SearchProfile.makeProfileSearchable;
                LookingForEmploymentAfterExam = SearchProfile.lookingForEmploymentAfterExam;
                ViewMyGradsFromOrganizers = SearchProfile.viewMyGradsFromOrganizers;
                FreeTextDescription = SearchProfile.freeTextDescription;
                //Area = SearchProfile.Area;
                // searchProfileInfoModel.Skills = SearchProfile.Result.Skills;
                if (SearchProfile.skills != null || SearchProfile.skills.Length != 0)
                {
                    for (int i = 0; i < SearchProfile.skills.Length; i++)
                    {
                        Skills.Add(new SkillModel
                        {
                            Name = SearchProfile.skills[i].name,
                            SkillLevel = SearchProfile.skills[i].skillLevel,
                            YearsOfSkill = SearchProfile.skills[i].yearsOfExperience


                        });

                    }

                }

                return Page();
            }
            return Page();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            string SearchProfileId = HttpContext.Session.GetString("SearchProfileId");
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());


            var _skillName = Request.Form["SkillNameInput"];
            var _skillLevel = Request.Form["SkillLevelInput"];
            var _yearsOfExperience = Request.Form["Experience"];

            List<SearchSkillInfoModel> skills = new List<SearchSkillInfoModel>();

            for (int i = 0; i < _skillLevel.Count; i++)
            {
                skills.Add(new SearchSkillInfoModel
                {
                    name = _skillName[i],
                    skillLevel = _skillLevel[i],
                    yearsOfExperience = int.Parse(_yearsOfExperience[i])
                });
            }

            //MakeProfileSearchable = Request.Form["MakeProfileSearchable"].ToString().Contains("on") ? true : false;
            //LookingForEmploymentAfterExam = Request.Form["LookingForEmploymentAfterExam"].ToString().Contains("on") ? true : false;
            //ViewMyGradsFromOrganizers = Request.Form["ViewMyGradsFromOrganizers"].ToString().Contains("on") ? true : false;
            FreeTextDescription = Request.Form["FreeTextDescription"];
            //Area = Request.Form["Area"];
            YearsOfExprienceInCompany = default /*int.Parse(Request.Form["YearsOfExprienceInCompany"])*/;







            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                if (_token.Role == "student")
                {
                    var url = "https://localhost:44309/SearchProfile/Student/Update";
                    List<AddSkillsModel> AddSkill = new List<AddSkillsModel>();
                    AddSkill.Add(new AddSkillsModel
                    {
                        Name = SkillName,
                        SkillLevel = SkillLevel,
                        YearsOfExperience = YearsOfExperience
                    });
                    string area = "";
                    var _area = (AreaEnum.Area)Area;
                    switch (_area)
                    {
                        case AreaEnum.Area.Norrbotten:
                            area = "Norrbotten";
                            break;
                        case AreaEnum.Area.V�sterbotten:
                            area = "V�sterbotten";
                            break;
                        case AreaEnum.Area.J�mtland:
                            area = "J�mtland";
                            break;
                        case AreaEnum.Area.V�sternorrland:
                            area = "V�sternorrland";
                            break;
                        case AreaEnum.Area.G�vleborg:
                            area = "G�vleborg";
                            break;
                        case AreaEnum.Area.Dalarna:
                            area = "Dalarna";
                            break;
                        case AreaEnum.Area.V�rmland:
                            area = "V�rmland";
                            break;
                        case AreaEnum.Area.Uppsala:
                            area = "Uppsala";
                            break;
                        case AreaEnum.Area.V�stmanland:
                            area = "V�stmanland";
                            break;
                        case AreaEnum.Area.Stockholm:
                            area = "Stockholm";
                            break;
                        case AreaEnum.Area.S�dermanland:
                            area = "S�dermanland";
                            break;
                        case AreaEnum.Area.J�nk�ping:
                            area = "J�nk�ping";
                            break;
                        case AreaEnum.Area.�rebro:
                            area = "�rebro";
                            break;
                        case AreaEnum.Area.�sterg�taland:
                            area = "�sterg�taland";
                            break;
                        case AreaEnum.Area.V�strag�taland:
                            area = "V�strag�taland";
                            break;
                        case AreaEnum.Area.Kalmar:
                            area = "Kalmar";
                            break;
                        case AreaEnum.Area.Gotland:
                            area = "Gotland";
                            break;
                        case AreaEnum.Area.Halland:
                            area = "Halland";
                            break;
                        case AreaEnum.Area.Sk�ne:
                            area = "Sk�ne";
                            break;
                        case AreaEnum.Area.Blekinge:
                            area = "Blekinge";
                            break;
                        case AreaEnum.Area.Kronoberg:
                            area = "Kronoberg";
                            break;
                        default:
                            break;
                    }
                    var values = new Dictionary<string, dynamic>
                    {
                       {"SearchProfileId", SearchProfileId },
                       {"MakeProfileSearchable",  MakeProfileSearchable },
                       {"LookingForEmploymentAfterExam", LookingForEmploymentAfterExam },
                       {"ViewMyGradsFromOrganizers",  ViewMyGradsFromOrganizers },
                       {"FreeTextDescription",  FreeTextDescription },
                       {"YearsOfExprienceInCompany",  YearsOfExprienceInCompany },
                        {"Area", area },


                       { "skills" ,skills }


                    };
                    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            return RedirectToPage("/SkillAndSearchProfile/SearchProfileInfoStudent");
                        }
                        else
                        {
                            return Page();
                        }
                    }

                }

                else
                {
                    return Page();
                }


            }


        }

    }
}
