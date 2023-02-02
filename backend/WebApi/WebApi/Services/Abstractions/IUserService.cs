using WebApi.Data.Entities;
using WebApi.Responses;
using WebApi.ViewModels;

namespace WebApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> SelectUserByIdAsync(string id);
        Task<UserEntity?> SelectUserByEmailAsync(string email);

        Task<UserEntity?> SelectUserByEmailAndPasswordAsync(string email, string password);

        Task<bool> AddUser(UserEntity user);
    }
}
