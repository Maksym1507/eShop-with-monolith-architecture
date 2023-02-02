using WebApi.Data.Entities;

namespace WebApi.Providers.Abstractions
{
    public interface IProductProvider
    {
        Task<List<ProductEntity>> ReadAsync();

        Task<List<ProductEntity>> ReadByCategoryPageLimitAsync(int categoryId, int page, decimal limit, string order);

        Task<ProductEntity?> ReadByIdAsync(int id);

        Task<int> CreateAsync(ProductEntity product);

        Task<bool> UpdateAsync(ProductEntity product);

        Task<bool> DeleteAsync(ProductEntity product);
    }
}
