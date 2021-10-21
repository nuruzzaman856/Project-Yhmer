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
    public class AddSchoolModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Orgnr { get; set; }
        [BindProperty]
        public string ContactPerson { get; set; }
        [BindProperty]
        public string Contacts { get; set; }
        [BindProperty]
        public string StreetAdress { get; set; }
        [BindProperty]
        public string PostalArea { get; set; }
        [BindProperty]
        public string PostalCode { get; set; }
        [BindProperty]
        public string City { get; set; }
        [BindProperty]
        public string About { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SchoolId { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            
            if (SchoolId != null)
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

                    var school = responseMessage.Content.ReadFromJsonAsync<SchoolModel>();

                    Name = school.Result.Name;
                    Orgnr = school.Result.Orgnr;
                    ContactPerson = school.Result.ContactPerson;
                    Contacts = school.Result.Contacts;
                    PostalArea = school.Result.PostalArea;
                    PostalCode = school.Result.PostalCode;
                    City = school.Result.City;
                    About = school.Result.About;
                    StreetAdress = school.Result.StreetAdress;

                    return Page();
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                return Page();
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
           
            if (SchoolId != null)
            {
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var url = "https://localhost:44309/School/Update";
                    var values = new Dictionary<string, dynamic>
                        {
                           {"UserId", _token.unique_name },
                           {"SchoolId", SchoolId },
                           {"Name", Name },
                           {"Orgnr", Orgnr },
                           {"ContactPerson", ContactPerson },
                           {"Contacts", Contacts },
                           {"StreetAdress", StreetAdress},
                           {"PostalCode", PostalCode },
                           {"PostalArea", PostalArea },
                           {"City", City },
                           {"About", About }

                        };
                    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                    {

                        return RedirectToPage("../Organizer/Schools");
                    }
                }
            }
            else
            {
                string token = HttpContext.Session.GetString("_Token");

                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var url = "https://localhost:44309/School/Add";
                    var values = new Dictionary<string, dynamic>
                        {
                           {"UserId", _token.unique_name },
                           {"SchoolId", SchoolId },
                           {"Name", Name },
                           {"Orgnr", Orgnr },
                           {"ContactPerson", ContactPerson },
                           {"Contacts", Contacts },
                           {"StreetAdress", StreetAdress},
                           {"PostalCode", PostalCode },
                           {"PostalArea", PostalArea },
                           {"City", City },
                           {"About", About }

                        };
                    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                    {

                        return RedirectToPage("../Organizer/Schools");
                    }
                }


            }
        }
    }
}
