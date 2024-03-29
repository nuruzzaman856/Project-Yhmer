﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Models;
using Api.Areas.Identity.Data;
using Api.Areas.Identity.Data.Entities;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    // Give it the [Authorize] attribute. It will bypass the autentication without it.  
    [Authorize]
    public class AuthController : ControllerBase
    {

        private Context _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(Context context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Use [AllowAnonymous] for methods anyone can use, Such as login and register. 
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {

            User user = model.User.Contains("@") ? await _userManager.FindByEmailAsync(model.User) : await _userManager.FindByNameAsync(model.User);
            if (user != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (signInResult.Succeeded)
                {

                    var roles = await _userManager.GetRolesAsync(user);
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("default-key-xxxx-aaaa-qqqq-default-key-xxxx-aaaa-qqqq");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {


                        // Add your claims to the JWT token
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.Role, roles.First().ToString())
                            
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Ok("No user or password matched, try again.");
                }
            }
            else
            {
                return Ok("No such user exists");
            }
        
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterModel model)
        {
            // Always better with a global try catch

            User newUser = new User()
            {
                Email = model.Email,
                UserName = model.Username,
                AgreedToTerms = model.AgreedToTerms,
                // Its always best practice to have some form of verification. this is off for simplicity
                EmailConfirmed = false,
                Id = Guid.NewGuid().ToString()
                //PasswordHash = model.Password
                // Set your customs
                //MyProperty = 13
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
            {
                var exceptionText = result.Errors.Aggregate("User Creation Failed - Identity Exception. Errors were: \n\r\n\r", (current, error) => current + (" - " + error + "\n\r"));
                throw new Exception(exceptionText);
            }
            if (result.Succeeded)
            {
                User user = await _userManager.FindByNameAsync(newUser.UserName);
                if (user is not null)
                {
                    await _userManager.AddToRoleAsync(newUser, model.Role);

                    //Remember to set your custom data and relationships here

                   UserSettings settings = new UserSettings()
                   {
                       Id = Guid.NewGuid().ToString(),
                       DarkMode = true,
                       User = user
                   };

                    UserGDPR gdpr = new UserGDPR()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UseMyData = false,
                        User = user
                    };

                    //Add it to the context
                    _context.UserSettings.Add(settings);
                    _context.UserGDPR.Add(gdpr);

                    //Save the data
                    _context.SaveChanges();

                    return Ok(new { result = $"User {model.Username} has been created", Token = "xxx" });
                }
                else
                {
                    return Ok(new { message = "Registration failed for unknown reasons, please try again." });
                }
            }
            else
            {
                StringBuilder errorString = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    errorString.Append(error.Description);
                }

                return Ok(new { result =  $"Register Fail: {errorString.ToString()}"});
            }

        }

        [Authorize]
        [HttpPost("changepassword")]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {

            if (model.NewPassword == model.ConfirmNewPassword)
            {
                User user = ToolBox.IsValidEmail(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email)).Value) ? await _userManager.FindByEmailAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email)).Value) : await _userManager.FindByNameAsync(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value);

                if (user is not null)
                {
                    if (await _userManager.CheckPasswordAsync(user, model.CurrentPassword))
                    {
                        await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                        return Ok(new { message = "Password has been updated." });
                    }
                    else
                    {
                        return Ok(new { message = $"Your password is incorrect. ({user.AccessFailedCount}) failed attempts." });
                    }
                }
                else
                {
                    return Ok(new { message = "No such user found." });
                }
            }
            else
            {
                return Ok(new { message = "Your password does not match." });
            }
        
        }

    }
}
