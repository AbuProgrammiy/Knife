using Microsoft.Extensions.Configuration;   // Iconfiguration ishlashi uchun
using Microsoft.IdentityModel.Tokens;       // SymmetricSecurityKey, SigningCredentials, EpochTime ishlashi uchun
using Project.Domen.Entities.Models;        // User model ishlashi uchun 
using System.Globalization;                 // CultureInfo ishlashi uchun    
using System.IdentityModel.Tokens.Jwt;      // JwtRegisteredClaimNames, JwtSecurityToken ishlashi uchun
using System.Security.Claims;               // Claim ishlashi uchun 
using System.Text;                          // Encoding ishlashi uchun

namespace Project.Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private IConfiguration _config;
        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_config["JWT:Expire"]!);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture),ClaimValueTypes.Integer64),

                new Claim("UserName",user.UserName!),
                new Claim(ClaimTypes.Role,user.Role!),
                new Claim("isAdmin",user.IsAdmin.ToString()),
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudence"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: credentials);

            string Token = new JwtSecurityTokenHandler().WriteToken(token);
            return $"Your Toke: {Token}";
        }
    }
}
