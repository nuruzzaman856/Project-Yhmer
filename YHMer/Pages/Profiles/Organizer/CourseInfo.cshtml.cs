using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using YHmer.Models;

namespace YHmer.Pages.Profiles.Organizer
{
    public class CourseInfoModel : PageModel
    {
        public string LIAStatus { get; set; }
        public string LookingForEducators { get; set; }
        public string LookingForGuestLecturers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CourseId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string EducationId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SchoolId { get; set; }
        public CourseModel CourseModel { get; set; }
        public async Task<ActionResult> OnGet()
        {
            
            CourseModel = new CourseModel();
            
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();

            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            string url = "https://localhost:44309/Course/Get";
            var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"CourseId", CourseId }
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
                var Profile = await responseMessage.Content.ReadFromJsonAsync<CourseModel>();

                CourseModel.Name = Profile.Name;
                CourseModel.Location = Profile.Location;
                CourseModel.Points = Profile.Points;
                CourseModel.IsLiaCourses = Profile.IsLiaCourses;
                CourseModel.Id= Profile.Id;
                CourseModel.About = Profile.About;
                CourseModel.StartDate = Profile.StartDate;
                CourseModel.EndDate = Profile.EndDate;
                CourseModel.SearchingForEducators = Profile.SearchingForEducators;
                CourseModel.SearchingForGuestLecturer = Profile.SearchingForGuestLecturer;
                LookingForEducators = Profile.SearchingForEducators ? "Ja" : "Nej";
                LookingForGuestLecturers = Profile.SearchingForGuestLecturer ? "Ja" : "Nej";
                LIAStatus = Profile.IsLiaCourses ? "Ja" : "Nej";

                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}
