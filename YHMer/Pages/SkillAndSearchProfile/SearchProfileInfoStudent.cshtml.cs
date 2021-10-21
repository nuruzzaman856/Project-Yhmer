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
    public class SearchProfileInfoStudentModel : PageModel
    {
        public List<SearchSkillInfoModel> ResponseSkills = new List<SearchSkillInfoModel>();
        public string MakeProfileSearchable { get; set; }

        public string LookingForEmploymentAfterExam { get; set; }

        public string ViewMyGradsFromOrganizers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchProfilesId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UserId { get; set; }

        //public List<SkillModel> ResponseSkillList = new List<SkillModel>();

        public SearchProfileInfoModel searchProfileInfoModel { get; set; }
        public async Task<ActionResult> OnGet()
        {
           
            searchProfileInfoModel = new SearchProfileInfoModel();

            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();

            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
          
            string url = "https://localhost:44309/SearchProfile/Student/Get";
            var values = new Dictionary<string, string>
                 {
                 };
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            request.Content = stringContent;
            HttpResponseMessage responseMessage = await client.SendAsync(request);
           
            if (responseMessage.IsSuccessStatusCode)
            {
                var SearchProfile = await responseMessage.Content.ReadFromJsonAsync<SearchProfileInfoModel>();


                searchProfileInfoModel.id = SearchProfile.id;
                searchProfileInfoModel.yearsOfExprienceInCompany = SearchProfile.yearsOfExprienceInCompany;
                //searchProfileInfoModel.SkillLevel = SearchProfile.Result.SkillLevel;
                //searchProfileInfoModel.SkillName = SearchProfile.Result.SkillName;
                searchProfileInfoModel.Area = SearchProfile.Area;
                searchProfileInfoModel.freeTextDescription = SearchProfile.freeTextDescription;
                MakeProfileSearchable = SearchProfile.makeProfileSearchable ? "Ja" : "Nej";
                LookingForEmploymentAfterExam = SearchProfile.lookingForEmploymentAfterExam? "Ja" : "Nej";
                ViewMyGradsFromOrganizers = SearchProfile.viewMyGradsFromOrganizers? "Ja" : "Nej";
               // searchProfileInfoModel.Skills = SearchProfile.Result.Skills;
                if (SearchProfile.skills != null || SearchProfile.skills.Length != 0)
                {
                    //foreach (var skill in SearchProfile.skills)
                    //{
                    //    ResponseSkills.Add(new SearchSkillInfoModel
                    //    {
                    //        name = skill.name,
                    //        skillLevel = skill.skillLevel,
                    //        yearsOfExperience = skill.yearsOfExperience


                    //    });
                    //}
                    for (int i = 0; i < SearchProfile.skills.Length; i++)
                    {
                        ResponseSkills.Add(new SearchSkillInfoModel
                        {
                            name = SearchProfile.skills[i].name,
                            skillLevel = SearchProfile.skills[i].skillLevel,
                            yearsOfExperience = SearchProfile.skills[i].yearsOfExperience,
                            IsVerified = SearchProfile.skills[i].IsVerified


                        });

                    }

                }
                //ResponseSkillList.Add(new SearchSkillInfoModel
                //{
                //    Name = SearchProfile.Result.SkillName,
                //    SkillLevel = SearchProfile.Result.SkillLevel,
                //    YearsOfExperience = SearchProfile.Result.YearsOfExperience
                //});

                return Page();
            }
            else
            {
                return RedirectToPage("../SkillAndSearchProfile/SearchProfile");
            }
        }


        public async Task<ActionResult> OnPostAsync()
        {


            string SearchProfileId = Request.Form["SelectButton"];
            if (Request.Form["UpdateSearchProfile"] == "UpdateSearchProfile")
            {
                HttpContext.Session.SetString("SearchProfileId", SearchProfileId);
                return RedirectToPage("../SkillAndSearchProfile/UpdateSearchProfile");
            }
            else 
            {
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
                string url = "https://localhost:44309/SearchProfile/Student/Delete";

                var values = new Dictionary<string, string>
                 {
                    {"SearchProfileId", SearchProfileId  }
                 };

                HttpClient client = new HttpClient();
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToPage("../Profiles/Profile");
                    }
                    else
                    {
                        return Page();
                    }
                }

            }


            
        }


    }



}

