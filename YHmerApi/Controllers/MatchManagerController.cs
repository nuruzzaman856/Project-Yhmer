using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Areas.Identity.Data;
using Api.Data;
using Api.Data.Entities;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchManagerController : ControllerBase
    {
        public readonly Context _context;
        public UserManager<User> _user;
        public MatchManagerController(Context context, UserManager<User> user)
        {
            _context = context;
            _user = user;
        }

        [Authorize]
        [HttpPost("Selection")]
        public async Task<ActionResult> MatchManager([FromBody] MatchManagerModel model)
        {
            var user = await _user.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var matchManager = await _context.MatchManager.Where(x => x.SearchProfileId == model.SearchProfileId && x.User.Id == user.Id).FirstOrDefaultAsync();

            if (matchManager == null)
            {
                var selection = new MatchManager()
                {
                    Id = Guid.NewGuid().ToString(),
                    User = user,
                    MatchedSearchProfileId = model.MatchedSearchProfileId,
                    SearchProfileId = model.SearchProfileId,
                    AcceptedLIA = model.AcceptedLIA,
                    DeclinedLIA = model.DeclinedLIA,
                    AcceptedJob = model.AcceptedJob,
                    DeclinedJob = model.DeclinedJob
                    

                };
                _context.Add(selection);
                await _context.SaveChangesAsync();

            }
            else
            {
                matchManager.User = user;
                matchManager.MatchedSearchProfileId = model.MatchedSearchProfileId;
                matchManager.SearchProfileId = model.SearchProfileId;
                matchManager.AcceptedLIA = model.AcceptedLIA;
                matchManager.DeclinedLIA = model.DeclinedLIA;
                matchManager.AcceptedJob = model.AcceptedJob;
                matchManager.DeclinedJob = model.DeclinedJob;

                await _context.SaveChangesAsync();
            }


            return Ok();
        }

        [Authorize]
        [HttpPost("Get/MatchManagers")]
        public async Task<ActionResult> GetAllMatchManagers([FromBody] MatchManagerModel model)
        {
            var user = await _user.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var matchManager = await _context.MatchManager.Where(x => x.SearchProfileId == model.SearchProfileId && x.User.Id == user.Id).FirstOrDefaultAsync();

            if(matchManager != null)
            {
            var respons = new
            {
                MatchedSearchProfileId = matchManager.MatchedSearchProfileId,
                SearchProfileId = matchManager.SearchProfileId,
                AcceptedLIA = matchManager.AcceptedLIA,
                DeclinedLIA = matchManager.DeclinedLIA,
                AcceptedJob = matchManager.AcceptedJob,
                DeclinedJob = matchManager.DeclinedJob
            };

                return Ok(respons);
            }
            else
            {
            return Ok(matchManager);
            }



        }

        [Authorize]
        [HttpGet("Get/MatchManager/Messages")]
        public async Task<ActionResult> GetMatchMessages()
        {

            var respons = new List<MatchMessagesModel>();
            var matches = new List<MatchManager>();
            List<MatchManager> matchedSearchProfiles = new List<MatchManager>();
            SearchProfile cProfile = new SearchProfile();
            StudentSearchProfile sProfile = new StudentSearchProfile();
            var Respons = new MatchMessagesModel();


            var user = await _user.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);
            var role = await _user.GetRolesAsync(user);

            var matchManager = await _context.MatchManager.Where(x => x.User.Id == user.Id).ToListAsync();


            if (role.Contains("student"))
            {
                foreach (var Match in matchManager)
                {
                    matchedSearchProfiles = await _context.MatchManager.Where(x => x.MatchedSearchProfileId == Match.SearchProfileId).ToListAsync();

                    foreach (var match in matchedSearchProfiles)
                    {
                        matches.Add(match);
                    }

                }

                foreach (var MatchedProfile in matches)
                {


                    cProfile = await _context.SearchProfiles.Where(x => x.Id == MatchedProfile.SearchProfileId).Include(x => x.User).FirstOrDefaultAsync();

                    Respons = new MatchMessagesModel()
                    {
                        AcceptedJob = MatchedProfile.AcceptedJob,
                        AcceptedLIA = MatchedProfile.AcceptedLIA,
                        Name = cProfile.Name,
                        Role = cProfile.Role,
                        Id = cProfile.Id,
                        UserName = cProfile.User.CompanyName.ToString()
                    };
                    respons.Add(Respons);
                }

            }

            if (role.Contains("company"))
            {
                foreach (var MatchedProfile in matchManager)
                {


                    sProfile = await _context.StudentSearchProfiles.Where(x => x.Id == MatchedProfile.MatchedSearchProfileId).Include(x => x.User).FirstOrDefaultAsync();
                    cProfile = await _context.SearchProfiles.Where(x => x.Id == MatchedProfile.SearchProfileId).Include(x => x.User).FirstOrDefaultAsync();

                    Respons = new MatchMessagesModel()
                    {
                        AcceptedJob = MatchedProfile.AcceptedJob,
                        AcceptedLIA = MatchedProfile.AcceptedLIA,
                        Name = cProfile.Name,
                        Role = cProfile.Role,
                        Id = sProfile.User.Id,
                        UserName = sProfile.User.UserName.ToString()
                    };

                    respons.Add(Respons);
                }
            }


            return Ok(respons);
        }
    }
}
