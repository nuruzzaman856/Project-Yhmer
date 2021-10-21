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
    public class SkillInfoModel : PageModel
    {
        public SkillModel SkillModel { get; set; }
        public string IsVerified { get; set; }


        public async Task<ActionResult> OnGet()
        {
            SkillModel = new SkillModel();

           
            string SkillId = HttpContext.Session.GetString("SkillId");
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();

            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            string url = "https://localhost:44309/Skill/Get";
            var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"SkillId", SkillId }
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
                
                var skill = responseMessage.Content.ReadFromJsonAsync<SkillModel>();
                SkillModel.Name = skill.Result.Name;
                IsVerified = skill.Result.IsVerified ? "Ja" : "Nej";
                SkillModel.SkillLevel = skill.Result.SkillLevel;
                SkillModel.YearsOfSkill = skill.Result.YearsOfSkill;
                SkillModel.Created = skill.Result.Created;



                return Page();
            }
            else
            {
                return Page();
            }

        }
    }
}
