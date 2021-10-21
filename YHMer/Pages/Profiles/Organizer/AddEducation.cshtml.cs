using System;
using System.Collections.Generic;
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
    public class AddEducationModel : PageModel
    {
        public string userId { get; set; }
        public string Role { get; set; }
        public string Name { get; set; } 
        public string Period { get; set; }
        public int Points { get; set; }
        [BindProperty]
        public bool IsLiaCourses { get; set; }
        public string City { get; set; }
        [BindProperty]
        public bool SearchingForBoardMembers { get; set; }
        [BindProperty]
        public DateTime StartDate { get; set; }
        [BindProperty]

        public DateTime EndDate { get; set; }
        [BindProperty]

        public DateTime LastDateForApplication { get; set; }
        public string YHNumber { get; set; }
        public string About { get; set; }


        [BindProperty(SupportsGet = true)]
        public string EducationId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SchoolId { get; set; }




        public async Task<ActionResult> OnGetAsync()
        {
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token); 

            if(EducationId != null)
            {
                string url = "https://localhost:44309/Education/Get";
                var values = new Dictionary<string, string>
                 {
                    {"EducationId", EducationId }
                 };
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = stringContent;
                HttpResponseMessage responseMessage = await client.SendAsync(request);

                if (responseMessage.IsSuccessStatusCode)
                {

                    var Education = await responseMessage.Content.ReadFromJsonAsync<EducationModel>();

                    Name = Education.Name;
                    City = Education.City;
                    StartDate = Education.StartDate;
                    EndDate = Education.EndDate;
                    LastDateForApplication = Education.LastDateForApplication;
                    IsLiaCourses = Education.IsLiaCourses;
                    YHNumber = Education.YHNumber;
                    About = Education.About;
                    Points = Education.Points;
                    SearchingForBoardMembers = Education.SearchingForBoardMembers;

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
                LastDateForApplication = DateTime.Now.Date;
                return Page();
            }
           
        }

        public async Task<ActionResult> OnPost()
        {
            if(EducationId != null)
            {
                string token = HttpContext.Session.GetString("_Token");

                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());


                Name = Request.Form["Name"];
                Period = Request.Form["Period"];
                Points = int.Parse(Request.Form["Points"]);
                City = Request.Form["City"];
                StartDate = DateTime.Parse(Request.Form["StartDate"]);
                EndDate = DateTime.Parse(Request.Form["EndDate"]);
                YHNumber = Request.Form["YHNumber"];
                LastDateForApplication = DateTime.Parse(Request.Form["LastDateForApplication"]);
                About = Request.Form["About"];

                


                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var url = "https://localhost:44309/Education/Update";
                    var values = new Dictionary<string, dynamic>
                    {
                       {"UserId", _token.unique_name },
                       {"EducationId", EducationId },
                       {"Name", Name },
                       {"Period", $"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}" },
                       {"Points", Points },
                       {"IsLiaCourses", IsLiaCourses},
                       {"City", City},
                       {"SearchingForBoardMembers", SearchingForBoardMembers },
                       {"StartDate", StartDate },
                       {"EndDate", EndDate },
                       {"YHNumber", YHNumber },
                       {"LastDateForApplication", LastDateForApplication },
                       {"About", About }
                    };
                    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
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
            else
            {
                string token = HttpContext.Session.GetString("_Token");

                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());


                Name = Request.Form["Name"];
                Period = Request.Form["Period"];
                Points = int.Parse(Request.Form["Points"]);
                City = Request.Form["City"];
                StartDate = DateTime.Parse(Request.Form["StartDate"]);
                EndDate = DateTime.Parse(Request.Form["EndDate"]);
                YHNumber = Request.Form["YHNumber"];
                LastDateForApplication = DateTime.Parse(Request.Form["LastDateForApplication"]);
                About = Request.Form["About"];



                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var url = "https://localhost:44309/Education/Add";
                    var values = new Dictionary<string, dynamic>
                    {
                       {"SchoolId", SchoolId },
                       {"Name", Name },
                       {"Period", Period },
                       {"Points", Points },
                       {"IsLiaCourses", IsLiaCourses},
                       {"City", City},
                       {"SearchingForBoardMembers", SearchingForBoardMembers },
                       {"StartDate", StartDate },
                       {"EndDate", EndDate },
                       {"YHNumber", YHNumber },
                       {"LastDateForApplication", LastDateForApplication },
                       {"About", About }
                    };
                    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
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
    }
}
