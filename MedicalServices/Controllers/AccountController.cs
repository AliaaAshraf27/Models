﻿using AutoMapper;
using MedicalServices.AppMetaData;
using MedicalServices.DTO;
using MedicalServices.Models.Identity;
using MedicalServices.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalServices.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region fields
        private readonly IMapper _mapper;
        private readonly IRegisterServies _applicationUserServies;
        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructors
        // Constructor for injecting dependencies
        public AccountController(IMapper mapper,
                                  IRegisterServies applicationUserServices, ILoginService loginService, IConfiguration configuration, UserManager<User> userManager)
        {
            _mapper = mapper;
            _applicationUserServies = applicationUserServices;
            _loginService = loginService;
            _configuration = configuration;
            _userManager = userManager;
        }
        #endregion

        #region Controllers
        [HttpPost(Router.AccountRouting.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterDTO register)
        {
            // Mapping the AddUserCommandDTO to a User entity using AutoMapper
            var UserMapping = _mapper.Map<User>(register);

            // Calling the service to add the user and await the result
            var emailResult = await _applicationUserServies.AddUserAsync(UserMapping, register.Password);

            // Handling the result of the user addition
            switch (emailResult)
            {
                case "EmailIsExist":
                    return BadRequest("Email Is already Exist");
                case "Failed":
                    return BadRequest("Failed To Register ");
                case "Success":
                    var token = GenerateJwtToken(register.Email);
                    // Create a new object that only includes the fields you want to return
                    var response = new
                    {
                        Message = "Register successful",
                        id = UserMapping.Id,
                        Token = new
                        {
                            Result = token.Result
                        }
                    };
                    return Ok(response);
                default:
                    return BadRequest();
            }
        }

        [HttpPost(Router.AccountRouting.Login)]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            // Calling the service to log the user in and await the result
            var loginResult = await _loginService.LogUserAsync(login.Email, login.Password);
            var userId = await _loginService.GetId(login.Email);
            if (userId == null)
                return NotFound("Not found");

            // Handling the result of the user login
            switch (loginResult)
            {
                case "EmailIsNotExist":
                    return BadRequest("Email Does Not Exist");
                case "PasswordIsNotCorrect":
                    return BadRequest("Password Is Not Correct");
                case "Failed":
                    return BadRequest("Failed To Login ");
                case "Success":
                    var token = GenerateJwtToken(login.Email);
                    // Create a new object that only includes the fields you want to return
                    var response = new
                    {
                        Message = "Login successful",
                        Id = userId,
                        Token = new
                        {
                            Result = token.Result
                        }
                    };
                    return Ok(response);

                default:
                    return BadRequest();
            }
        }

        //private async Task<string> GenerateJwtToken(string email)
        //{
        //    var jwtSettings = _configuration.GetSection("Jwt");

        //    // Define the token's claims
        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, email),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(ClaimTypes.Email, email)
        //    };

        //    // Generate the token
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: jwtSettings["Issuer"],
        //        audience: jwtSettings["Audience"],
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddHours(1), // Token expiry time
        //        signingCredentials: creds
        //    );

        //    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        //    // Store the token
        //    await _loginService.StoreTokenAsync(email, tokenString);

        //    return tokenString;
        //}

        private async Task<string> GenerateJwtToken(string email)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var user = await _loginService.getUserByEmail(email);
            // Fetch user roles
            var roles = await _userManager.GetRolesAsync(user);



            // Define the token's claims
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Email, email),
            };



            // Add roles to claims
            claims.AddRange(roles.Select(role => new Claim("role", role)));

            // Generate the token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expiry time
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            // Store the token
            await _loginService.StoreTokenAsync(email, tokenString);

            return tokenString;
        }
        #endregion
    }
}
