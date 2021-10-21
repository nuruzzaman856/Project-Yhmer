using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Areas.Identity.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YHmer.Pages.Profiles.Organizer
{
    public class VerifyStudentModel : PageModel
    {
        public class ExperienceToVerifyModel
        {
           
            public string Name { get; set; }
            public string Role { get; set; }
            public string Period { get; set; }
            public string Experience { get; set; }
            public string Contacts { get; set; }

        }

        public List <ExperienceToVerifyModel> UsersExperienceToVerify = new List<ExperienceToVerifyModel>();
        public List<ExperienceToVerifyModel> UsersSkillsToVerify = new List<ExperienceToVerifyModel>();


        public void OnGet()
        {
        }
    }
}
