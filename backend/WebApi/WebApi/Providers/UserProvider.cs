using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Providers.Abstractions;
using WebApi.Services.Abstractions;
using WebApi.Services.Interfaces;

namespace WebApi.Provider
{
    public class UserProvider : IUserProvider
    {
        private readonly ApplicationDbContext _dbContext;

        public UserProvider(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<UserEntity?> ReadByIdAsync(string id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<UserEntity?> ReadByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<UserEntity?> ReadByEmailAndPasswordAsync(string email, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
        }

        public async Task<bool> CreateAsync(UserEntity user)
        {
            var result = await _dbContext.Users.AddAsync(user);

            int countOfAddedRows;
            countOfAddedRows = await _dbContext.SaveChangesAsync();

            return countOfAddedRows > 0;
        }
    }
}
