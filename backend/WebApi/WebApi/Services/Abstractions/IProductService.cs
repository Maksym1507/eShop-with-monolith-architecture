using WebApi.Data.Entities;
using WebApi.View_Models;

namespace WebApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductEntity>> SelectAllProductsAsync();

        Task<List<ProductEntity>> SelectAllProductsByCategoryPageLimitAsync(int categoryId, int page, decimal limit, string order);

        Task<ProductEntity?> SelectProductByIdAsync(int id);

        Task<int> CreateProductAsync(ProductDto product);

        Task<bool> UpdateProductAsync(ProductDto product, int id);

        Task<bool> RemoveProductAsync(int id);
    }
}
