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

namespace YHmer.Pages.Profiles.Students
{
    public class RegistrationcodeClass
    {
        public string EducationRegistrationCode { get; set; }

    }
    public class RegisterStudentModel : PageModel
    {
        //[BindProperty]
        //public RegistrationcodeClass EducationRegistrationCode { get; set; }
        [BindProperty]
        public string EducationRegistrationCode { get; set; }
        public string UnsuccessfulErrorMessage { get; set; }
        public void OnGet()
        {
            UnsuccessfulErrorMessage = "";
        }

        public async Task<ActionResult> OnPostAsync()
        {
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();

            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            string url = "https://localhost:44309/EducationStudents/Add";
            var values = new Dictionary<string, string>
            {
                {
                    "EducationCode", EducationRegistrationCode
                }
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
                return RedirectToPage("/Profiles/Students/Educations");
            }
            else
            {
                UnsuccessfulErrorMessage = "Registrering misslyckades.";
                return Page();
            }
        }
    }
}
