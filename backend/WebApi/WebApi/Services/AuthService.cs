using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Responses;
using WebApi.Services.Abstractions;
using WebApi.Services.Interfaces;
using WebApi.ViewModels;

namespace WebApi.Services
{
    public class AuthService : BaseDateService<ApplicationDbContext>, IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ILogger<UserService> _loggerService;
        private readonly ITokenService _tokenService;

        public AuthService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<IBaseDateService> logger,
            IUserService userService,
            ILogger<UserService> loggerService,
            ITokenService tokenService,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _userService = userService;
            _loggerService = loggerService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<string> RegisterUserAsync(RegisterDto registerModel)
        {
            var user = await _userService.SelectUserByEmailAsync(registerModel.Email!);

            if (user != null)
            {
                throw new Exception("Account has already existed");
            }

            user = _mapper.Map<UserEntity>(registerModel);

            var userIsAdded = await _userService.AddUser(user);

            if (!userIsAdded)
            {
                throw new Exception("Unsuccesfull try to sign up");
            }

            return "You are sign up";
        }

        public async Task<AuthResponse> LoginUserAsync(LoginDto loginModel)
        {
            AuthResponse authResponse = null!;

            var accessToken = await _tokenService.GetToken(loginModel.Email!, loginModel.Password!);

            var account = await _userService.SelectUserByEmailAndPasswordAsync(loginModel.Email!, HashPasswordService.HashPassword(loginModel.Password!));

            if (account != null)
            {
                authResponse = new AuthResponse()
                {
                    AccessToken = accessToken,
                    User = _mapper.Map<UserResponse>(account)
                };
            }

            return authResponse;
        }
    }
}
