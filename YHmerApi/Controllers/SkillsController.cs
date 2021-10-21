using Api.Areas.Identity.Data;
using Api.Areas.Identity.Data.Entities;
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
    public class SkillsController : ControllerBase
    {

        private Context _context;
        private UserManager<User> _userManager;

        public SkillsController(Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost("/Skill/Add/Student")]
        public async Task<ActionResult> StudentAddSkill([FromBody] StudentAddSkillModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("student"))
            {

                var newSkillMatch = new SkillMatch
                {
                    Id = Guid.NewGuid().ToString(),
                    User = user,
                    Skill = new Skill
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = model.Name,
                        IsVerified = false

                    },
                    SkillLevel = model.SkillLevel,
                    YearsOfSkill = model.YearsOfSkill,
                    Created = DateTime.Now,
                    IsVerified = false
                };
                user.SkillMatches.Add(newSkillMatch);


                _context.SaveChanges();
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost("/Skill/Add/Admin")]
        public async Task<ActionResult> AdminAddSkill([FromBody] AdminAddSkillModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("root"))
            {
                var Skill = new Skill
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = model.Name,
                    IsVerified = true

                };

                _context.Skills.Add(Skill);
                //user.SkillMatches.Add(Skill);
                _context.SaveChanges();
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("/Skill/Update")]
        public async Task<ActionResult> UpdateSkill([FromBody] ChangeSkillModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var roles = await _userManager.GetRolesAsync(user);
            var AllSkillMatches = _context.SkillMatches.Include(x => x.Skill).Where(x => x.Skill.Id == model.SkillId).FirstOrDefault();

            if (roles.Contains("root"))
            {
                AllSkillMatches.IsVerified = model.IsVerified;
                AllSkillMatches.Created = DateTime.Now;
                AllSkillMatches.Skill.Name = model.Name;
                AllSkillMatches.SkillLevel = model.SkillLevel;
                AllSkillMatches.YearsOfSkill = model.YearsOfSkill;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("/Skill/Delete")]
        public async Task<ActionResult> DeleteSkill([FromBody] RemoveSkillsModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var roles = await _userManager.GetRolesAsync(user);
            var AllSkills = _context.Skills.Include(x => x.skillMatches).Where(x => x.Id == model.SkillId).FirstOrDefault();
            var AllCompanySkillMatches = _context.SearchProfileSkillMatches.Where(x => x.Skill.Id == model.SkillId);
            //var AllSkillMatches = _context.SkillMatches.Include(x => x.Skill).Where(x => x.Skill.Id == model.SkillId);
            var AllSkillMatches = _context.SkillMatches.Where(x => x.Skill.Id == AllSkills.Id).ToList();
            if (roles.Contains("root"))
            {
                //_context.SkillMatches.Remove(skilMatch);
                foreach (var skillMatch in AllSkillMatches)
                {
                    _context.SkillMatches.Remove(skillMatch);
                }
                _context.SaveChanges();
                foreach (var companySkillMatch in AllCompanySkillMatches)
                {
                    _context.SearchProfileSkillMatches.Remove(companySkillMatch);
                }
                _context.Skills.Remove(AllSkills);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [Authorize]
        [HttpPost("/Skill/Get")]
        public async Task<ActionResult> GetSkill([FromBody] GetSkillModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var role = await _userManager.GetRolesAsync(user);
            if (role.Contains("root"))
            {
                var Skill = await _context.Skills.Where(x => x.Id == model.SkillId).FirstOrDefaultAsync();
                //var AllSkillMatches = _context.Skills.Where(x => x.Id == model.SkillId).FirstOrDefault();
                var response = new
                {
                    Name = Skill.Name,
                };

                return Ok(response);
            }
            else
            {

                var AllSkillMatches = _context.SkillMatches.Include(x => x.Skill).Include(x => x.User).Where(x => x.Skill.Id == model.SkillId).FirstOrDefault();
                //var AllSkillMatches = _context.Skills.Where(x => x.Id == model.SkillId).FirstOrDefault();
                var response = new
                {
                    Name = AllSkillMatches.Skill.Name,
                    SkillLevel = AllSkillMatches.SkillLevel,
                    YearsOfSkill = AllSkillMatches.YearsOfSkill,
                    IsVerified = AllSkillMatches.IsVerified,
                    Created = AllSkillMatches.Created
                };

                return Ok(response);
            }
        }
        [Authorize]
        [HttpPost("/Skill/Verify")]
        public async Task<ActionResult> VerifySkill([FromBody] VerifySkillModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var role = await _userManager.GetRolesAsync(user);

            if (role.Contains("root"))
            {
                var skill = await _context.Skills.Where(x => x.Id == model.SkillId).FirstOrDefaultAsync();
                skill.IsVerified = true;
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost("/Skill/Replace")]
        public async Task<ActionResult> ReplaceSkill([FromBody] ReplaceSkillModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var role = await _userManager.GetRolesAsync(user);

            if (role.Contains("root"))
            {
                var oldSkill = await _context.Skills.Where(x => x.Name == model.OldSkillName).FirstOrDefaultAsync();
                var newSkill = await _context.Skills.Where(x => x.Name == model.NewSkillName).FirstOrDefaultAsync();

                var studentSkillMatches = await _context.SkillMatches.Where(x => x.Skill.Id == oldSkill.Id).ToListAsync();
                var AllCompanySkillMatches = await _context.SearchProfileSkillMatches.Where(x => x.Skill.Id == oldSkill.Id).ToListAsync();
                if (newSkill != null)
                {
                    if (studentSkillMatches.Count != 0)
                    {
                        foreach (var skillMatch in studentSkillMatches)
                        {
                            skillMatch.Skill = newSkill;
                        }
                        _context.SaveChanges();

                    }
                    if (AllCompanySkillMatches.Count != 0)
                    {

                        foreach (var companySkillMatch in AllCompanySkillMatches)
                        {
                            companySkillMatch.Skill = newSkill;
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                else
                {
                    _context.Add(new Skill
                    {
                        IsVerified = true,
                        Name = model.NewSkillName,
                        Id = Guid.NewGuid().ToString()
                    });
                    await _context.SaveChangesAsync();
                    newSkill = await _context.Skills.Where(x => x.Name == model.NewSkillName).FirstOrDefaultAsync();
                    foreach (var skillMatch in studentSkillMatches)
                    {
                        skillMatch.Skill = newSkill;
                    }
                    _context.SaveChanges();
                    foreach (var companySkillMatch in AllCompanySkillMatches)
                    {
                        companySkillMatch.Skill = newSkill;
                    }
                    await _context.SaveChangesAsync();
                }

                _context.Skills.Remove(oldSkill);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost("/Skill/Edit")]
        public async Task<ActionResult> EditSkill([FromBody] EditSkillModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var role = await _userManager.GetRolesAsync(user);

            if (role.Contains("root"))
            {
                var skill = await _context.Skills.Where(x => x.Id == model.SkillId).FirstOrDefaultAsync();
                skill.Name = model.SkillName;
                if (!skill.IsVerified)
                {
                    skill.IsVerified = true;
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
        [HttpPost("/Skill/GetAll")]
        public async Task<ActionResult> GetAllSkills([FromBody] GetAllSkillsModel model)
        {

            string UserName;

            if(model.UserId == null)
            {
                UserName = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            }
            else
            {
                UserName = await _context.Users.Where(x => x.Id == model.UserId).Select(x => x.UserName).FirstOrDefaultAsync();
            }
            
            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var roles = await _userManager.GetRolesAsync(user);
            List<object> listOfSkills = new List<object>();


            if (roles.Contains("root"))
            {
                IQueryable<Skill> AllSkills = _context.Skills.Where(x => x == x);
                foreach (var skill in AllSkills)
                {
                    var response = new
                    {
                        Id = skill.Id,
                        Name = skill.Name,
                        IsVerified = skill.IsVerified


                    };
                    listOfSkills.Add(response);

                }
            }
            else
            {
                IQueryable<SkillMatch> AllSkillMatches = _context.SkillMatches.Include(x => x.Skill).Where(x => x.User.UserName == UserName);
                foreach (var skill in AllSkillMatches)
                {
                    var response = new
                    {
                        Id = skill.Skill.Id,
                        Name = skill.Skill.Name,
                        SkillLevel = skill.SkillLevel,
                        YearsOfSkill = skill.YearsOfSkill,
                        IsVerified = skill.Skill.IsVerified,
                        Created = skill.Created

                    };
                    listOfSkills.Add(response);

                }
            }

            // var AllSkillMatches = _context.Skills.Include(x => x.skillMatches).Select(x =>x).Where(x => x.Id == model.UserId);


            return Ok(listOfSkills);

        }

        [Authorize]
        [HttpPost("/Skill/GetAllVerifed")]
        public async Task<ActionResult> GetAllVerifed([FromBody] GetAllSkillsModel model)
        {
            List<object> listOfSkills = new List<object>();

            IQueryable<Skill> AllSkills = _context.Skills.Where(x => x.IsVerified).OrderBy(x => x.Name);
            foreach (var skill in AllSkills)
            {
                var response = new
                {
                    Id = skill.Id,
                    Name = skill.Name,
                    IsVerified = skill.IsVerified


                };
                listOfSkills.Add(response);

            }            
            // var AllSkillMatches = _context.Skills.Include(x => x.skillMatches).Select(x =>x).Where(x => x.Id == model.UserId);


            return Ok(listOfSkills);

        }
    }

}
