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
    public class SkillsModel : PageModel
    {


        public class SkillModel
        {

            public string Id { get; set; }

            public string Name { get; set; }
            public bool IsVerified { get; set; }
            public string SkillLevel { get; set; }
            public int YearsOfSkill { get; set; }

            public DateTime Created { get; set; }



        }

        public List<SkillModel> receivedSkills = new List<SkillModel>();
        public string ProfileRole { get; set; }
        public async Task<ActionResult> OnGet()
        {
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();

            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            ProfileRole = _token.Role;

            string url = "https://localhost:44309/Skill/GetAll";
            var values = new Dictionary<string, string>
                 {
                    {"userId", _token.unique_name }
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


                var skills = responseMessage.Content.ReadFromJsonAsync<List<SkillModel>>();

                foreach (var skill in skills.Result)
                {
                    receivedSkills.Add(skill);
                }

                client.Dispose();
                return Page();
            }


            return Page();
        }

        public async Task<ActionResult> OnPost()
        {


            string SkillId = Request.Form["SelectButton"];
            //var test = Request.Form["AddSkillDirector"];
            //string test2 = Request.Form["ReDirectToInfo"];

            if (Request.Form["AddSkillDirector"] == "AddSkill")
            {
                return RedirectToPage("../SkillAndSearchProfile/AddSkill");
            }

            else if (Request.Form["ReDirectToInfo"] == "RedirectToInfo")
            {
                HttpContext.Session.SetString("SkillId", SkillId);
                return RedirectToPage("../SkillAndSearchProfile/SkillInfo");

            }

            else
            {


                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
                string url = "https://localhost:44309/Skill/Delete";




                var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"SkillId", SkillId  }
                 };

                HttpClient client = new HttpClient();
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToPage("../SkillAndSearchProfile/Skills");
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
