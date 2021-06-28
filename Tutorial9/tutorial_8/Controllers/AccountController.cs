using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using tutorial_8.DTOs.Request;
using tutorial_8.DTOs.Response;
using tutorial_8.Helpers;
using tutorial_8.Models;
using tutorial_8.Models.Authentication;

namespace tutorial_8.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Clinic_DbContext _context;
        private readonly IConfiguration _configuration;

        public AccountController (Clinic_DbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task Register(RegisterRequest reg)
        {
            var hashPassSalt = SecurityHelpers.GetHashPasswordSalt(reg.Password);

            var AppUser = new AppUser()
            {
                Login = reg.Login,
                Password = hashPassSalt.Item1,
                Salt = hashPassSalt.Item2,
                RefreshToken = SecurityHelpers.RefreshToken(),
                RefresHTokentExpirration = DateTime.Now.AddMinutes(10)
            };
            await _context.AppUsers.AddAsync(AppUser);
            await _context.SaveChangesAsync();
        }
        
        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public async Task<AccountResponceDto> Login(LoginRequestDto loginRequest)
        {
            AppUser appUser = _context.AppUsers.FirstOrDefault(x => x.Login == loginRequest.Login);

            string passwordHash = appUser.Password;
            string currentHashPass = SecurityHelpers.GetHashPasswordWithSalt(loginRequest.Password, appUser.Salt);

            if(passwordHash != currentHashPass)
            {
                throw new UnauthorizedAccessException();
            }
            else
            {
                Claim[] claims = new[]
                {
                    new Claim(ClaimTypes.Name,"Prashant"),
                    new Claim(ClaimTypes.Role,"admin"),
                    new Claim(ClaimTypes.Role,"user")
                };
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret"]));

                SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "http://localhost:53959",
                    audience: "http://localhost:53959",
                    claims: claims,
                    expires:DateTime.Now.AddMinutes(10),
                    signingCredentials: creds
                    );

                appUser.RefreshToken = SecurityHelpers.RefreshToken();
                appUser.RefresHTokentExpirration = DateTime.Now.AddDays(1);
                await _context.SaveChangesAsync();

                var result = new AccountResponceDto
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = appUser.RefreshToken
                };
                return result;
            }
        }

        [AllowAnonymous]
        [Route("Refresh")]
        [HttpPost]
        public async Task<AccountResponceDto> Refresh(string token, RefreshTokenRequest refreshToken)
        {
            AppUser appUser = _context.AppUsers.FirstOrDefault(x => x.RefreshToken == refreshToken.RefreshToken);

            if(appUser == null || appUser.RefresHTokentExpirration < DateTime.Now)
            {
                throw new SecurityTokenException("Invalid");
            }

            var login = SecurityHelpers.GetUserIdFromAccToken(token.Replace("Bearer ", ""), _configuration["Secret"]);

                Claim[] claims = new[]
                {
                    new Claim(ClaimTypes.Name,"Prashant"),
                    new Claim(ClaimTypes.Role,"admin"),
                    new Claim(ClaimTypes.Role,"user")
                };
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret"]));

                SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken newTok = new JwtSecurityToken(
                    issuer: "http://localhost:53959",
                    audience: "http://localhost:53959",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: creds
                    );

                appUser.RefreshToken = SecurityHelpers.RefreshToken();
                appUser.RefresHTokentExpirration = DateTime.Now.AddDays(1);
                await _context.SaveChangesAsync();

                var result = new AccountResponceDto
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(newTok),
                    RefreshToken = appUser.RefreshToken
                };
                return result;

            }

    }
}
