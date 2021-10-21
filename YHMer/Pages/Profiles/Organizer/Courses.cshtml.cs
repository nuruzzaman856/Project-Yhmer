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
    public class ManageCoursesModel : PageModel
    {
        public class GetAllCoursesModel
        {
            public string Name { get; set; }
            public string Period { get; set; }
            public string Id { get; set; }
            public int Points { get; set; }
            public bool IsLiaCourses { get; set; }
            public string Location { get; set; }
        }
        


        

        public List<GetAllCoursesModel> ResponseMessageList = new List<GetAllCoursesModel>();

        public async Task <ActionResult> OnGet()
        {
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            

            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            string url = "https://localhost:44309/Course/GetAll";

            var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"EducationId", HttpContext.Session.GetString("EducationId") }
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


                var Profile = responseMessage.Content.ReadFromJsonAsync<List<GetAllCoursesModel>>();

                foreach (var course in Profile.Result)
                {
                    ResponseMessageList.Add(course);
                }

                client.Dispose();
                return Page();
            }


            return Page();
        }

        public async Task <ActionResult> OnPost()
        {
            if (Request.Form["AddCourses"] == "Add Courses")
            {
                return RedirectToPage("../Organizer/AddCourses");
            }
            else
            {
                string CourseId;

                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
                string url = "https://localhost:44309/Course/Delete";

                CourseId = Request.Form["SelectedCourseID"];


                var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"CourseId", CourseId  }
                 };

                HttpClient client = new HttpClient();
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToPage("../Organizer/Courses");
                        //return Page(); //Buggen som förstörde 
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
