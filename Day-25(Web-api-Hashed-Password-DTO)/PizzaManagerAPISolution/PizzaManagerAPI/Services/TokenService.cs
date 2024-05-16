using Microsoft.IdentityModel.Tokens;
using PizzaManagerAPI.Interface;
using PizzaManagerAPI.Model;
using PizzaManagerAPI.Model.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PizzaManagerAPI.Services
{
    public class TokenService:ITokenService
    {
        private readonly string _secretKey;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            _secretKey = configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

        }
        public async Task<string> GenerateToken(Customer customer)
        {
            string token = string.Empty;
            var claims = new List<Claim>(){
                new Claim("Id", customer.UserId.ToString())   ,
                new Claim("Name",customer.Name.ToString())
            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(2), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(myToken);
            return token;

        }
    }
}
