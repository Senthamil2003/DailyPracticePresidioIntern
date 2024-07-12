using AtmApplicationApp.Models;

namespace AtmApplicationApp.Interface
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(Card login);

    }
}
