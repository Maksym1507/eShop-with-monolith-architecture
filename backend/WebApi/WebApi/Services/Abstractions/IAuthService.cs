using WebApi.Responses;
using WebApi.ViewModels;

namespace WebApi.Services.Abstractions
{
    public interface IAuthService
    {
        Task<string> RegisterUserAsync(RegisterDto registerModel);

        Task<AuthResponse> LoginUserAsync(LoginDto loginModel);
    }
}
