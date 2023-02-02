using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Providers.Abstractions;
using WebApi.Services.Abstractions;

namespace WebApi.Provider
{
    public class CategoryProvider : ICategoryProvider
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryProvider(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<List<ProductEntity>?> ReadByCategoryAsync(int categoryId)
        {
            return await _dbContext.Products.Where(w => w.CategoryId == categoryId).ToListAsync();
        }
    }
}
