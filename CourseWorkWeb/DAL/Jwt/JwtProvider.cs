using CourseWorkWeb.DAL.Context;
using CourseWorkWeb.Models.Entity.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace CourseWorkWeb.DAL.Jwt
{
    public class JwtProvider(IOptions<JwtOptions> options,MedicineDataContext dataContext) : IJwtProvider
    {
        private readonly IOptions<JwtOptions> _options = options;
        private readonly MedicineDataContext _dataContext = dataContext;

        public string GenerateToken(Account user)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            
            var permissions = _dataContext.RolesPermissions
                .Where(rp => rp.RoleId == user.RoleId)
                .Select(rp => rp.Permission)
                .ToList();
           var actions = permissions.Select(p => p.Action).ToList();
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            claims.AddRange(actions.Select(action => new Claim(action, "true")).ToArray());
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(config["JwtOptions:SecretKey"])),
                    SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(double.Parse(config["JwtOptions:ExpiresHours"]))
                );
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
