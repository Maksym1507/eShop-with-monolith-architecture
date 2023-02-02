using WebApi.Data.Entities;

namespace WebApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<ProductEntity>> SelectProductsByCategoryAsync(int categoryId);
    }
}
