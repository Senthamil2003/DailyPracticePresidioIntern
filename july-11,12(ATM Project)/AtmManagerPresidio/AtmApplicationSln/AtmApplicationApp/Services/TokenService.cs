using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AtmApplicationApp.Interface;
using AtmApplicationApp.Models;
namespace AtmApplicationApp.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey;
        private readonly SymmetricSecurityKey _key;
       

        public TokenService(IConfiguration configuration, ILogger<TokenService> logger) // Added logger parameter
        {
            _secretKey = configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
           
        }

        /// <summary>
        /// Generates a JSON Web Token (JWT) for the given customer.
        /// </summary>
        /// <param name="customer">The customer for whom the token should be generated.</param>
        /// <returns>The generated JWT token.</returns>
        public async Task<string> GenerateToken(Card customer)
        {
           

            string token = string.Empty;
            var claims = new List<Claim>()
            {
                new Claim("AccountNumber", customer.AccountNumber.ToString()),
               
            };

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(10), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(myToken);
         
            return token;

        }
        
    }
}
