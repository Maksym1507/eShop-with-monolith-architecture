using Microsoft.AspNetCore.Mvc;
using WebApi.Responses;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            UserResponse userResponse;

            try
            {
                userResponse = await _userService.SelectUserByIdAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(new { ex.Message });
            }

            return Ok(userResponse);
        }
    }
}
