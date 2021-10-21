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
    public class CoursesController : ControllerBase
    {
        private Context _context;
        private UserManager<User> _userManager;

        public CoursesController(Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize]
        [HttpPost("/Course/Add")]
        public async Task<ActionResult> AddCourse([FromBody] AddCourseModel model)
        {
            var educations = await _context.Educations.Include(x => x.School).ThenInclude(x => x.User).Where(x => x.Id == model.EducationId).FirstOrDefaultAsync();
            if (educations.School.User.UserName == User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value)
            {
                var newCourse = new Course
                {
                    IsLiaCourse = model.IsLiaCourse,
                    Location = model.Location,
                    Name = model.Name,
                    Points = model.Points,
                    SearchingForEducator = model.SearchingForEducators,
                    SearchingForGuestLecturer = model.SearchingForGuestLecturer,
                    About = model.About,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                };
                educations.Courses.Add(newCourse);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPost("/Course/Update")]
        public async Task<ActionResult> UpdateCourse([FromBody] ChangeCourseModel model)
        {
            var course = await _context.Courses.Include(x => x.Education).ThenInclude(x => x.School).ThenInclude(x => x.User).Select(x => x).Where(x => x.Id == model.CourseId).FirstOrDefaultAsync();
            if(course.Education.School.User.UserName == User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value && course.Education.Id == model.EducationId)
            {
                course.Name = model.Name;
                course.Location = model.Location;
                course.Points = model.Points;
                course.IsLiaCourse = model.IsLiaCourse;
                course.SearchingForEducator = model.SearchingForEducators;
                course.SearchingForGuestLecturer = model.SearchingForGuestLecturer;
                course.About = model.About;
                course.StartDate = model.StartDate;
                course.EndDate = model.EndDate;
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();

        }
        [Authorize]
        [HttpPost("/Course/Delete")]
        public async Task<ActionResult> DeleteCourse([FromBody] DeleteCourseModel model)
        {
            var course = await _context.Courses.Include(c => c.Education).ThenInclude(x => x.School).ThenInclude(x => x.User).Where(x => x.Id == model.CourseId).FirstOrDefaultAsync();

            if (course.Education.School.User.UserName == User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost("/Course/Get")]
        public async Task<ActionResult> GetCourse([FromBody] GetCourseModel model)
        {
            var course = await _context.Courses.Where(x => x.Id == model.CourseId).FirstOrDefaultAsync();
            //return Ok(course);

            //var education = _context.Educations.Include(x => x.Courses).Where(x => x.Id == model.EducationId).FirstOrDefault();

            var response = new
            {
                Location = course.Location,
                Id = course.Id,
                Name = course.Name,
                Points = course.Points,
                IsLiaCourses = course.IsLiaCourse,
                SearchingForEducators = course.SearchingForEducator,
                SearchingForGuestLecturer = course.SearchingForGuestLecturer,
                About = course.About,
                StartDate = course.StartDate,
                EndDate =course.EndDate
                

                
            };
            return Ok(response);
        }
        [Authorize]
        [HttpPost("/Course/GetAll")]
        public async Task<ActionResult> GetAllCourses([FromBody] GetAllCoursesModel model)
        {
            var courses = await _context.Courses.Include(x => x.Education).Where(x => x.Education.Id == model.EducationId).ToListAsync();
            List<object> listOfCourses = new List<object>();
            foreach (var course in courses)
            {
                var response = new
                {
                    Location = course.Location,
                    Id = course.Id,
                    Name = course.Name,
                    Points = course.Points,
                    IsLiaCourses = course.IsLiaCourse,
                    SearchingForEduators = course.SearchingForEducator,
                    SearchingForGuestLecturer = course.SearchingForGuestLecturer,
                    About = course.About,
                    StartDate = course.StartDate,
                    EndDate = course.EndDate


                };
                listOfCourses.Add(response);
            }
            return Ok(listOfCourses);
        }
    }
}
