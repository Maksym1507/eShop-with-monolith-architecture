using IdentityModel.Client;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class TokenService : ITokenService
    {
        public async Task<string> GetToken(string username, string password)
        {
            using (var client = new HttpClient())
            {
                var discoveryDocument = await client.GetDiscoveryDocumentAsync("https://localhost:7045");
                var token = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                {
                    Address = "https://localhost:7045/connect/token",
                    ClientId = "react_client",
                    ClientSecret = "secret_1",
                    Scope = "openid",
                    GrantType = "password",
                    UserName = username,
                    Password = password
                });

                if (token.IsError)
                {
                    throw new Exception(token.ErrorDescription);
                }

                return token.AccessToken;
            }
        }
    }
}
