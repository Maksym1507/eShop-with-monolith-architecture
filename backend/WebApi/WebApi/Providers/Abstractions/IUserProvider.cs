using WebApi.Data.Entities;

namespace WebApi.Providers.Abstractions
{
    public interface IUserProvider
    {
        Task<UserEntity?> ReadByIdAsync(string id);

        Task<UserEntity?> ReadByEmailAsync(string email);

        Task<UserEntity?> ReadByEmailAndPasswordAsync(string email, string password);

        Task<bool> CreateAsync(UserEntity user);
    }
}
