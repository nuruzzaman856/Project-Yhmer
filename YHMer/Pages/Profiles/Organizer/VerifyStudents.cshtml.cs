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
    public class VerifyStudentsModel : PageModel
    {
        [BindProperty]
        public List<StudentModel> UnverifiedStudents { get; set; }
        [BindProperty]
        public List<StudentModel> VerifiedStudents { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            UnverifiedStudents = new List<StudentModel>();
            VerifiedStudents = new List<StudentModel>();
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

            var url = "https://localhost:44309/EducationStudents/GetAll";
            var values = new Dictionary<string, string>
                 {
                    

                 };
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, stringContent);
            if (responseMessage.IsSuccessStatusCode == true)
            {
                var studentList = await responseMessage.Content.ReadFromJsonAsync<List<StudentModel>>();

                foreach (var student in studentList)
                {
                    if (student.IsVerified)
                    {
                        VerifiedStudents.Add(student);
                    }
                    else
                    {
                        UnverifiedStudents.Add(student);
                    }
                }
                client.Dispose();
                return Page();
            }
            client.Dispose();
            return Page();

        }
        public async Task<ActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(Request.Form["RemoveStudentId"]))
            {
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

                var url = "https://localhost:44309/EducationStudents/Remove";
                var values = new Dictionary<string, string>
                 {
                    {"StudentId", Request.Form["RemoveStudentId"] },
                    {"EducationId", Request.Form["RemoveStudentEducationId"] },
                 };
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(url, stringContent);
                if (responseMessage.IsSuccessStatusCode == true)
                {
                    client.Dispose();
                    return RedirectToPage("/Profiles/Organizer/VerifyStudents");

                }
                else
                {
                    client.Dispose();
                    return RedirectToPage("/Profiles/Organizer/VerifyStudents");
                }
            }
            else
            {
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

                var url = "https://localhost:44309/EducationStudents/Verify";
                var values = new Dictionary<string, string>
                 {
                    {"StudentId", Request.Form["VerifyStudentId"] },
                    {"EducationId", Request.Form["VerifyStudentEducationId"] },
                 };
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(url, stringContent);
                if (responseMessage.IsSuccessStatusCode == true)
                {
                    client.Dispose();
                    return RedirectToPage("/Profiles/Organizer/VerifyStudents");
                }
                else
                {
                    client.Dispose();
                    return RedirectToPage("/Profiles/Organizer/VerifyStudents");

                }
            }
        }
    }
}
