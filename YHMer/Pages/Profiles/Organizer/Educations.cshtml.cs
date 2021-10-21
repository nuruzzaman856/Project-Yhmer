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
    public class EducationsModel : PageModel
    {

        public List<EducationModel> recivedlistofEdu = new List<EducationModel>();

        [BindProperty(SupportsGet = true)]
        public string SchoolId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string EducationId { get; set; }

        public async Task <ActionResult> OnGet()
        {
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();

            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            string url = "https://localhost:44309/Education/GetAll";
            var values = new Dictionary<string, string>
                 {
                    {"userId", _token.unique_name },
                    {"SchoolId", SchoolId }
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
                

                var Profile = responseMessage.Content.ReadFromJsonAsync<List<EducationModel>>();
              
                foreach (var education in Profile.Result)
                {
                    recivedlistofEdu.Add(education);
                }

                    client.Dispose();
                return Page();
            }


            return Page();
        }

        public async Task<ActionResult> OnPost()
        {

          
                var EducationID = Request.Form["SelectedEducationID"];
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
                string url = "https://localhost:44309/Education/Delete";

                var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"EducationId", EducationID  }
                 };

                HttpClient client = new HttpClient();
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToPage("../Organizer/Educations", new { SchoolId = SchoolId });
                }
                    else
                    {
                        return Page();
                    }
                }
        }


    }   
}

