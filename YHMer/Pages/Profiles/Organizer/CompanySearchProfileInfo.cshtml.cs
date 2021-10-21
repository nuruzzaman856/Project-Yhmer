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
    public class CompanySearchProfileInfoModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Company { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchProfileId { get; set; }

        public Models.CompanySearchProfileModel SearchProfile { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            SearchProfile = new Models.CompanySearchProfileModel();
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            var url = "https://localhost:44309/SearchProfile/Get";
            var    values = new Dictionary<string, string>
                 {
                    {"SearchProfileId", SearchProfileId },
                 };
             var   json = JsonConvert.SerializeObject(values, Formatting.Indented);
              var  stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var  request = new HttpRequestMessage(HttpMethod.Post, url);
              HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

              request.Content = stringContent;
              var  responseMessage = await client.SendAsync(request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    
                    var response = await responseMessage.Content.ReadFromJsonAsync<Models.CompanySearchProfileModel>();

                    SearchProfile.Name = response.Name;
                    SearchProfile.About = response.About;
                    SearchProfile.Area = response.Area;
                    SearchProfile.Address = response.Address;
                    SearchProfile.Contact = response.Contact;
                    SearchProfile.ContactInformation = response.ContactInformation;
                    SearchProfile.Aktiv = response.Aktiv;
                    SearchProfile.Period = response.Period;
                    SearchProfile.Role = response.Role;


                    SearchProfile.Skills = new string[response.Skills.Length];

                    for (int i = 0; i < response.Skills.Length; i++)
                    {
                        SearchProfile.Skills[i] = response.Skills[i];
                    }

                    return Page();
                }
                else
                {
                    return Page();
                }
        }
    }
}
