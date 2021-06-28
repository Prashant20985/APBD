using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace tutorial_8.Helpers
{
    public static class SecurityHelpers
    {
        public static Tuple<string,string> GetHashPasswordSalt(string Password)
        {
            byte[] salt = new byte[128 / 8];

            using (var rnd = RandomNumberGenerator.Create())
            {
                rnd.GetBytes(salt);
            }

            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount:10000,
                numBytesRequested:256/8
                ));
            string saltBase64 = Convert.ToBase64String(salt);
            return new(hash, saltBase64);
        }

        public static string GetHashPasswordWithSalt(string Password,string salt)
        {
            byte[] saltByte = Convert.FromBase64String(salt);

            string currentHashPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password:Password,
                salt: saltByte,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount:10000,
                numBytesRequested:256/8
                ));
            return currentHashPassword;
        }

        public static string RefreshToken()
        {
            var randNum = new byte[32];

            using (var rnd = RandomNumberGenerator.Create())
            {
                rnd.GetBytes(randNum);
                return Convert.ToBase64String(randNum);
            }
        }

        public static string GetUserIdFromAccToken(string AccessToken, string secret)
        {
            var tokenValidParametes = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateActor = true,
                ClockSkew = TimeSpan.FromMinutes(2),
                ValidIssuer = "",
                ValidAudience = "",
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(AccessToken, tokenValidParametes, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if(jwtSecurityToken == null || jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid Token");
            }

            var UserId = principal.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(UserId))
            {
                throw new SecurityTokenException($"Missing Clain:  {ClaimTypes.Name}");
            }
            return UserId;
        }
    }
}
