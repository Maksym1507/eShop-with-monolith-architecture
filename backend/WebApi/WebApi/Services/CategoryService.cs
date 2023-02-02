using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Providers.Abstractions;
using WebApi.Services.Abstractions;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class CategoryService : BaseDateService<ApplicationDbContext>, ICategoryService
    {
        private readonly ICategoryProvider _categoryProvider;
        private readonly ILogger<UserService> _loggerService;

        public CategoryService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDateService<ApplicationDbContext>> logger,
            ICategoryProvider categoryProvider,
            ILogger<UserService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _categoryProvider = categoryProvider;
            _loggerService = loggerService;
        }

        public async Task<List<ProductEntity>> SelectProductsByCategoryAsync(int categoryId)
        {
            var productList = await _categoryProvider.ReadByCategoryAsync(categoryId);

            if (productList?.Count == 0)
            {
                _loggerService.LogWarning($"Not founded products with category Id = {categoryId}");
                throw new Exception($"No products in database with categoryId = {categoryId}");
            }

            return productList!;
        }
    }
}
