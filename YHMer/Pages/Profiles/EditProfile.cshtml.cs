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
using Newtonsoft.Json.Linq;
using YHmer.Models;
using System.Web;

namespace YHmer.Pages
{
    public class EditProfileModel : PageModel
    {
        [BindProperty]
        public ChangeUserProfileModel EditProfile { get; set; }
        private string UserID { get; set; }
        public string Message { get; set; }
        public string ProfileRole { get; set; }
        [BindProperty]
        public bool Visible { get; set; }


        //public EditProfileModel()
        //{
        //    EditProfile = new ChangeUserProfileModel();

        //}
        public ChangePasswordModel Password { get; set; }
        public async Task<ActionResult> OnGet()
        {

            EditProfile = new ChangeUserProfileModel();
            Password = new ChangePasswordModel();
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            ProfileRole = _token.Role;

         
            string url = "https://localhost:44309/Profile/getcontext";

            var values = new Dictionary<string, string>
                 {
                    
                 };
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
      
            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if (responseMessage.IsSuccessStatusCode)
            {
                var Profile = await responseMessage.Content.ReadFromJsonAsync<UserProfileModel>();
                EditProfile.FirstName = Profile.FirstName;
                EditProfile.LastName = Profile.LastName;
                EditProfile.About = Profile.About;
                EditProfile.PhoneNumber = Profile.phoneNumber == null ? "" : Profile.phoneNumber.ToString();
                EditProfile.Address = Profile.Adress;
                EditProfile.City = Profile.City;
                EditProfile.CompanyName = Profile.CompanyName;
                EditProfile.ContactPerson = Profile.ContactPerson;
                EditProfile.PostalCode = Profile.PostalCode;
                EditProfile.PostalArea = Profile.PostalArea;
                EditProfile.Orgnumber = Profile.OrgNumber;
                Visible = Profile.VisibleProfile;
                
                client.Dispose();
                return Page();
            }
            else
            {
                client.Dispose();
                return Page();
            }
        }
        public async Task<ActionResult> OnPost()
        {
            Password = new ChangePasswordModel();
            //EditProfile = new ChangeUserProfileModel();
            string token = HttpContext.Session.GetString("_Token");
            if (string.IsNullOrEmpty(token))
            {
                Redirect("/Login/Login");
            }
            var handler = new JwtSecurityTokenHandler();
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());

            EditProfile.FirstName = Request.Form["FirstName"];
            EditProfile.LastName = Request.Form["lastname"];
            EditProfile.CompanyName = Request.Form["CompanyName"];
            EditProfile.PhoneNumber = Request.Form["phoneNumber"];
            EditProfile.About = Request.Form["about"];
            EditProfile.ContactPerson = Request.Form["ContactPerson"];
            EditProfile.City = Request.Form["City"];
            EditProfile.Address = Request.Form["Address"];
            EditProfile.PostalCode = Request.Form["PostalCode"];
            EditProfile.Orgnumber = Request.Form["Orgnumber"];
            EditProfile.PostalArea = Request.Form["PostalArea"];
            


            if (Request.Form["update"] == "Uppdatera min profil")
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    var url = "https://localhost:44309/Profile/update";
                    var values = new Dictionary<string, object>
                    {
                        {"FirstName", EditProfile.FirstName },
                        {"LastName", EditProfile.LastName },
                        {"CompanyName", EditProfile.CompanyName },
                        {"PhoneNumber", EditProfile.PhoneNumber },
                        {"About", EditProfile.About },
                        //{"Id", _token.unique_name},
                        {"ContactPerson", EditProfile.ContactPerson },
                        {"City", EditProfile.City },
                        {"Address", EditProfile.Address },
                        {"PostalCode", EditProfile.PostalCode },
                        {"OrgNumber",  EditProfile.Orgnumber },
                        {"PostalArea",   EditProfile.PostalArea },
                        {"Visible", Visible },
                    };

                    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            return RedirectToPage("/Profiles/Profile");
                        }
                    }
                }
            }
            else if (Request.Form["delete"] == "Delete Profile")
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var url = "https://localhost:44309/Profile/delete";

                    var values = new Dictionary<string, string>
                    {
                        {"id", _token.unique_name}
                    };
                    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            return RedirectToPage("/Login/Login");
                        }
                    }
                }
            }
            else if (Request.Form["changePassword"] == "Ändra lösenord")
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var url = "https://localhost:44309/Auth/changepassword";

                    var values = new Dictionary<string, string>
                    {
                        {"CurrentPassword", Request.Form["oldPass"]},
                        {"NewPassword", Request.Form["newPass"]},
                        {"ConfirmNewPassword", Request.Form["confirmPass"]}
                    };
                    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            Message = "Lösenordet har ändrats";
                        }
                    }
                }
            }
            return RedirectToPage("/Profiles/EditProfile");
        }
    }
}
