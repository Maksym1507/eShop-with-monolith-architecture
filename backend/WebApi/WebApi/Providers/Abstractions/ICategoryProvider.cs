using WebApi.Data.Entities;

namespace WebApi.Providers.Abstractions
{
    public interface ICategoryProvider
    {
        Task<List<ProductEntity>?> ReadByCategoryAsync(int categoryId);
    }
}
