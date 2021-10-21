using Api.Areas.Identity.Data;
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
using static Api.Areas.Identity.Data.User;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : Controller
    {
        private Context _context;
        private readonly UserManager<User> _userManager;

        public ProfileController(Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("getcontext")]
        public async Task<ActionResult> GetProfileContext()
        {
            var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            //var user = await _context.Users.Where(x => x.UserName == userClaims.UserName).FirstOrDefaultAsync();


            //User user = null;
            //if(model.Id == null)
            //{
            //    var userName = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            //    user = await _context.Users.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            //}
            //else
            //{
            //    user = await _context.Users.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            //}

            return Ok(user);
        }

        [Authorize]
        [HttpPost("update")]
        public async Task<ActionResult> Update([FromBody] UpdateModel model)
        {
            // Always better with a global try catch
            try
            {
                var user = await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
                if (!string.IsNullOrEmpty(model.FirstName))
                {
                    user.FirstName = model.FirstName;
                }
                if (!string.IsNullOrEmpty(model.LastName))
                {
                    user.LastName = model.LastName;

                }
                user.About = model.About;
                user.PhoneNumber = model.PhoneNumber;
                user.Adress = model.Address;
                if (!string.IsNullOrEmpty(model.OrgNumber))
                {
                    user.OrgNumber = model.OrgNumber;
                }
                if (!string.IsNullOrEmpty(model.CompanyName))
                {
                    user.CompanyName = model.CompanyName;
                }
                if (!string.IsNullOrEmpty(model.ContactPerson))
                {
                    user.ContactPerson = model.ContactPerson;
                }
                user.City = model.City;
                user.PostalArea = model.PostalArea;
                user.PostalCode = model.PostalCode;
                user.VisibleProfile = model.Visible;
                _context.SaveChanges();
                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [Authorize]
        [HttpPost("delete")]
        public async Task<ActionResult> Delete([FromBody] DeleteModel model)
        {
            // Always better with a global try catch
            var user = await _context.Users.Include(x => x.Schools).ThenInclude(x => x.Educations).ThenInclude(x => x.Courses).Where(x => x.UserName == User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value).FirstOrDefaultAsync();
            _context.Remove(user);
            _context.SaveChanges();
            return Ok();
        }

        //[HttpPost("update")]
        //[AllowAnonymous]
        //public async Task<ActionResult> UpdateProfile([FromBody] UpdateDemoTable model)
        //{s

        //    //string username = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;

        //    //_context.Users.Where(x => x.NormalizedUserName == username.ToUpper()).First().UserSpecification.About = model.About;

        //    _context.DemoTable.Where(x => x.Id == model.Id).First().About = model.About;


        //    _context.SaveChanges();

        //    return Ok("Ok");
        //}


        //[HttpPost("addprofile")]
        //[AllowAnonymous]
        //public async Task<ActionResult> AddProfile([FromBody] UpdateAboutMeModel model)
        //{

        //    DemoTable dt = new DemoTable();

        //    _context.DemoTable.Add(dt);

        //    _context.SaveChanges();

        //    return Ok("Ok");
        //}


    }
}
