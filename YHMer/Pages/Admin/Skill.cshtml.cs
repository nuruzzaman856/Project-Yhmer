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
    public class EditSkillModel : PageModel
    {
        [BindProperty]
        public string SkillName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SkillId { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            if (SkillId != null)
            {

                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

                var url = "https://localhost:44309/Skill/Get";
                var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"SkillId", SkillId },
                 };
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(url, stringContent);
                if (responseMessage.IsSuccessStatusCode == true)
                {
                    var skill = await responseMessage.Content.ReadFromJsonAsync<SkillModel>();
                    SkillName = skill.Name;

                    client.Dispose();
                    return Page();

                }
                client.Dispose();
            }
            return Page();
        }
        public async Task<ActionResult> OnPostAsync()
        {
            if (SkillId != null)
            {
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

                var url = "https://localhost:44309/Skill/Edit";
                var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"SkillId", SkillId },
                    {"SkillName", Request.Form["Name"] },
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
                client.Dispose();
            }
            else
            {
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

                var url = "https://localhost:44309/Skill/Add/Admin";
                var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"Name", Request.Form["Name"] },
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
                client.Dispose();
            }
            return Page();
        }
    }
}
