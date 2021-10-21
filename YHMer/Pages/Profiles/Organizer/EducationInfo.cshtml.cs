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
    public class EducationInfoModel : PageModel
    {
        public string LIAStatus { get; set; }
        public string LookingForBoardMembersStatus { get; set; }
        public EducationModel Education { get; set; }

        public List<CourseModel> ResponseMessageList = new List<CourseModel>();

        [BindProperty(SupportsGet = true)]
        public string EducationId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SchoolId { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            Education = new EducationModel();
            
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();

            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            string url = "https://localhost:44309/Education/Get";
            var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"EducationId", EducationId }
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
                GetAllConnectedCourses();
                var Profile = await responseMessage.Content.ReadFromJsonAsync<EducationModel>();

                Education.Name = Profile.Name;
                Education.City = Profile.City;
                Education.Period = Profile.Period;
                Education.Points = Profile.Points;
                Education.IsLiaCourses = Profile.IsLiaCourses;
                Education.ID = Profile.ID;
                Education.About = Profile.About;
                Education.StartDate = Profile.StartDate;
                Education.EndDate = Profile.EndDate;
                Education.LastDateForApplication = Profile.LastDateForApplication;
                Education.SearchingForBoardMembers = Profile.SearchingForBoardMembers;
                Education.RegisterCode = Profile.RegisterCode;
                LookingForBoardMembersStatus = Profile.SearchingForBoardMembers ? "Ja" : "Nej";
                LIAStatus = Profile.IsLiaCourses ? "Ja" : "Nej";

                return Page();
            }
            else
            {
                return Page();
            }
        }

        public async Task<ActionResult> OnPostAsync()
        {
           
           if(Request.Form["DeleteCourse"] == "DeleteCourse")
           {
                var selectedId = Request.Form["SelectionButton"];
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
                string url = "https://localhost:44309/Course/Delete";

                var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"CourseId", selectedId }
                 };

                HttpClient client = new HttpClient();
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var ob = new { SchoolId = SchoolId, EducationId = EducationId };
                        return RedirectToPage("../Organizer/EducationInfo", ob);;
                    }
                    else
                    {
                        return Page();
                    }
                }
           }
            else
            {
                return Page();
            }
           
        }

        void GetAllConnectedCourses()
        {
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();


            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            string url = "https://localhost:44309/Course/GetAll";

            var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"EducationId", EducationId }
                 };

            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            request.Content = stringContent;
            HttpResponseMessage responseMessage = client.Send(request);

            if (responseMessage.IsSuccessStatusCode)
            {
                var Profile = responseMessage.Content.ReadFromJsonAsync<List<CourseModel>>();

                foreach (var course in Profile.Result)
                {
                    ResponseMessageList.Add(course);
                }
            }

        }

    }
 
}
