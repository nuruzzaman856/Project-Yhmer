using Api.Areas.Identity.Data;
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
    [Authorize]
    public class EducationStudentsController : Controller
    {
        private Context _context;
        private readonly UserManager<User> _userManager;

        public EducationStudentsController(Context context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost("/EducationStudents/Verify")]
        public async Task<ActionResult> VerifyStudent([FromBody] VerifyStudentModel model)
        {
            var UserName = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            var user = await _userManager.FindByNameAsync(UserName);
            var EducationStudent = await _context.EducationStudent.Where(x => x.User.Id == model.StudentId && x.Education.Id == model.EducationId && x.Education.School.User.UserName == UserName).FirstOrDefaultAsync();
            if (EducationStudent != null)
            {
                EducationStudent.IsVerified = true;
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("/EducationStudents/Add")]
        public async Task<ActionResult> CreateEducationStudents([FromBody] AddEducationStudentsModel model)
        {
            var UserName = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            var user = await _userManager.FindByNameAsync(UserName);

            var education = await _context.Educations.Where(x => x.RegisterCode == model.EducationCode).FirstOrDefaultAsync();

            var _educationStudent = new EducationStudent
            {
                Id = Guid.NewGuid().ToString(),
                Education = education,
                User = user,
                IsVerified = false
            };

            await _context.EducationStudent.AddAsync(_educationStudent);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize]
        [HttpPost("/EducationStudents/Remove")]
        public async Task<ActionResult> RemoveEducationStudents([FromBody] VerifyStudentModel model)
        {
            var UserName = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            var user = await _userManager.FindByNameAsync(UserName);

            var EducationStudent = await _context.EducationStudent.Where(x => x.User.Id == model.StudentId && x.Education.Id == model.EducationId && x.Education.School.User.UserName == UserName).FirstOrDefaultAsync();

            if(EducationStudent != null)
            {
                _context.EducationStudent.Remove(EducationStudent);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost("/EducationStudents/Student/Get")]
        public async Task<ActionResult> StudentGetEducationStudents()
        {
            var UserName = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            var user = await _userManager.FindByNameAsync(UserName);

            var studentEducation = await _context.EducationStudent.Include(x => x.Education).ThenInclude(x => x.School).Where(x => x.User.Id == user.Id).FirstOrDefaultAsync();
            var courses = await _context.Courses.Where(x => x.Education.Id == studentEducation.Education.Id).ToListAsync();
            var Response = new
            {
                IsStudentVerified = studentEducation.IsVerified,
                SchoolName = studentEducation.Education.School.SchoolName,
                EducationName = studentEducation.Education.Name,
                Points = studentEducation.Education.Points,
                StartDate = studentEducation.Education.StartDate,
                EndDate = studentEducation.Education.EndDate,
                About = studentEducation.Education.About,
                City = studentEducation.Education.City,
                courses = new List<dynamic>()
            };

            foreach (var course in courses)
            {
                Response.courses.Add(new 
                {
                    Name = course.Name,
                    Points = course.Points,
                    StartDate= course.StartDate,
                    EndDate= course.EndDate,

                });
            }
            return Ok(Response);

        }
        [Authorize]
        [HttpPost("/EducationStudents/GetAll")]
        public async Task<ActionResult> GetAllEducationStudents()
        {
            var UserName = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            var user = await _userManager.FindByNameAsync(UserName);

            var EducationsStudents = await _context.EducationStudent.Include(x => x.User).Include(x => x.Education).Where(x => x.Education.School.User.UserName == UserName).ToListAsync();

            if (EducationsStudents.Count > 0)
            {
                var Response = new List<dynamic>();

                foreach (var educationStudent in EducationsStudents)
                {
                    var _educationStudent = new
                    {
                        StudentId = educationStudent.User.Id,
                        FirstName = educationStudent.User.FirstName,
                        LastName = educationStudent.User.LastName,
                        IsVerified = educationStudent.IsVerified,
                        EducationID = educationStudent.Education.Id,
                        EducationName = educationStudent.Education.Name
                    };

                    Response.Add(_educationStudent);
                }
                return Ok(Response);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
