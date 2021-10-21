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

namespace YHmer.Pages.Admin
{
    public class SkillsModel : PageModel
    {
        [BindProperty]
        public List<Models.SkillModel> UnverifiedSkills { get; set; }
        [BindProperty]
        public List<Models.SkillModel> VerifiedSkills { get; set; }
        public async Task<ActionResult> OnGetAsync()
        {
            UnverifiedSkills = new List<Models.SkillModel>();
            VerifiedSkills = new List<Models.SkillModel>();
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

            var url = "https://localhost:44309/Skill/GetAll";
            var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },

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
                    if (skill.IsVerified)
                    {
                        VerifiedSkills.Add(skill);
                    }
                    else
                    {
                        UnverifiedSkills.Add(skill);
                    }
                }
                client.Dispose();
                return Page();
            }
            client.Dispose();
            return Page();

        }
        public async Task<ActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(Request.Form["DeleteSkill"]))
            {

                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

                var url = "https://localhost:44309/Skill/Delete";
                var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"SkillId", Request.Form["DeleteSkill"] },
                 };
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(url, stringContent);
                if (responseMessage.IsSuccessStatusCode == true)
                {
                    client.Dispose();
                    return RedirectToPage("/Admin/Skills");
                }
                else
                {
                    client.Dispose();
                    return RedirectToPage("/Admin/Skills");
                }
            }
            else
            {
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

                var url = "https://localhost:44309/Skill/Verify";
                var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"SkillId", Request.Form["VerifySkill"] },
                 };
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(url, stringContent);
                if (responseMessage.IsSuccessStatusCode == true)
                {
                    client.Dispose();
                    return RedirectToPage("/Admin/Skills");
                }
                else
                {
                    client.Dispose();
                    return RedirectToPage("/Admin/Skills");
                }
            }
        }

    }
}

