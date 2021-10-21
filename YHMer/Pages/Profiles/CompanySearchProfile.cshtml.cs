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

namespace YHmer.Pages.Profiles
{
    public class CompanySearchProfileModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchProfileId { get; set; }
        [BindProperty]
        public Models.CompanySearchProfileModel SearchProfile { get; set; }
        [BindProperty]
        public List<Models.CompanySearchProfileModel> SearchProfiles { get; set; }
        [BindProperty]
        public int Period { get; set; }
        [BindProperty]
        public bool Active { get; set; }
        [BindProperty]
        public int Area { get; set; }
        [BindProperty]
        public string PostedSearchId { get; set; }
        
        public List<Models.SkillModel> VerifiedSkills { get; set; }


        public CompanySearchProfileModel()
        {
            SearchProfile = new Models.CompanySearchProfileModel();
            SearchProfiles = new List<Models.CompanySearchProfileModel>();
        }
        public async Task<ActionResult> OnGetAsync()
        {
            VerifiedSkills = new List<Models.SkillModel>();
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

            var url = "https://localhost:44309/Skill/GetAllVerifed";
            var values = new Dictionary<string, string>
                 {
                    {"UserId", _token.unique_name },

                 };
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, stringContent);
            if (responseMessage.IsSuccessStatusCode == true)
            {
                var skills = responseMessage.Content.ReadFromJsonAsync<List<SkillModel>>();

                foreach (var skill in skills.Result)
                {
                    VerifiedSkills.Add(skill);
                }
            }

        
            url = "https://localhost:44309/SearchProfile/GetAll";
            values = new Dictionary<string, string>
                 {
                    {"userId", _token.unique_name },
                 };
            stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = stringContent;
            responseMessage = await client.SendAsync(request);

            if (responseMessage.IsSuccessStatusCode)
            {
                var response = responseMessage.Content.ReadFromJsonAsync<List<Models.CompanySearchProfileModel>>();

                foreach (var profile in response.Result)
                {
                    SearchProfiles.Add(profile);
                }
            }


            if (SearchProfileId != null)
            {

                url = "https://localhost:44309/SearchProfile/Get";
                values = new Dictionary<string, string>
                 {
                    {"SearchProfileId", SearchProfileId },
                 };
                json = JsonConvert.SerializeObject(values, Formatting.Indented);
                stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                request = new HttpRequestMessage(HttpMethod.Post, url);

                request.Content = stringContent;
                responseMessage = await client.SendAsync(request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    
                    var response = await responseMessage.Content.ReadFromJsonAsync<Models.CompanySearchProfileModel>();

                    SearchProfile.Name = response.Name;
                    SearchProfile.About = response.About;
                    SearchProfile.Area = response.Area;
                    SearchProfile.Address = response.Address;
                    SearchProfile.Contact = response.Contact;
                    SearchProfile.ContactInformation = response.ContactInformation;
                    Active = response.Aktiv;
                    SearchProfile.Period = response.Period;
                    SearchProfile.Role = response.Role;
                    SearchProfile.LIA = response.LIA;
                    SearchProfile.Employment = response.Employment;


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

            return Page();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (Request.Form["delete"] == "Ta bort")
            {
                string searchProfileId = Request.Form["selectedId"];
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();

                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
                string url = "https://localhost:44309/SearchProfile/Delete";
                var values = new Dictionary<string, string>
                 {
                    {"SearchProfileId", searchProfileId },
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
                    return RedirectToPage("/Profiles/CompanySearchProfile");
                }
                else
                {
                    return Page();
                }
            }
            if (Request.Form["Annonsera"] == "Annonsera")
            {
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
                var skills = Request.Form["SkillName"];

                var active = Request.Form["Aktiv"];
                var LIA = Request.Form["LIA"];
                var employment = Request.Form["Anställning"];


                SearchProfile.Aktiv = active.Count > 0 ? true : false;
                SearchProfile.LIA = LIA.Count > 0 ? true : false;
                SearchProfile.Employment = employment.Count > 0 ? true : false;

                string _period = "";
                using (HttpClient client = new HttpClient())
                {
                    var url = "https://localhost:44309/SearchProfile/Add";
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    switch (Period)
                    {
                        case 1:
                            _period = "VT";
                            break;
                        case 2:
                            _period = "HT";
                            break;
                        case 3:
                            _period = "Löpande";
                            break;
                        default:
                            break;
                    }
                    
                    string area = "";
                    var _area = (AreaEnum.Area)Area;
                    switch (_area)
                    {
                        case AreaEnum.Area.Norrbotten:
                            area = "Norrbotten";
                            break;
                        case AreaEnum.Area.Västerbotten:
                            area = "Västerbotten";
                            break;
                        case AreaEnum.Area.Jämtland:
                            area = "Jämtland";
                            break;
                        case AreaEnum.Area.Västernorrland:
                            area = "Västernorrland";
                            break;
                        case AreaEnum.Area.Gävleborg:
                            area = "Gävleborg";
                            break;
                        case AreaEnum.Area.Dalarna:
                            area = "Dalarna";
                            break;
                        case AreaEnum.Area.Värmland:
                            area = "Värmland";
                            break;
                        case AreaEnum.Area.Uppsala:
                            area = "Uppsala";
                            break;
                        case AreaEnum.Area.Västmanland:
                            area = "Västmanland";
                            break;
                        case AreaEnum.Area.Stockholm:
                            area = "Stockholm";
                            break;
                        case AreaEnum.Area.Södermanland:
                            area = "Södermanland";
                            break;
                        case AreaEnum.Area.Jönköping:
                            area = "Jönköping";
                            break;
                        case AreaEnum.Area.Örebro:
                            area = "Örebro";
                            break;
                        case AreaEnum.Area.Östergötaland:
                            area = "Östergötaland";
                            break;
                        case AreaEnum.Area.Västragötaland:
                            area = "Västragötaland";
                            break;
                        case AreaEnum.Area.Kalmar:
                            area = "Kalmar";
                            break;
                        case AreaEnum.Area.Gotland:
                            area = "Gotland";
                            break;
                        case AreaEnum.Area.Halland:
                            area = "Halland";
                            break;
                        case AreaEnum.Area.Skåne:
                            area = "Skåne";
                            break;
                        case AreaEnum.Area.Blekinge:
                            area = "Blekinge";
                            break;
                        case AreaEnum.Area.Kronoberg:
                            area = "Kronoberg";
                            break;
                        default:
                            break;
                    }
                    var payload = new Dictionary<string, dynamic>
            {
                {"UserId", _token.unique_name },
                { "Name", SearchProfile.Name},
                { "Period", _period },
                { "Contact", SearchProfile.Contact},
                {"ContactInformation", SearchProfile.ContactInformation },
                {"Role", SearchProfile.Role },
                { "About", SearchProfile.About },
                { "Aktiv", SearchProfile.Aktiv},
                {"LIA", SearchProfile.LIA },
                {"Employment", SearchProfile.Employment },
                {"Address", SearchProfile.Address },
                {"Area", area },
                { "Skills", skills}
            };

                    var json = JsonConvert.SerializeObject(payload, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            return RedirectToPage("/Profiles/CompanySearchProfile");
                        }
                        else
                        {
                            return RedirectToPage("/Profiles/CompanySearchProfile");
                        }
                    }
                }
            }
            else if (Request.Form["Uppdatera"] == "Uppdatera")
            {
                string token = HttpContext.Session.GetString("_Token");
                var handler = new JwtSecurityTokenHandler();
                var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
                List<string> skills = Request.Form["SkillName"].ToList();
                var active = Request.Form["Aktiv"];
                var LIA = Request.Form["LIA"];
                var employment = Request.Form["Anställning"];
                SearchProfile.Aktiv = active.Count > 0 ? true : false;
                SearchProfile.LIA = LIA.Count > 0 ? true : false;
                SearchProfile.Employment = employment.Count > 0 ? true : false;
                string _period = "";
                using (HttpClient client = new HttpClient())
                {
                    var url = "https://localhost:44309/SearchProfile/Update";
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    switch (Period)
                    {
                        case 1:
                            _period = "VT";
                            break;
                        case 2:
                            _period = "HT";
                            break;
                        case 3:
                            _period = "L�pande";
                            break;
                        default:
                            break;
                    }
                    string area = "";
                    var _area = (AreaEnum.Area)Area;
                    switch (_area)
                    {
                        case AreaEnum.Area.Norrbotten:
                            area = "Norrbotten";
                            break;
                        case AreaEnum.Area.Västerbotten:
                            area = "Västerbotten";
                            break;
                        case AreaEnum.Area.Jämtland:
                            area = "Jämtland";
                            break;
                        case AreaEnum.Area.Västernorrland:
                            area = "Västernorrland";
                            break;
                        case AreaEnum.Area.Gävleborg:
                            area = "Gävleborg";
                            break;
                        case AreaEnum.Area.Dalarna:
                            area = "Dalarna";
                            break;
                        case AreaEnum.Area.Värmland:
                            area = "Värmland";
                            break;
                        case AreaEnum.Area.Uppsala:
                            area = "Uppsala";
                            break;
                        case AreaEnum.Area.Västmanland:
                            area = "Västmanland";
                            break;
                        case AreaEnum.Area.Stockholm:
                            area = "Stockholm";
                            break;
                        case AreaEnum.Area.Södermanland:
                            area = "Södermanland";
                            break;
                        case AreaEnum.Area.Jönköping:
                            area = "Jönköping";
                            break;
                        case AreaEnum.Area.Örebro:
                            area = "Örebro";
                            break;
                        case AreaEnum.Area.Östergötaland:
                            area = "Östergötaland";
                            break;
                        case AreaEnum.Area.Västragötaland:
                            area = "Västragötaland";
                            break;
                        case AreaEnum.Area.Kalmar:
                            area = "Kalmar";
                            break;
                        case AreaEnum.Area.Gotland:
                            area = "Gotland";
                            break;
                        case AreaEnum.Area.Halland:
                            area = "Halland";
                            break;
                        case AreaEnum.Area.Skåne:
                            area = "Skåne";
                            break;
                        case AreaEnum.Area.Blekinge:
                            area = "Blekinge";
                            break;
                        case AreaEnum.Area.Kronoberg:
                            area = "Kronoberg";
                            break;
                        default:
                            break;
                    }
                    var skillsToRemove = skills.Where(x => string.IsNullOrEmpty(x)).ToList();

                    foreach (var removeble in skillsToRemove)
                    {
                        skills.Remove(removeble);
                    }

                    var payload = new Dictionary<string, dynamic>

            {
                {"UserId", _token.unique_name },
                {"SearchProfileId", SearchProfileId },
                { "Name", SearchProfile.Name},
                { "Period", _period },
                { "Contact", SearchProfile.Contact},
                {"ContactInformation", SearchProfile.ContactInformation },
                {"Role", SearchProfile.Role },
                { "About", SearchProfile.About },
                { "Aktiv", SearchProfile.Aktiv },
                {"LIA", SearchProfile.LIA },
                {"Employment", SearchProfile.Employment },
                { "Area", area },
                {"Address", SearchProfile.Address },
                { "Skills", skills}
            };

                    var json = JsonConvert.SerializeObject(payload, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            return RedirectToPage("/Profiles/CompanySearchProfile");
                        }
                        else
                        {
                            return RedirectToPage("/Profiles/CompanySearchProfile");
                        }
                    }
                }
            }
            return RedirectToPage("/Profiles/CompanySearchProfile");


        }
    }
}
