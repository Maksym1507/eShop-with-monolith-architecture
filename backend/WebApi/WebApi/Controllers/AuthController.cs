using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;
using WebApi.Responses;
using WebApi.Services.Abstractions;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerModel)
        {
            string message;

            try
            {
                message = await _authService.RegisterUserAsync(registerModel);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }

            return Ok(new { SuccesedMessage = message });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginModel)
        {
            AuthResponse authResponse;

            try
            {
                authResponse = await _authService.LoginUserAsync(loginModel);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }

            return Ok(authResponse);
        }
    }
}
