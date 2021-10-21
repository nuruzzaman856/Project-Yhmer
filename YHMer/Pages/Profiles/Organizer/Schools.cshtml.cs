using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using YHmer.Models;

namespace YHmer.Pages.Profiles.Organizer
{
    public class SchoolsModel : PageModel
    {
        public List<SchoolModel> ResponseMessageList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SchoolID { get; set; }
    
        public string userID { get; set; }
        public async Task<ActionResult> OnGet()
        {


            ResponseMessageList = new List<SchoolModel>();
            using (HttpClient client = new HttpClient())
            {
                var token = HttpContext.Session.GetString("_Token");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
                userID = _token.unique_name;

                Dictionary<string, dynamic> values = new Dictionary<string, dynamic>
                {
                };

                var payload = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(payload, Encoding.UTF8, "application/json");

                using (HttpResponseMessage httpResponse = await client.PostAsync("https://localhost:44309/School/GetAll", stringContent))
                {
                    var response = await httpResponse.Content.ReadFromJsonAsync<List<SchoolModel>>();
                    foreach (var school in response)
                    {
                        ResponseMessageList.Add(school);
                    }
                    return Page();
                }

            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var School = Request.Form["SelectedSchoolID"].ToArray();

            string deleteButton = Request.Form["deleteschool"];
            
            if (deleteButton != null)
            {
                var SchoolID = Request.Form["SelectedSchoolID"];
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
                string url = "https://localhost:44309/School/Delete";

                var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },
                    {"SchoolId", SchoolID  }
                 };

                HttpClient client = new HttpClient();
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToPage("../Organizer/Schools");
                    }
                    else
                    {
                        return Page();
                    }
                }
            }

            //else if(RedirectToInfo != null)
            //{
                
            //    HttpContext.Session.SetString("SchoolId", SchoolID);
            //    return RedirectToPage("../Organizer/SchoolInfo");
            //}
            //else if(setSchoolID != null)
            //{
            //    HttpContext.Session.SetString("SchoolId", SchoolID);
            //    return RedirectToPage("../Organizer/Educations");
            //}
            //else if (addSchool != null)
            //{
            //    return RedirectToPage("../Organizer/AddSchool");
            //}
            else
            {
                return Page();
            }
        }
    }
}
