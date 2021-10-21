using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Api.Areas.Identity.Data;
using Api.Areas.Identity.Data.Entities;
using System.Net.Http;
using Newtonsoft.Json;

namespace YHmer.Pages.Registration
{
    public class IndexModel : PageModel
    {
       [BindProperty(SupportsGet = true)]
       public string Selection { get; set; }

        public string HtmlHolder2 { get; set; }
        public string HTMLPlaceholderOne { get; set; }
       
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Phonenumber { get; set; }
        public string ConfimrationOfAgreement { get; set; }
        public string Role { get; set; }

        public void OnGet()
        {
            HTMLPlaceholderOne = "";
            ViewData["Role"] = Selection;
            HtmlHolder2 = "";
        }


        public async Task <ActionResult> OnPost()
        {
            if(Request.Form["create"] == "Godkänn")
            {

                ConfimrationOfAgreement = "Yes";
                Email = Request.Form["Email"];
                UserName = Request.Form["UserName"];
                Password = Request.Form["Password"];
                ConfirmPassword = Request.Form["ConfirmPassword"];

                switch (Selection)
                {
                    case "Student":
                        Role = "Student";
                        break;
                    case "Företag":
                        Role = "Company";
                        break;
                    case "Anordnare":
                        Role = "Organizer";
                        break;
                    default:
                        break;
                }

                if (ConfirmPassword != Password)
                {
                    HTMLPlaceholderOne = "Fel lösenord, försök igen...";
                    return Page();
                }
                else
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var url = "https://localhost:44309/Auth/register";
                        var values = new Dictionary<string, string>
                    {
                       {"Username", UserName },
                       {"Email", Email },
                       {"Password", Password },
                       {"Role", Role},
                       {"AgreedToTerms", ConfimrationOfAgreement }
                    };
                        var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                        var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                        using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                        {
                            if (responseMessage.IsSuccessStatusCode)
                            {
                                return RedirectToPage("/Login/Login");
                            }
                            else
                            {
                                HtmlHolder2 = "Konto kunde inte skapas";
                                return Page();
                            }
                        }
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
           

