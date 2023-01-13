using ApiTest.Models;
using ApiTest.Models.Respons;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ModelTest.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest.Bussines
{
    internal class AccountService : IAccountService
    {
        private readonly string? _verify;
        private readonly DB_TestHummanContext _context;

        public AccountService(DB_TestHummanContext context, IConfiguration configuration)
        {
            _verify = configuration.GetSection("settings").GetSection("key").ToString();
            _context = context;
        }

        public async Task<ResponAccount?> GetValidate(RequestAccount data)
        {
            var aut = await _context.Accounts.FirstOrDefaultAsync(i=> i.Count == data.account && i.Pount == data.pount);
            var acount = await _context.Clients.FirstOrDefaultAsync(i => i.AccountId == aut.Id);
            ResponAccount? respon = null;
            if (aut != null && acount != null)
            {
                var bytes = Encoding.ASCII.GetBytes(_verify);
                var claim = new ClaimsIdentity();

                claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, aut.Count));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claim,
                    Expires = DateTime.UtcNow.AddDays(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenconf = tokenHandler.CreateToken(tokenDescriptor);
                string tokenCreate = tokenHandler.WriteToken(tokenconf);

                respon = new ResponAccount()
                {
                    Id = acount.Id,
                    name = acount.Name + acount.LastNames,
                    token = tokenCreate,
                    role = aut.RolId
                };

                return respon;
            }
            
            return respon;
        }
    }
}
