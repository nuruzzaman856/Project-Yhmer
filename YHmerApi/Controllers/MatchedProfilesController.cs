using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Areas.Identity.Data;
using Api.Data;
using Api.Data.Entities;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Areas.Identity.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchedProfilesController : ControllerBase
    {
        public readonly Context _context;
        public UserManager<User> _user;
        public MatchedProfilesController(Context context, UserManager<User> user)
        {
            _context = context;
            _user = user;
        }

        #region Company

        [AllowAnonymous]
        [HttpGet("Company/SearchProfiles/GetAll")]
        public async Task<ActionResult> GetAllStudentSearchProfiles()
        {
            var user = await _user.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);

            int counter = 0;
            int Looper = 0;
            int matchingsearch = 0;

            var companiesSearchProfiles = await _context.SearchProfiles.Include(x => x.Skills).ThenInclude(x => x.Skill).Include(x => x.User).ThenInclude(x => x.MatchManagers).Where(x => x.User.Id == user.Id).Where(x => x.Aktiv == true || x.LIA == true || x.Employment == true).ToListAsync();

            var response = new List<GetAllStudentSearchProfiles>();

            foreach (var cProfile in companiesSearchProfiles)
            {
                var studentSearchProfiles = await _context.StudentSearchProfiles.Include(x => x.User).ThenInclude(x => x.SkillMatches).ThenInclude(x => x.Skill).Where(x => x.Area == cProfile.Area).Where(x => x.MakeProfileSearchable == true || x.LookingForEmploymentAfterExam == true).ToListAsync();

               
                foreach (var sProfile in studentSearchProfiles)
                {
                    counter = 0;
                    Looper = 0;
                    matchingsearch = 0;
                    string AcceptedLia = "false";
                    string DeniedLia = "false";
                    string AcceptedJob = "false";
                    string DeniedJob = "false";

                    foreach (var skill in cProfile.Skills.OrderBy(x => x.Skill.Name))
                    {
                        foreach (var skillmatches in sProfile.User.SkillMatches.OrderBy(x => x.Skill.Name))
                        {
                            if (cProfile.LIA == true && sProfile.MakeProfileSearchable == true)
                            {
                                matchingsearch++;
                            }
                            else if (cProfile.Employment == true && sProfile.LookingForEmploymentAfterExam == true)
                            {
                                matchingsearch++;
                            }

                            if (skill.Skill.Name == skillmatches.Skill.Name)
                            {
                                counter++;
                            }
                            
                        }
                        Looper++;
                    }

                    foreach (var matchManager in cProfile.User.MatchManagers)
                    {
                        if(matchManager.MatchedSearchProfileId == sProfile.Id)
                        {
                            AcceptedLia = matchManager.AcceptedLIA ?  "true" : "false";
                            DeniedLia = matchManager.DeclinedLIA ? "true" : "false";
                            AcceptedJob = matchManager.AcceptedJob ? "true" : "false";
                            DeniedJob = matchManager.DeclinedJob ? "true" : "false";
                        }
                    }

                  

                    if (matchingsearch > 0 && counter > 0 && Looper == cProfile.Skills.Count)
                    {
                        response.Add(new Models.GetAllStudentSearchProfiles { MatchedIndividual = sProfile.User.UserName, SearchProfile = cProfile.Name, Grades = sProfile.ViewMyGradsFromOrganizers, StudentId = sProfile.User.Id, Period = cProfile.Period, Matches = counter, wantedSkills = cProfile.Skills.Count(), LIA = sProfile.MakeProfileSearchable,
                            Employment = sProfile.LookingForEmploymentAfterExam, cLia = cProfile.LIA, cEmployment = cProfile.Employment, MatchedSearchProfileId = sProfile.Id, SearchProfileId = cProfile.Id, AcceptedLia = AcceptedLia, DeniedLia = DeniedLia,AcceptedJob = AcceptedJob,DeniedJob= DeniedJob });
                    }

                }

            }

            return Ok(response);
        }


        [Authorize]
        [HttpGet("Student/SearchProfiles/GetAll")]
        public async Task<ActionResult> GetAllCompanySearchProfiles()
        {
            int counter = 0;
            int Looper = 0;
            int matchingsearch = 0;
            var user = await _user.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var studentSearchProfile = await _context.StudentSearchProfiles.Include(x => x.User.SkillMatches).ThenInclude(x => x.Skill).Where(x => x.User.Id == user.Id && (x.MakeProfileSearchable == true || x.LookingForEmploymentAfterExam == true)).FirstOrDefaultAsync();
            var response = new List<GetAllCompaniesSearchProfiles>();

            if (studentSearchProfile != null)
            {
                var companySearchProfiles = await _context.SearchProfiles.Include(x => x.User).ThenInclude(x => x.SearchProfiles).ThenInclude(x => x.Skills).ThenInclude(x => x.Skill).Where(x => x.Area == studentSearchProfile.Area && x.Aktiv == true || x.LIA == true || x.Employment == true).ToListAsync();

                var matchManagers = await _context.MatchManager.Where(x => x.User.Id == user.Id).ToListAsync();

                foreach (var cSearchProfile in companySearchProfiles)
                {
                    counter = 0;
                    Looper = 0;
                    matchingsearch = 0;
                    string AcceptedLia = "false";
                    string DeniedLia = "false";
                    string AcceptedJob = "false";
                    string DeniedJob = "false";
                    foreach (var Studentskillmatch in studentSearchProfile.User.SkillMatches.OrderBy(x => x.Skill.Name))
                    {
                        foreach (var Companyskillmatch in cSearchProfile.Skills.OrderBy(x => x.Skill.Name))
                        {
                            if (cSearchProfile.LIA == true && studentSearchProfile.MakeProfileSearchable == true)
                            {
                                matchingsearch++;
                            }
                            else if (cSearchProfile.Employment == true && studentSearchProfile.LookingForEmploymentAfterExam == true)
                            {
                                matchingsearch++;
                            }
                            if (Studentskillmatch.Skill.Name == Companyskillmatch.Skill.Name)
                            {

                                counter++;
                            }
                        }
                        Looper++;
                    }


                    var orderedManager = matchManagers.OrderBy(x => x.MatchedSearchProfileId).ToList();
                        
                    for(int i=0; i<matchManagers.Count - 1; i++)
                    {
                        if(orderedManager[i].MatchedSearchProfileId == orderedManager[i + 1].MatchedSearchProfileId && orderedManager[i].DeclinedLIA == true || orderedManager[i + 1].DeclinedLIA == true)
                        {
                            AcceptedLia = "false";
                        }
                        else if (orderedManager[i].MatchedSearchProfileId == orderedManager[i + 1].MatchedSearchProfileId && orderedManager[i].DeclinedJob == true || orderedManager[i + 1].DeclinedJob == true)
                        {
                            AcceptedJob = "false";
                        }
                        else if(orderedManager[i].MatchedSearchProfileId != orderedManager[i + 1].MatchedSearchProfileId)
                        {
                            AcceptedLia = orderedManager[i].AcceptedLIA ? "true" : "false";
                            DeniedLia = orderedManager[i].DeclinedLIA ? "true" : "false";
                            AcceptedJob = orderedManager[i].AcceptedJob ? "true" : "false";
                            DeniedJob = orderedManager[i].DeclinedJob ? "true" : "false";
                        }
                    }
                        //if (matchManager.MatchedSearchProfileId == cSearchProfile.Id)
                        //{
                        //    AcceptedLia = matchManager.AcceptedLIA ? "true" : "false";
                        //    DeniedLia = matchManager.DeclinedLIA ? "true" : "false";
                        //    AcceptedJob = matchManager.AcceptedJob ? "true" : "false";
                        //    DeniedJob = matchManager.DeclinedJob ? "true" : "false";
                        //}
                    


                    if (matchingsearch > 0 && counter > 0 && Looper == studentSearchProfile.User.SkillMatches.Count)
                    {

                        response.Add(new Models.GetAllCompaniesSearchProfiles { SearchProfileName = cSearchProfile.Name, UserId = cSearchProfile.User.Id, CompanyName = cSearchProfile.User.CompanyName, MatchedSkills = counter, WantedSkills = cSearchProfile.Skills.Count(), Area = cSearchProfile.Area, Period = cSearchProfile.Period, 
                            ContactPerson = cSearchProfile.Contact, MatchedSearchProfileId = cSearchProfile.Id, SearchProfileId = studentSearchProfile.Id,  Role = cSearchProfile.Role, LIA = studentSearchProfile.MakeProfileSearchable, Employment = studentSearchProfile.LookingForEmploymentAfterExam, cLIA = cSearchProfile.LIA, cEmployment = cSearchProfile.Employment,
                            AcceptedLia = AcceptedLia,
                            DeniedLia = DeniedLia,
                            AcceptedJob = AcceptedJob,
                            DeniedJob = DeniedJob
                        });
                    }

                }

            }



            return Ok(response);
        }


        #endregion
    }
}
