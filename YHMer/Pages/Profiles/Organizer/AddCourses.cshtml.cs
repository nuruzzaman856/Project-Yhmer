using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Api.Areas.Identity.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using YHmer.Models;

namespace YHmer.Pages.Profiles.Organizer
{
    public class AddCoursesModel : PageModel
    {
        

        public string UserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string EducationId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CourseId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SchoolId { get; set; }
        public string Name { get; set; }
        public string Period { get; set; }
        public int Points { get; set; }
        public string Location { get; set; }

        [BindProperty]
        public bool IsLiaCourses { get; set; }
        [BindProperty]

        public bool SearchingForEducators { get; set; }
        [BindProperty]

        public bool SearchingForGuestLecturer { get; set; }
        
        [BindProperty]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [BindProperty]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string YHNumber { get; set; }
       
        public string About { get; set; }

      


        public async Task<IActionResult> OnGetAsync()
        {
            
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            if (CourseId != null)
            {
                string url = "https://localhost:44309/Course/Get";
                var values = new Dictionary<string, string>
                 {
                    {"EducationId", EducationId },
                    {"CourseId", CourseId }
                 };
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = stringContent;
                HttpResponseMessage responseMessage = await client.SendAsync(request);

                if (responseMessage.IsSuccessStatusCode)
                {

                    var Course = await responseMessage.Content.ReadFromJsonAsync<CourseModel>();

                    Name = Course.Name;
                    Location = Course.Location;
                    StartDate = Course.StartDate;
                    EndDate = Course.EndDate;
                    IsLiaCourses = Course.IsLiaCourses;
                    YHNumber = Course.YHNumber;
                    About = Course.About;
                    Points = Course.Points;
                    SearchingForEducators = Course.SearchingForEducators;
                    SearchingForGuestLecturer = Course.SearchingForGuestLecturer;
                   

                    return Page();
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                StartDate = DateTime.Now.Date;
                EndDate = DateTime.Now.Date;
                return Page();
            }




        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (CourseId != null)
            {

                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());


                Name = Request.Form["Name"];
                Period = Request.Form["Period"];
                Points = int.Parse(Request.Form["Points"]);
                Location = Request.Form["Location"];
                StartDate = DateTime.Parse(Request.Form["StartDate"]);
                EndDate = DateTime.Parse(Request.Form["EndDate"]);
                About = Request.Form["About"];

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var url = "https://localhost:44309/Course/Update";
                    var values = new Dictionary<string, dynamic>
                        {
                           {"EducationId", EducationId },
                           {"CourseId", CourseId },
                           {"UserId", _token.unique_name },
                           {"Name", Name },
                           {"Period", Period },
                           {"Points", Points },
                           {"IsLiaCourse", IsLiaCourses},
                           {"Location", Location},
                           {"SearchingForEducators", SearchingForEducators },
                           {"SearchingForGuestLecturer", SearchingForGuestLecturer},
                           {"StartDate", StartDate },
                           {"EndDate", EndDate },
                           {"About", About }

                        };
                    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            return RedirectToPage("../Organizer/EducationInfo", new { EducationId = EducationId, SchoolId = SchoolId });
                        }
                        else
                        {
                            return Page();
                        }
                    }

                }
            }

            else
            {
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

                bool q = SearchingForEducators;

                Name = Request.Form["Name"];
                Period = Request.Form["Period"];
                Points = int.Parse(Request.Form["Points"]);
                Location = Request.Form["Location"];
                StartDate = DateTime.Parse(Request.Form["StartDate"]);
                EndDate = DateTime.Parse(Request.Form["EndDate"]);
                About = Request.Form["About"];

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var url = "https://localhost:44309/Course/Add";
                    var values = new Dictionary<string, dynamic>
                        {
                           {"EducationId", EducationId },
                           {"UserId", _token.unique_name },
                           {"Name", Name },
                           {"Period", Period },
                           {"Points", Points },
                           {"IsLiaCourse", IsLiaCourses},
                           {"Location", Location},
                           {"SearchingForEducators", SearchingForEducators },
                           {"SearchingForGuestLecturer", SearchingForGuestLecturer},
                           {"StartDate", StartDate },
                           {"EndDate", EndDate },
                           {"About", About }

                        };
                    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            return RedirectToPage("../Organizer/EducationInfo", new { EducationId = EducationId, SchoolId = SchoolId });
                        }
                        else
                        {
                            return Page();
                        }
                    }
                }

            }
        }
    }

}