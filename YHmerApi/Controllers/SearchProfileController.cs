using Api.Areas.Identity.Data;
using Api.Areas.Identity.Data.Entities;
using Api.Data;
using Api.Data.Entities;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{

    [Route("[controller]")]
    [ApiController]
    // Give it the [Authorize] attribute. It will bypass the autentication without it.  

    [Authorize]
    public class SearchProfileController : ControllerBase
    {


        private Context _context;
        private UserManager<User> _userManager;

        public SearchProfileController(Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        #region Student
        [Authorize]
        [HttpPost("/SearchProfile/Student/Add")]
        public async Task<ActionResult> StudentAddSearchProfile([FromBody] AddSearchProfileInfoModel model)
        {
            var UserName = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            var user = _context.Users.Where(x => x.UserName == UserName).FirstOrDefault();
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("student"))
            {
                foreach (var skill in model.Skills)
                {
                    var _skill = await _context.Skills.Where(x => x.Name == skill.Name).FirstOrDefaultAsync();
                    if (_skill != null)
                    {
                        var skillmatch = new SkillMatch
                        {
                            User = user,
                            Created = DateTime.Now,
                            Id = Guid.NewGuid().ToString(),
                            Skill = _skill,
                            IsVerified = false,
                            SkillLevel = skill.SkillLevel,
                            YearsOfSkill = skill.YearsOfExperience
                        };
                        _context.SkillMatches.Add(skillmatch);
                    }
                    else
                    {
                        var newSkill = new Skill
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = skill.Name,
                            IsVerified = false,
                        };
                        var skillmatch = new SkillMatch
                        {
                            User = user,
                            Created = DateTime.Now,
                            Id = Guid.NewGuid().ToString(),
                            Skill = newSkill,
                            IsVerified = false,
                            SkillLevel = skill.SkillLevel,
                            YearsOfSkill = skill.YearsOfExperience
                        };
                        _context.Skills.Add(newSkill);
                        _context.SkillMatches.Add(skillmatch);
                    }
                    await _context.SaveChangesAsync();
                }
                var newSearchProfile = new StudentSearchProfile
                {
                    Id = Guid.NewGuid().ToString(),
                    MakeProfileSearchable = model.MakeProfileSearchable,
                    LookingForEmploymentAfterExam = model.LookingForEmploymentAfterExam,
                    ViewMyGradsFromOrganizers = model.ViewMyGradsFromOrganizers,
                    FreeTextDescription = model.FreeTextDescription,
                    YearsOfExprienceInCompany = model.YearsOfExprienceInCompany,
                    Area = model.Area




                };
                user.StudentSearchProfiles.Add(newSearchProfile);


                _context.SaveChanges();
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("/SearchProfile/Student/Update")]
        public async Task<ActionResult> UpdateSearchProfile([FromBody] ChangeSearchProfile model)
        {

            var UpdateSearch = _context.StudentSearchProfiles.Include(x => x.User).Where(x => x.Id == model.SearchProfileId).FirstOrDefault();
            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            if (UpdateSearch.User.Id == user.Id)
            {
                UpdateSearch.LookingForEmploymentAfterExam = model.LookingForEmploymentAfterExam;
                UpdateSearch.MakeProfileSearchable = model.MakeProfileSearchable;
                UpdateSearch.ViewMyGradsFromOrganizers = model.ViewMyGradsFromOrganizers;
                UpdateSearch.FreeTextDescription = model.FreeTextDescription;
                UpdateSearch.YearsOfExprienceInCompany = model.YearsOfExprienceInCompany;
                UpdateSearch.Area = model.Area;
                _context.SaveChanges();
                var _skillsMatches = await _context.SkillMatches.Include(x => x.Skill).Where(x => x.User.Id == user.Id).ToListAsync();
                foreach (var skillMatch in _skillsMatches)
                {
                    for (int i = 0; i < model.skills.Count(); i++)
                    {
                        if (model.skills[i].Name == skillMatch.Skill.Name)
                        {
                            //TODO Edit Skillmatch here
                            break;
                        }
                        else if (i <= model.skills.Count())
                        {
                            var _skillMatch = await _context.SkillMatches.Where(x => x.Skill.Name == skillMatch.Skill.Name && x.User.Id == user.Id).FirstOrDefaultAsync();
                            _context.SkillMatches.Remove(_skillMatch);
                        }
                    }
                }
                foreach (var skill in model.skills)
                {

                    var _skill = await _context.Skills.Where(x => x.Name == skill.Name).FirstOrDefaultAsync();
                    if (_skill == null)
                    {
                        var newSkill = new Skill
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = skill.Name,
                            IsVerified = false,
                        };
                        var skillmatch = new SkillMatch
                        {
                            User = user,
                            Created = DateTime.Now,
                            Id = Guid.NewGuid().ToString(),
                            Skill = newSkill,
                            IsVerified = false,
                            SkillLevel = skill.SkillLevel,
                            YearsOfSkill = skill.YearsOfExperience
                        };
                        _context.Skills.Add(newSkill);
                        _context.SkillMatches.Add(skillmatch);
                    }
                    else
                    {
                        var SkillMatches = _context.SkillMatches.Where(x => x.Skill.Name == skill.Name && x.User.Id == user.Id).FirstOrDefault();
                        if(SkillMatches == null)
                        {
                            var skillmatch = new SkillMatch
                            {
                                User = user,
                                Created = DateTime.Now,
                                Id = Guid.NewGuid().ToString(),
                                Skill = _skill,
                                IsVerified = false,
                                SkillLevel = skill.SkillLevel,
                                YearsOfSkill = skill.YearsOfExperience
                            };
                            _context.SkillMatches.Add(skillmatch);
                        }
                        else
                        {
                            SkillMatches.SkillLevel = skill.SkillLevel;
                            SkillMatches.YearsOfSkill = skill.YearsOfExperience;
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("/SearchProfile/Student/Delete")]
        public async Task<ActionResult> DeleteSearchProfile([FromBody] RemoveSearchProfileModel model)
        {
            var UserName = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            var searchProfile = await _context.StudentSearchProfiles.Include(c => c.User).ThenInclude(x => x.SkillMatches).Where(x => x.Id == model.SearchProfileId).FirstOrDefaultAsync();
            if (searchProfile.User.UserName == UserName)
            {
                foreach (var skillmatch in searchProfile.User.SkillMatches)
                {
                    _context.SkillMatches.Remove(skillmatch);
                }
                _context.StudentSearchProfiles.Remove(searchProfile);
                //searchProfile.Id = model.SearchProfileId;
                //searchProfile.MakeProfileSearchable = false;
                //searchProfile.LookingForEmploymentAfterExam = false;
                //searchProfile.ViewMyGradsFromOrganizers = false;
                //searchProfile.FreeTextDescription = String.Empty;
                //searchProfile.YearsOfExprienceInCompany = default;

                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [Authorize]
        [HttpPost("/SearchProfile/Student/Get")]
        public async Task<ActionResult> GetEducation()
        {
            var userName = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            try
            {
                var searchProfile = await _context.StudentSearchProfiles.Where(x => x.User.UserName == userName).FirstOrDefaultAsync();
                var skillMatches = _context.SkillMatches.Include(x => x.Skill).Where(x => x.User.UserName == userName /*&& x.Skill.IsVerified && x.IsVerified*/);
                //var skillMatches = _context.SkillMatches.Include(x => x.Skill).Where(x => x.User.Id == model.UserId && x.Skill.IsVerified && x.IsVerified);
                var ListOfSkills = new List<dynamic>();
                if (searchProfile == null)
                {
                    return BadRequest();
                }

                foreach (var skillMatch in skillMatches)
                {
                    var _skill = new
                    {
                        Name = skillMatch.Skill.Name,
                        SkillLevel = skillMatch.SkillLevel,
                        YearsOfExperience = skillMatch.YearsOfSkill,
                        IsVerified = skillMatch.Skill.IsVerified
                    };
                    ListOfSkills.Add(_skill);

                }
                var response = new
                {
                    Id = searchProfile.Id,
                    MakeProfileSearchable = searchProfile.MakeProfileSearchable,
                    LookingForEmploymentAfterExam = searchProfile.LookingForEmploymentAfterExam,
                    ViewMyGradsFromOrganizers = searchProfile.ViewMyGradsFromOrganizers,
                    FreeTextDescription = searchProfile.FreeTextDescription,
                    YearsOfExprienceInCompany = searchProfile.YearsOfExprienceInCompany,
                    Area = searchProfile.Area,
                    Skills = ListOfSkills
                };
                return Ok(response);

            }

            catch (Exception)
            {

                return BadRequest();
            }
        }
        #endregion

        [Authorize]
        [HttpPost("/SearchProfile/Add")]
        public async Task<ActionResult> AddSearchProfile([FromBody] ProfileModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var newSearchProfile = new SearchProfile
            {

                About = model.About,
                Aktiv = model.Aktiv,
                Address = model.Address,
                Area = model.Area,
                Contact = model.Contact,
                ContactInformation = model.ContactInformation,
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Period = model.Period,
                Role = model.Role,
                User = user,
                LIA = model.LIA,
                Employment = model.Employment
                
            };

            foreach (var skill in model.Skills)
            {
                var _skill = await _context.Skills.Where(x => x.Name == skill).FirstOrDefaultAsync();
                if (_skill != null)
                {
                    var _profileSkillMatch = new SearchProfileSkillMatch
                    {
                        Id = Guid.NewGuid().ToString(),
                        SearchProfile = newSearchProfile,
                        Skill = _skill
                    };

                    newSearchProfile.Skills.Add(_profileSkillMatch);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var newSkill = new Skill
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = skill,
                        IsVerified = false,
                    };
                    _context.Skills.Add(newSkill);
                    await _context.SaveChangesAsync();
                    var _newSkill = await _context.Skills.Where(x => x.Name == newSkill.Name ).FirstOrDefaultAsync();
                    var _profileSkillMatch = new SearchProfileSkillMatch
                    {
                        Id = Guid.NewGuid().ToString(),
                        SearchProfile = newSearchProfile,
                        Skill = _newSkill
                    };
                    newSearchProfile.Skills.Add(_profileSkillMatch);
                    await _context.SaveChangesAsync();
                }
            }
            _context.SearchProfiles.Add(newSearchProfile);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [Authorize]
        [HttpPost("/SearchProfile/Update")]
        public async Task<ActionResult> UpdateSeachProfile([FromBody] ProfileModel model)
        {
            var profileToUpdate = await _context.SearchProfiles.Include(x => x.User).Where(x => x.Id == model.SearchProfileId).FirstOrDefaultAsync();
            if(profileToUpdate.User.UserName == User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value)
            {

            profileToUpdate.Name = model.Name;
            profileToUpdate.Period = model.Period;
            profileToUpdate.Role = model.Role;
            profileToUpdate.Contact = model.Contact;
            profileToUpdate.ContactInformation = model.ContactInformation;
            profileToUpdate.About = model.About;
            profileToUpdate.Address = model.Address;
            profileToUpdate.Aktiv = model.Aktiv;
            profileToUpdate.Area = model.Area;
            profileToUpdate.LIA = model.LIA;
            profileToUpdate.Employment = model.Employment;

            var _skills = _context.SearchProfileSkillMatches.Include(x => x.Skill).Where(x => x.SearchProfile.Id == model.SearchProfileId);

            foreach (var skillmatch in _skills)
            {

                for (int i = 0; i < model.Skills.Count; i++)
                {
                    if (skillmatch.Skill.Name == model.Skills[i])
                    {
                        break;
                    }
                    else if (i == model.Skills.Count - 1)
                    {
                        _context.SearchProfileSkillMatches.Remove(skillmatch);
                    }

                }

            }

            foreach (var skill in model.Skills)
            {
                var Skill = await _context.Skills.Where(x => x.Name == skill).FirstOrDefaultAsync();
                if (Skill == null)
                {
                    var newSkill = new Skill
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = skill,
                        IsVerified = false,
                    };
                    _context.Skills.Add(newSkill);
                    await _context.SaveChangesAsync();

                    var theNewSkill = await _context.Skills.Where(x => x.Name == newSkill.Name).FirstOrDefaultAsync();

                    var _skillMatch = new SearchProfileSkillMatch
                    {
                        Id = Guid.NewGuid().ToString(),
                        SearchProfile = profileToUpdate,
                        Skill = theNewSkill,
                    };
                    _context.Add(_skillMatch);
                }

                else
                {
                    var _skillsInMatches = await _context.SearchProfileSkillMatches.Include(x => x.Skill).Where(x => x.SearchProfile.Id == model.SearchProfileId).ToListAsync();

                    for (int i = 0; i < _skillsInMatches.Count; i++)
                    {

                        if (_skillsInMatches[i].Skill.Name == skill)
                        {
                            break;
                        }
                        else if (i == _skillsInMatches.Count - 1)
                        {
                            var _skillMatch = new SearchProfileSkillMatch
                            {
                                Id = Guid.NewGuid().ToString(),
                                SearchProfile = profileToUpdate,
                                Skill = Skill,
                            };

                            _context.Add(_skillMatch);
                        }
                    }

                }
            }

            await _context.SaveChangesAsync();
            return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("/SearchProfile/Delete")]
        public async Task<ActionResult> DeleteSearchProfile([FromBody] ProfileModel model)
        {
            var profile = await _context.SearchProfiles.Include(x => x.User).Where(x => x.Id == model.SearchProfileId).FirstOrDefaultAsync();
            if(profile.User.UserName == User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value)
            {

            var skillMatch = await _context.SearchProfileSkillMatches.Where(x => x.SearchProfile.Id == model.SearchProfileId).ToListAsync();
            foreach (var match in skillMatch)
            {
                _context.Remove(match);
            }


            _context.Remove(profile);
            await _context.SaveChangesAsync();

            return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("/SearchProfile/Get")]
        public async Task<ActionResult> GetSearchProfile([FromBody] ProfileModel model)
        {

            var profile = await _context.SearchProfiles.Include(x => x.Skills).ThenInclude(x => x.Skill).Where(x => x.Id == model.SearchProfileId).FirstOrDefaultAsync();

            var response = new
            {
                SearchProfileId = profile.Id,
                About = profile.About,
                Address = profile.Address,
                Contact = profile.Contact,
                ContactInformation = profile.ContactInformation,
                Name = profile.Name,
                Aktiv = profile.Aktiv,
                Area = profile.Area,
                Role = profile.Role,
                Period = profile.Period,
                LIA = profile.LIA,
                Employment = profile.Employment,
                Skills = new List<string>()

            };

            foreach (var skill in profile.Skills)
            {
                response.Skills.Add(skill.Skill.Name);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPost("/SearchProfile/GetAll")]
        public async Task<ActionResult> GetAllSearchProfile([FromBody] ProfileModel model)
        {
            var UserName = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            var allSearchProfiles = await _context.SearchProfiles.Include(x => x.Skills).ThenInclude(x => x.Skill).Where(x => x.User.UserName == UserName).ToListAsync();


            var responseList = new List<dynamic>();

            foreach (var profile in allSearchProfiles)
            {
                var response = new
                {
                    SearchProfileId = profile.Id,
                    About = profile.About,
                    Address = profile.Address,
                    Contact = profile.Contact,
                    ContactInformation = profile.ContactInformation,
                    Name = profile.Name,
                    Aktiv = profile.Aktiv,
                    Area = profile.Area,
                    Role = profile.Role,
                    Period = profile.Period,
                    LIA = profile.LIA,
                    Employment = profile.Employment

                };
                responseList.Add(response);
            }

            return Ok(responseList);
        }


    }
}

