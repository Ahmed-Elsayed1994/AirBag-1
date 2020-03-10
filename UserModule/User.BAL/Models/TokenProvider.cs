using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace User.BAL.Models
{
    public class TokenProvider
    {
        private readonly IConfiguration _configuration;
        public Claim[] Claims
        {
            get;
            set;
        }
        private readonly AppSettings _appSettings;
        public TokenProvider(IConfiguration configuration,
            IOptions<AppSettings> appSettings)
        {
            _configuration = configuration;
            _appSettings = appSettings.Value;
        }
        public Tokens GenerateAccessToken(CoreData.Users.Entities.User user)
        {
            if (user == null)
                return null;
            var claims = new[] {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            Claims = claims;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            ClaimsIdentity getClaimsIdentity()
            {
                return new ClaimsIdentity(
                    getClaims()
                    );
                Claim[] getClaims()
                {
                    var claims1 = new List<Claim>();
                    claims1.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims1.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

                    foreach (var item in user.UserRoles)
                    {
                        claims1.Add(new Claim(ClaimTypes.Role, item.Role.Name));
                    }
                    return claims1.ToArray();
                }
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = getClaimsIdentity(),

                Expires = DateTime.UtcNow.AddMonths(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string fName = string.Empty;
            string lName = string.Empty;
            fName = user.FirstName;
            lName = user.LastName;
            
            return new Tokens(tokenHandler.WriteToken(token), "JWT", user.UserName, user.Id, fName, lName);
        }
    }
}