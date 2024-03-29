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

namespace YHmer.Pages.SearchProfile
{
    public class SearchProfileModel : PageModel
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

        public List<Models.SkillModel> VerifiedSkills { get; set; }

        //public async Task<ActionResult> OnGetAsync()
        //{
        //    string token = HttpContext.Session.GetString("_Token");
        //    var handler = new JwtSecurityTokenHandler();
        //    var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
        //    HttpClient client = new HttpClient();
        //    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        //    if (_token.unique_name.)
        //    {
        //        return Page();
        //    }

        //    else
        //    {
        //        return RedirectToPage("/Profiles/Profile");
        //    }


        //}


        public async Task<ActionResult> OnGetAsync()
        {
            VerifiedSkills = new List<Models.SkillModel>();
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

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
                client.Dispose();
                return Page();
            }
            client.Dispose();
            return Page();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            //var skill = Request.Form["SkillName"];

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

            MakeProfileSearchable = Request.Form["MakeProfileSearchable"].ToString().Contains("on") ? true : false;
            LookingForEmploymentAfterExam = Request.Form["LookingForEmploymentAfterExam"].ToString().Contains("on") ? true : false;
            ViewMyGradsFromOrganizers = Request.Form["ViewMyGradsFromOrganizers"].ToString().Contains("on") ? true : false;
            FreeTextDescription = Request.Form["FreeTextDescription"];
            YearsOfExprienceInCompany = default /*int.Parse(Request.Form["YearsOfExprienceInCompany"])*/;







            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                if (_token.Role == "student")
                {
                    var url = "https://localhost:44309/SearchProfile/Student/Add";
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
                        case AreaEnum.Area.Västerbotten:
                            area = "Västerbotten";
                            break;
                        case AreaEnum.Area.Jämtland:
                            area = "Jämtland";
                            break;
                        case AreaEnum.Area.Västernorrland:
                            area = "Västernorrland";
                            break;
                        case AreaEnum.Area.Gävleborg:
                            area = "Gävleborg";
                            break;
                        case AreaEnum.Area.Dalarna:
                            area = "Dalarna";
                            break;
                        case AreaEnum.Area.Värmland:
                            area = "Värmland";
                            break;
                        case AreaEnum.Area.Uppsala:
                            area = "Uppsala";
                            break;
                        case AreaEnum.Area.Västmanland:
                            area = "Västmanland";
                            break;
                        case AreaEnum.Area.Stockholm:
                            area = "Stockholm";
                            break;
                        case AreaEnum.Area.Södermanland:
                            area = "Södermanland";
                            break;
                        case AreaEnum.Area.Jönköping:
                            area = "Jönköping";
                            break;
                        case AreaEnum.Area.Örebro:
                            area = "Örebro";
                            break;
                        case AreaEnum.Area.Östergötaland:
                            area = "Östergötaland";
                            break;
                        case AreaEnum.Area.Västragötaland:
                            area = "Västragötaland";
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
                        case AreaEnum.Area.Skåne:
                            area = "Skåne";
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
                       {"MakeProfileSearchable",  MakeProfileSearchable },
                       {"LookingForEmploymentAfterExam", LookingForEmploymentAfterExam },
                       {"ViewMyGradsFromOrganizers",  ViewMyGradsFromOrganizers },
                       {"FreeTextDescription",  FreeTextDescription },
                       {"YearsOfExprienceInCompany",  YearsOfExprienceInCompany },
                        { "Area", area},
                       { "skills" ,skills }


                    };
                    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            return RedirectToPage("../SkillAndSearchProfile/SearchProfileInfoStudent");
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
