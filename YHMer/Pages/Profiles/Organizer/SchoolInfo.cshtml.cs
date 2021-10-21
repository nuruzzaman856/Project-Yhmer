using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace YHmer.Pages.Profiles.Organizer
{
    public class SchoolInfoModel : PageModel
    {
        public SchoolModel OutPut { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SchoolId { get; set; }

        public async Task <ActionResult> OnGetAsync()
        {
            string token = HttpContext.Session.GetString("_Token");
    
            string url = "https://localhost:44309/School/Get";
            var values = new Dictionary<string, string>
                 {
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
                OutPut = new SchoolModel();
                var school = responseMessage.Content.ReadFromJsonAsync<SchoolModel>();

                OutPut.Name = school.Result.Name;
                OutPut.Orgnr = school.Result.Orgnr;
                OutPut.ContactPerson = school.Result.ContactPerson;
                OutPut.Contacts = school.Result.Contacts;
                OutPut.PostalArea = school.Result.PostalArea;
                OutPut.PostalCode = school.Result.PostalCode;
                OutPut.City = school.Result.City;
                OutPut.About = school.Result.About;
                OutPut.StreetAdress = school.Result.StreetAdress;

                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}
