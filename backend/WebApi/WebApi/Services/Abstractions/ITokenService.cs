using IdentityModel.Client;

namespace WebApi.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetToken(string username, string password);
    }
}
