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
    public class ReplaceSkillModel : PageModel
    {
        public List<Models.SkillModel> VerifiedSkills { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Skill { get; set; }
        public async Task<ActionResult> OnGetAsync()
        {
            VerifiedSkills = new List<Models.SkillModel>();
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

            var url = "https://localhost:44309/Skill/GetAllVerifed";
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
            VerifiedSkills = new List<Models.SkillModel>();
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

            var url = "https://localhost:44309/Skill/Replace";
            var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"NewSkillName", Request.Form["ReplaceSkill"] },
                    {"OldSkillName", Skill },
                 };
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, stringContent);
            if (responseMessage.IsSuccessStatusCode == true)
            {
                var skills = responseMessage.Content.ReadFromJsonAsync<List<SkillModel>>();
                return RedirectToPage("/Admin/Skills");
            }
            client.Dispose();
            return RedirectToPage("/Admin/ReplaceSkill", new 
            {
                Skill = Skill
            });
        }
    }
}
