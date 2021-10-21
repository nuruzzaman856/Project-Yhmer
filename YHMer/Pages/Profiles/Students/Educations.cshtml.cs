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
    public class EducationsModel : PageModel
    {
        public EducationStudentsModel Education { get; set; }

        public List<CourseModel> Courses { get; set; }
        public async Task<ActionResult> OnGetAsync()
        {

            Education = new EducationStudentsModel();
            Courses = new List<CourseModel>();

            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();

            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            string url = "https://localhost:44309/EducationStudents/Student/Get";
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
                
                var Profile = await responseMessage.Content.ReadFromJsonAsync<EducationStudentsModel>();
                Education.IsStudentVerified = Profile.IsStudentVerified;
                Education.SchoolName = Profile.SchoolName;
                Education.EducationName = Profile.EducationName;
                Education.Points = Profile.Points;
                Education.StartDate = Profile.StartDate;
                Education.EndDate = Profile.EndDate;
                Education.About = Profile.About;
                Education.City = Profile.City;
                Education.Courses = Profile.Courses;

                return Page();
            }
            else
            {

                return RedirectToPage("/Profiles/Students/RegisterStudent");
            }
        }
    }
}
