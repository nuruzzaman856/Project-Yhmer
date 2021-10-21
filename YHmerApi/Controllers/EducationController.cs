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
    public class EducationController : ControllerBase
    {
        private Context _context;
        private UserManager<User> _userManager;

        public EducationController(Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize]
        [HttpPost("/Education/Add")]
        public async Task<ActionResult> AddEducation([FromBody] AddEducationModel model)
        {

            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("organizer"))
            {
                try
                {
                    var registrationCode = "";
                    bool IsCodeUnique = false;
                    var school = _context.Schools.Include(x => x.Educations).Where(x => x.ID == model.SchoolId).FirstOrDefault();
                    while(!IsCodeUnique)
                    {
                        registrationCode = ToolBox.GenerateCode();
                        if(!await _context.Educations.AnyAsync(c => c.RegisterCode == registrationCode))
                        {
                            IsCodeUnique = true;
                        }
                    }
                    Education newEducation = new Education
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = model.Name,
                        City = model.City,
                        IsLiaCourses = model.IsLiaCourses,
                        Points = model.Points,
                        SearchingForBoardMembers = model.SearchingForBoardMembers,
                        About = model.About,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate,
                        YHNumber = model.YHNumber,
                        LastDateForApplication = model.LastDateForApplication,
                        RegisterCode = registrationCode
                    };

                    school.Educations.Add(newEducation);
                    _context.SaveChanges();
                    return Ok();

                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost("/Education/Update")]
        public async Task<ActionResult> UpdateEducation([FromBody] ChangeEducationModel model)
        {
            var education = await _context.Educations.Include(x => x.School).ThenInclude(x => x.User).Where(x => x.Id == model.EducationID).FirstOrDefaultAsync();
            if (education.School.User.UserName == User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value)
            {
                education.Name = model.Name;
                education.IsLiaCourses = model.IsLiaCourses;
                education.Points = model.Points;
                education.City = model.City;
                education.SearchingForBoardMembers = model.SearchingForBoardMembers;
                education.About = model.About;
                education.StartDate = model.StartDate;
                education.EndDate = model.EndDate;
                education.YHNumber = model.YHNumber;
                education.LastDateForApplication = model.LastDateForApplication;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost("/Education/Delete")]
        public async Task<ActionResult> DeleteEducation([FromBody] RemoveEducationModel model)
        {
            var education = await _context.Educations.Include(c => c.School).ThenInclude(x => x.User).Where(x => x.Id == model.EducationId).FirstOrDefaultAsync();
            if (education.School.User.UserName == User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value)
            {
                var courses = _context.Courses.Where(x => x.Education.Id == model.EducationId);
                foreach (var Course in courses)
                {
                    _context.Courses.Remove(Course);
                }
                _context.Educations.Remove(education);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
        [Authorize]
        [HttpPost("/Education/Get")]
        public async Task<ActionResult> GetEducation([FromBody] GetEducationModel model)
        {
            var education = await _context.Educations.Include(x => x.Courses).Where(x => x.Id == model.EducationId).FirstOrDefaultAsync();

            var response = new
            {
                City = education.City,
                Id = education.Id,
                Name = education.Name,
                Points = education.Points,
                IsLiaCourses = education.IsLiaCourses,
                SearchingForBoardMembers = education.SearchingForBoardMembers,
                About = education.About,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                YHNumber = education.YHNumber,
                LastDateForApplication = education.LastDateForApplication,
                RegisterCode = education.RegisterCode,
                //Courses = new List<Course>() {  }
            };
            //foreach (var course in education.Courses )
            //{
            //    response.Courses.Add(course);
            //}

            return Ok(response);
        }

        [Authorize]
        [HttpPost("/Education/GetAll")]
        public async Task<ActionResult> GetAllEducation([FromBody] GetAllEducationsModel model)
        {
            var educations = await _context.Educations.Where(x => x.School.ID == model.SchoolId).ToListAsync();
            List<object> listOfEducation = new List<object>();
            foreach (var education in educations)
            {
                var response = new
                {
                    City = education.City,
                    Id = education.Id,
                    Name = education.Name,
                    Points = education.Points,
                    IsLiaCourses = education.IsLiaCourses,
                    SearchingForBoardMembers = education.SearchingForBoardMembers,
                    About = education.About,
                    StartDate = education.StartDate,
                    EndDate = education.EndDate,
                    YHNumber = education.YHNumber,
                    LastDateForApplication = education.LastDateForApplication

                };
                listOfEducation.Add(response);

            }
            return Ok(listOfEducation);

        }
    }
}
