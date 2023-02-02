using AutoMapper;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Providers.Abstractions;
using WebApi.Services.Abstractions;
using WebApi.Services.Interfaces;
using WebApi.View_Models;

namespace WebApi.Services
{
    public class ProductService : BaseDateService<ApplicationDbContext>, IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductProvider _productProvider;
        private readonly ILogger<UserService> _loggerService;

        public ProductService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDateService<ApplicationDbContext>> logger,
            IProductProvider productProvider,
            ILogger<UserService> loggerService,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _productProvider = productProvider;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        public async Task<List<ProductEntity>> SelectAllProductsAsync()
        {
            return await _productProvider.ReadAsync();
        }

        public async Task<List<ProductEntity>> SelectAllProductsByCategoryPageLimitAsync(int categoryId, int page, decimal limit, string order)
        {
            var productList = await _productProvider.ReadByCategoryPageLimitAsync(categoryId, page, limit, order);

            if (productList.Count == 0)
            {
                _loggerService.LogWarning($"Products with category id = {categoryId} and page = {page} weren't found");
                throw new Exception($"Products with category id = {categoryId} and page = {page} weren't found");
            }

            return productList;
        }

        public async Task<ProductEntity?> SelectProductByIdAsync(int id)
        {
            var product = await _productProvider.ReadByIdAsync(id);

            if (product == null)
            {
                _loggerService.LogWarning($"Not founded product with Id = {id}");
                throw new Exception("Product not found");
            }

            return product;
        }

        public async Task<int> CreateProductAsync(ProductDto product)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var productToAdd = _mapper.Map<ProductEntity>(product);

                _loggerService.LogInformation($"Created product with title = {product.Title}");
                return await _productProvider.CreateAsync(productToAdd);
            });
        }

        public async Task<bool> UpdateProductAsync(ProductDto product, int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var productToUpdate = await _productProvider.ReadByIdAsync(id);

                if (productToUpdate == null)
                {
                    _loggerService.LogWarning($"Not founded product with Id = {id}");
                    throw new Exception("Product not found");
                }

                productToUpdate = _mapper.Map<ProductEntity>(product);
                productToUpdate.Id = id;

                return await _productProvider.UpdateAsync(productToUpdate);
            });
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var productToDelete = await _productProvider.ReadByIdAsync(id);

                if (productToDelete == null)
                {
                    _loggerService.LogWarning($"Not founded product with Id = {id}");
                    throw new Exception("Product not found");
                }

                return await _productProvider.DeleteAsync(productToDelete);
            });
        }
    }
}
