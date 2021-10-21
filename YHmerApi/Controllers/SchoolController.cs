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
    [Authorize]
    public class SchoolController : Controller
    {
        private Context _context;
        private UserManager<User> _userManager;

        public SchoolController(Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //[Authorize]
        [Authorize]
        [HttpPost("/School/Add")]
        public async Task<ActionResult> AddSchool([FromBody] AddSchoolModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var roles = _userManager.GetRolesAsync(user);
            if (roles.Result.Contains("organizer"))
            {
                var school = new School
                {
                    AboutSchool = model.About,
                    SchoolName = model.Name,
                    Orgnr = model.Orgnr,
                    ContactPerson = model.ContactPerson,
                    Contacts = model.Contacts,
                    StreetAdress = model.StreetAdress,
                    PostalCode = model.PostalCode,
                    PostalArea = model.PostalArea,
                    City = model.City
                };

                user.Schools.Add(school);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
        [Authorize]
        [HttpPost("/School/Delete")]
        public async Task<ActionResult> DeleteSchool([FromBody] RemoveSchoolModel model)
        {
            try
            {
                var school = await _context.Schools.Include(x => x.User).Include(x => x.Educations).ThenInclude(x => x.Courses).Where(x => x.ID == model.SchoolId).FirstOrDefaultAsync();
                if (school.User.UserName == User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value)
                {
                    _context.Schools.Remove(school);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPost("/School/Update")]
        public async Task<ActionResult> UpdateSchool([FromBody] UpdateSchoolModel model)
        {
            var claims = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;

            var user = await _context.Users.Where(u => u.UserName == claims)
                .Include(s => s.Schools)
                .FirstOrDefaultAsync();

            var school = await _context.Schools.Where(x => x.ID == model.SchoolId).FirstOrDefaultAsync(); //SchoolId blev UserName?

            
            if (user.Schools.Contains(school))
            {
                school.SchoolName = model.Name;
                school.AboutSchool = model.About;
                school.Orgnr = model.Orgnr;
                school.ContactPerson = model.ContactPerson;
                school.Contacts = model.Contacts;
                school.StreetAdress = model.StreetAdress;
                school.PostalCode = model.PostalCode;
                school.PostalArea = model.PostalArea;
                school.City = model.City;

                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }           
        }
        [AllowAnonymous]
        [HttpPost("/School/Get")]
        public async Task<ActionResult> GetSchool([FromBody] GetSchoolModel model)
        {
            var school = await _context.Schools.Where(x => x.ID == model.SchoolId).FirstOrDefaultAsync();
            var result = new SchoolModel
            {
                Id = school.ID,
                Name = school.SchoolName,
                About = school.AboutSchool,
                Orgnr = school.Orgnr,
                ContactPerson = school.ContactPerson,
                Contacts = school.Contacts,
                PostalCode = school.PostalCode,
                PostalArea = school.PostalArea,
                StreetAdress = school.StreetAdress,
                City = school.City,
            };
            return Ok(result);

        }
        [AllowAnonymous]
        [HttpPost("/School/GetAll")]
        public async Task<ActionResult> GetAllSchool([FromBody] GetSchoolsModel model)
        {
            var claims = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            var schools = await _context.Schools.Where(x => x.User.UserName == claims).ToListAsync();
            var listOfSchools = new List<SchoolModel>();

            foreach (var registeredSchool in schools)
            {
                var result = new SchoolModel
                {
                    Id = registeredSchool.ID,
                    Name = registeredSchool.SchoolName,
                    About = registeredSchool.AboutSchool,
                    Orgnr = registeredSchool.Orgnr,
                    ContactPerson = registeredSchool.ContactPerson,
                    Contacts = registeredSchool.Contacts,
                    StreetAdress = registeredSchool.StreetAdress,
                    PostalArea = registeredSchool.PostalArea,
                    PostalCode = registeredSchool.PostalCode,
                    City = registeredSchool.City
                };
                listOfSchools.Add(result);
            }
            return Ok(listOfSchools);
        }
    }
}
