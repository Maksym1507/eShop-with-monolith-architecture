using AutoMapper;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Providers.Abstractions;
using WebApi.Responses;
using WebApi.Services.Abstractions;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class UserService : BaseDateService<ApplicationDbContext>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserProvider _userProvider;
        private readonly ILogger<UserService> _loggerService;

        public UserService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDateService<ApplicationDbContext>> logger,
            ILogger<UserService> loggerService,
            IUserProvider userProvider,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _userProvider = userProvider;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        public async Task<UserResponse> SelectUserByIdAsync(string id)
        {
            var user = await _userProvider!.ReadByIdAsync(id);

            if (user == null)
            {
                _loggerService.LogWarning($"Not founded user with Id = {id}");
                throw new Exception("User not found");
            }

            var userResponse = _mapper.Map<UserResponse>(user);

            return userResponse;
        }

        public async Task<UserEntity?> SelectUserByEmailAsync(string email)
        {
            return await _userProvider.ReadByEmailAsync(email);
        }

        public async Task<UserEntity?> SelectUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _userProvider.ReadByEmailAndPasswordAsync(email, password);
        }

        public async Task<bool> AddUser(UserEntity user)
        {
            return await ExecuteSafeAsync(async () =>
            {
                _loggerService.LogInformation($"User was created");
                return await _userProvider.CreateAsync(user);
            });
        }
    }
}
