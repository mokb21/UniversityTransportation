using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UniversityTransportation.Data.Models;
using UniversityTransportation.Enums;
using UniversityTransportation.Interfaces.Services;
using UniversityTransportation.Models;

namespace UniversityTransportation.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IDriverService _driverService;
        private readonly IPassengerService _passengerService;

        public AccountsController(
            ILogger<AccountsController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IDriverService driverService,
            IPassengerService passengerService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _driverService = driverService;
            _passengerService = passengerService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                return await GenerateProfileWithToken(model);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            try
            {
                if (model.UserName != null &&
                    model.Email != null &&
                    model.Password != null &&
                    model.Password == model.ConfirmPassword)
                {
                    var user = new ApplicationUser
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        Role = (byte)UserRoles.Admin,
                        PhoneNumber = model.Phone,
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                        return Ok();
                    else
                        return BadRequest();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterDriver([FromBody] DTO.Accounts.Driver model)
        {
            try
            {
                if (model.UserName != null &&
                    model.Email != null &&
                    model.Password != null &&
                    model.Password == model.ConfirmPassword)
                {
                    var user = new ApplicationUser
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        Role = (byte)UserRoles.Driver,
                        PhoneNumber = model.Phone,
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return Ok(await _driverService.AddDriverToUserAsync(model, user));
                    }
                    else
                        return BadRequest();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterPassenger([FromBody] DTO.Accounts.Passenger model)
        {
            try
            {
                if (model.UserName != null &&
                    model.Email != null &&
                    model.Password != null &&
                    model.Password == model.ConfirmPassword)
                {
                    var user = new ApplicationUser
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        Role = (byte)UserRoles.Passenger,
                        PhoneNumber = model.Phone,
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return Ok(await _passengerService.AddDPassengerToUserAsync(model, user));
                    }
                    else
                        return BadRequest();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        private async Task<IActionResult> GenerateProfileWithToken(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        token = await GetToken(user),
                        user = new
                        {
                            id = user.Role == (byte)UserRoles.Passenger ? user.PassengerId.Value :
                                user.Role == (byte)UserRoles.Driver ? user.DriverId.Value :
                                user.Id,
                            role = user.Role,
                            userName = user.UserName,
                        }
                    });
                }

                return BadRequest();
            }

            return NotFound();
        }

        private async Task<object> GetToken(ApplicationUser user)
        {
            try
            {
                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            };

                var roles = await _userManager.GetRolesAsync(user);

                foreach (var role in roles)
                {
                    claims.Add(new Claim("roles", role));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.ConfigurationConstants.TokenKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    Constants.ConfigurationConstants.TokenIssuer,
                    Constants.ConfigurationConstants.TokenIssuer,
                    claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: creds);

                return new { Status = "Success", Token = new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo };
            }
            catch (Exception ex)
            {
                return new { Status = "Failed" };
            }

        }
    }
}