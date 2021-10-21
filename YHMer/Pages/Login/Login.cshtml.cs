using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Api.Areas.Identity.Data;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace YHmer.Pages.Login
{
    public class SignInModel : PageModel
    {

        public const string SessionKeyName = "_Token";
        public string SessionInfo_Token { get; private set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string HTMLPlaceholderOne { get; set; }
        public void OnGet()
        {
            HTMLPlaceholderOne = "";
        }


        public async Task<ActionResult> OnPost()
        {
            User = Request.Form["email"];
            Password = Request.Form["password"];



            using (HttpClient client = new HttpClient())
            {

                var url = "https://localhost:44309/Auth/login";

                var values = new Dictionary<string, string>
                 {
                    {"User", User },
                    {"Password", Password }
                 };

                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                {

                    using (HttpContent contet = responseMessage.Content)
                    {
                        try
                        {
                            var messageback = contet.ReadAsStringAsync();
                            JObject converstion = JsonConvert.DeserializeObject<dynamic>(messageback.Result);
                            string accessToken = converstion.Value<string>("token");


                            // Set token in session
                            HttpContext.Session.SetString(SessionKeyName, accessToken);

                            // Get the token
                            //string token = HttpContext.Session.GetString(SessionKeyName);

                            if (responseMessage.IsSuccessStatusCode)
                            {
                                return RedirectToPage("/Profiles/Profile");
                            }
                            else
                            {
                                return Page();
                            }
                        }
                        catch (Exception)
                        {
                            HTMLPlaceholderOne = "Inloggning misslyckades";
                            return Page();
                        }
                    }
                }


            }
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Api.Areas.Identity.Data;

//namespace YHmer.Pages.Login
//{
//    public class SignInModel : PageModel
//    {
//        public string Email { get; set; }
//        public string Password { get; set; }
//        public void OnGet()
//        {
//        }

//        public ActionResult OnPost()
//        {
//            using (var context = new Context())
//            {
//                Email = Request.Form["email"];
//                Password = Request.Form["password"];

//                var user = context.Users.
//                    FirstOrDefault(p => p.Email == Email && p.PasswordHash == Password);

//                if(user.Email == Email && user.PasswordHash == Password)
//                {
//                    return new RedirectToPageResult("/Profiles/Profile");
//                }
//                else
//                {
//                    return Page();
//                }
//            }
//        }
//    }
//}
