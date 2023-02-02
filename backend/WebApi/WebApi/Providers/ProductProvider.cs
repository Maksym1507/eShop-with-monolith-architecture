using Microsoft.EntityFrameworkCore;
using WebApi.Providers.Abstractions;
using WebApi.Data.Entities;
using WebApi.Data;
using WebApi.Services.Abstractions;

namespace WebApi.Provider
{
    public class ProductProvider : IProductProvider
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductProvider(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<List<ProductEntity>> ReadAsync()
        {
            var productList = await _dbContext.Products.ToListAsync();
            return productList;
        }

        public async Task<List<ProductEntity>> ReadByCategoryPageLimitAsync(int categoryId, int page, decimal limit, string order)
        {
            List<ProductEntity> productList = null!;

            var pageCount = Math.Ceiling(_dbContext.Products.Where(w => w.CategoryId == categoryId).Count() / limit);

            switch (order)
            {
                case "asc":
                    productList = await _dbContext.Products.Where(w => w.CategoryId == categoryId).OrderBy(o => o.Title).Skip((page - 1) * (int)limit).Take((int)limit).ToListAsync();
                    break;
                case "desc":
                    productList = await _dbContext.Products.Where(w => w.CategoryId == categoryId).OrderByDescending(o => o.Title).Skip((page - 1) * (int)limit).Take((int)limit).ToListAsync();
                    break;
                default:
                    productList = await _dbContext.Products.Where(w => w.CategoryId == categoryId).OrderBy(o => o.Title).Skip((page - 1) * (int)limit).Take((int)limit).ToListAsync();
                    break;
            }

            return productList;
        }

        public async Task<ProductEntity?> ReadByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> CreateAsync(ProductEntity productToAdd)
        {
            var result = _dbContext.Products.Add(productToAdd);

            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<bool> UpdateAsync(ProductEntity productToUpdate)
        {
            _dbContext.Products.Update(productToUpdate);

            var quantityEntriesUpdated = await _dbContext.SaveChangesAsync();

            if (quantityEntriesUpdated > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(ProductEntity productToDelete)
        {
            _dbContext.Products.Remove(productToDelete);
            var quantityEntriesDeleted = await _dbContext.SaveChangesAsync();

            if (quantityEntriesDeleted > 0)
            {
                return true;
            }

            return false;
        }
    }
}
