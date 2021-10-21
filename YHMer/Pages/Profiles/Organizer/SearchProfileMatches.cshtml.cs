using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using YHmer.Models;

namespace YHmer.Pages.Profiles.Organizer
{
    public class SearchProfileMatchesModel : PageModel
    {
        public List<Models.StudentSearchProfileModel> ResponseOne { get; set; }
        public List<Models.CompanyMatchedProfileModel> ResponseTwo { get; set; }

        public string Role { get; set; }



        public async Task<ActionResult> OnGetAsync()
        {
            ResponseOne = new List<StudentSearchProfileModel>();
            ResponseTwo = new List<CompanyMatchedProfileModel>();
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();


            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            Role = _token.Role;

            if (_token.Role == "company")
            {
                string url = "https://localhost:44309/MatchedProfiles/Company/SearchProfiles/GetAll";

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {

                    var messageBack = await response.Content.ReadFromJsonAsync<List<StudentSearchProfileModel>>();




                    foreach (var profile in messageBack)
                    {


                        ResponseOne.Add(profile);
                    }




                }
            }
            else if (_token.Role == "student")
            {
                string url = "https://localhost:44309/MatchedProfiles/Student/SearchProfiles/GetAll";



                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {

                    var messageBack = await response.Content.ReadFromJsonAsync<List<CompanyMatchedProfileModel>>();
                    if (messageBack.Count > 0)
                    {
                        foreach (var profile in messageBack)
                        {
                            ResponseTwo.Add(profile);
                        }
                    }

                }

            }


            return Page();
        }
        public async Task<ActionResult> OnPostAsync()
        {
            var matchManager = new MatchManagerModel();
            var Responsethree = new MatchManagerModel();
            string selectedId = Request.Form["selectedId"];
            string selectedMatchId = Request.Form["selectedMatchId"];

            string token = HttpContext.Session.GetString("_Token");

            string url = "https://localhost:44309/MatchManager/Get/MatchManagers";
            var values = new Dictionary<string, dynamic>()
            {
                {"SearchProfileId", selectedId }
            };

            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            var StringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var response = await client.PostAsync(url, StringContent);


            if (response.IsSuccessStatusCode)
            {
                if (response.ReasonPhrase == "OK") 
                {
                    var messageBack = await response.Content.ReadFromJsonAsync<MatchManagerModel>();
                    bool acceptLIA;
                    bool denyLIA;
                    bool acceptJob;
                    bool denyJob;
                    var regret = Request.Form["Change"];

                    if(regret.Count > 0)
                    {
                        if(messageBack.AcceptedJob == true)
                        {
                            Responsethree.AcceptedJob = false;
                            Responsethree.DeclinedJob = messageBack.DeclinedJob;
                            Responsethree.AcceptedLia = messageBack.AcceptedLia;
                            Responsethree.DeclinedLia = messageBack.DeclinedLia;
                        }
                        else if(messageBack.AcceptedLia == true)
                        {
                            Responsethree.AcceptedJob = messageBack.AcceptedJob;
                            Responsethree.DeclinedJob = messageBack.DeclinedJob;
                            Responsethree.AcceptedLia = false;
                            Responsethree.DeclinedLia = messageBack.DeclinedLia;
                        }
                    }
                    else
                    {
                        Responsethree.AcceptedJob =  Request.Form["acceptJob"].Count > 0 ? true : false;
                        Responsethree.DeclinedJob = Request.Form["deleteJob"].Count > 0 ? true : false;
                        Responsethree.AcceptedLia =  Request.Form["acceptLia"].Count > 0 ? true : false;
                        Responsethree.DeclinedLia = Request.Form["deleteLia"].Count > 0 ? true : false;
  
                    }







                    matchManager.AcceptedLia = Responsethree.AcceptedLia; 
                    matchManager.DeclinedLia = Responsethree.DeclinedLia;
                    matchManager.AcceptedJob = Responsethree.AcceptedJob;
                    matchManager.DeclinedJob = Responsethree.DeclinedJob;
                    matchManager.SearchProfileId = selectedId;

                    token = HttpContext.Session.GetString("_Token");
                    url = "https://localhost:44309/MatchManager/Selection";

                    values = new Dictionary<string, dynamic>
                 {
                {"MatchedSearchProfileId", selectedMatchId },
                {"SearchProfileId", matchManager.SearchProfileId },
                {"AcceptedLia", matchManager.AcceptedLia },
                {"DeclinedLia", matchManager.DeclinedLia },
                {"AcceptedJob", matchManager.AcceptedJob },
                {"DeclinedJob", matchManager.DeclinedJob }
                 };

                    client = new HttpClient();
                    json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    var message = await client.PostAsync(url, stringContent);

                    if (message.IsSuccessStatusCode)
                    {
                        client.Dispose();
                        message.Dispose();
                        return RedirectToPage("/Profiles/Organizer/SearchProfileMatches");
                    }
                    else
                    {
                        client.Dispose();
                        message.Dispose();
                        return RedirectToPage("/Profiles/Organizer/SearchProfileMatches");
                    }
                }
                
                
                else
                {
                    var acceptLIA = Request.Form["acceptLia"];
                    var denyLIA = Request.Form["deleteLia"];
                    var acceptJob = Request.Form["acceptJob"];
                    var denyJob = Request.Form["deleteJob"];
                    

                    matchManager.AcceptedLia = acceptLIA.Count > 0 ? true : false;
                    matchManager.DeclinedLia = denyLIA.Count > 0 ? true : false;
                    matchManager.AcceptedJob = acceptJob.Count > 0 ? true : false;
                    matchManager.DeclinedJob = denyJob.Count > 0 ? true : false;
                    matchManager.SearchProfileId = selectedId;

                    token = HttpContext.Session.GetString("_Token");
                    url = "https://localhost:44309/MatchManager/Selection";

                    values = new Dictionary<string, dynamic>
{
         {"MatchedSearchProfileId", selectedMatchId },
                {"SearchProfileId", matchManager.SearchProfileId },
                {"AcceptedLia", matchManager.AcceptedLia },
                {"DeclinedLia", matchManager.DeclinedLia },
                {"AcceptedJob", matchManager.AcceptedJob },
                {"DeclinedJob", matchManager.DeclinedJob }
};

                    client = new HttpClient();
                    json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    var message = await client.PostAsync(url, stringContent);

                    if (message.IsSuccessStatusCode)
                    {
                        client.Dispose();
                        message.Dispose();
                        return RedirectToPage("/Profiles/Organizer/SearchProfileMatches");
                    }
                    else
                    {
                        client.Dispose();
                        message.Dispose();
                        return RedirectToPage("/Profiles/Organizer/SearchProfileMatches");
                    }
                }







            }
            else
            {
                return Page();
            }










        }
    }
}
