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

namespace YHmer.Pages.Profiles.Organizer
{
    public class SearchProfileInfoModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string StudentId { get; set; }
        public UserProfileModel UserProfile { get; set; }
        public List <SkillModel> Skills { get; set; }

        public async Task<ActionResult> OnGet()
        {
            UserProfile = new UserProfileModel();
            Skills = new List<SkillModel>();
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
           
            string url = "https://localhost:44309/Profile/getcontext";
            var values = new Dictionary<string, string>
                 {
                    {"Id", StudentId }, 
                 };
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            request.Content = stringContent;
            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if (responseMessage.IsSuccessStatusCode)
            {
                var Profile = responseMessage.Content.ReadFromJsonAsync<UserProfileModel>();
                UserProfile.FirstName = Profile.Result.FirstName == null ? "" : Profile.Result.FirstName;
                UserProfile.LastName = Profile.Result.LastName == null ? "" : Profile.Result.LastName;
                UserProfile.email = Profile.Result.email == null ? "" : Profile.Result.email;
                UserProfile.About = Profile.Result.About == null ? "" : Profile.Result.About;
                UserProfile.phoneNumber = Profile.Result.phoneNumber == null ? "" : Profile.Result.phoneNumber;
                UserProfile.City = Profile.Result.City == null ? "" : Profile.Result.City;
                UserProfile.CompanyName = Profile.Result.CompanyName == null ? "" : Profile.Result.CompanyName;
                UserProfile.Adress = Profile.Result.Adress;
                UserProfile.ContactPerson = Profile.Result.ContactPerson;
                UserProfile.PostalCode = Profile.Result.PostalCode;
                UserProfile.PostalArea = Profile.Result.PostalArea;
            }
            else
            {
                client.Dispose();
                RedirectToPage("/Index");
            }

            url = "https://localhost:44309/Skill/GetAll";
            values = new Dictionary<string, string>
                 {
                    {"UserId", StudentId },

                 };
            json = JsonConvert.SerializeObject(values, Formatting.Indented);
            stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            responseMessage = await client.PostAsync(url, stringContent);
            if (responseMessage.IsSuccessStatusCode == true)
            {
                var skills = responseMessage.Content.ReadFromJsonAsync<List<SkillModel>>();

                foreach (var skill in skills.Result)
                {
                    Skills.Add(skill);
                }
            }
            else
            {
                client.Dispose();
                RedirectToPage("/Index");
            }

            client.Dispose();
            return Page();
        }
    }
}
