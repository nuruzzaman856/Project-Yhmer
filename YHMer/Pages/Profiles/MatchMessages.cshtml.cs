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
    public class MatchMessagesModel : PageModel
    {
        public List<MatchMessagesModels> Message { get; set; }
        public async Task<ActionResult> OnGetAsync()
        {
            Message = new List<MatchMessagesModels>();
            string token = HttpContext.Session.GetString("_Token");
            string message = "";
            string url = "https://localhost:44309/MatchManager/Get/MatchManager/Messages";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var messages = await response.Content.ReadFromJsonAsync<List<MatchMessagesModels>>();

                foreach(var outPut in messages)
                {
                    Message.Add(outPut);
                 
                   
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
