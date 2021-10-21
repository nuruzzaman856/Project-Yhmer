using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using YHmer.Models;

namespace YHmer.Pages.SkillAndSearchProfile
{
    public class AddSkillModel : PageModel
    {
        public string Name { get; set; }
        public bool IsVerified { get; set; }

        public string SkillLevel { get; set; }
        public int YearsOfSkill { get; set; }



        public async Task<ActionResult> OnGetAsync()
        {
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            if (_token.Role == "student" || _token.Role == "root")
            {
                return Page();
            }

            else
            {
                return RedirectToPage("/Profiles/Profile");
            }

        }


        public async Task<ActionResult> OnPost()
        {
            string token = HttpContext.Session.GetString("_Token");
            var handler = new JwtSecurityTokenHandler();
            var _token = JsonConvert.DeserializeObject<TokenModel>(handler.ReadJwtToken(token).Payload.SerializeToJson());


            Name = Request.Form["Name"];
            SkillLevel = Request.Form["SkillLevel"];
            YearsOfSkill = int.Parse(Request.Form["YearsOfSkill"]);
            //IsVerified = (Request.Form["IsVerified"].ToString()).Contains("on") ? true : false;
         
           



            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var skilllevel1 = "";
                switch (SkillLevel)
                {
                    case "1":
                        skilllevel1 = "TeoretiksT";
                        break;
                    case "2":
                        skilllevel1 = "Rookie";
                        break;
                    case "3":
                        skilllevel1 = "Medel";
                        break;
                    case "4":
                        skilllevel1 = "Hög";
                        break;
                    case "5":
                        skilllevel1 = "Professionell";
                        break;
                    default:
                        break;
                }
                if (_token.Role== "student")
                {
                    var url = "https://localhost:44309/Skill/Add/Student";
                    var values = new Dictionary<string, dynamic>
                    {
                       {"Name",  Name },
                       {"SkillLevel", skilllevel1 },
                       {"YearsOfSkill",  YearsOfSkill }
                 
                      
                    };
                    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            return RedirectToPage("../SkillAndSearchProfile/Skills");
                        }
                        else
                        {
                            return Page();
                        }
                    }

                }
                else if(_token.Role == "root")
                {
                    var url = "https://localhost:44309/Skill/Add/Admin";
                    var values = new Dictionary<string, dynamic>
                    {
                       {"UserId", _token.unique_name },
                       {"Name",  Name }
                      
                      
                    };
                    var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                    var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, stringContent))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            return RedirectToPage("../SkillAndSearchProfile/Skills");
                        }
                        else
                        {
                            return Page();
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
}
