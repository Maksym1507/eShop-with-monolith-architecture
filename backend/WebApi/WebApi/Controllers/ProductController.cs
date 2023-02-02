using WebApi.View_Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Interfaces;
using WebApi.Data.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int categoryId, int page, decimal limit, string? order = null)
        {
            List<ProductEntity> productList;

            try
            {
                if (page != 0 && limit != 0 && order != null)
                {
                    productList = await _productService.SelectAllProductsByCategoryPageLimitAsync(categoryId, page, limit, order!);
                }
                else
                {
                    productList = await _categoryService.SelectProductsByCategoryAsync(categoryId);
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { ex.Message });
            }

            return Ok(productList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _productService.SelectProductByIdAsync(id));
            }
            catch (Exception ex)
            {
                return NotFound(new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto product)
        {
            try
            {
                await _productService.CreateProductAsync(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }

            return Ok(new { SuccesedMessage = "Product has been added" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(ProductDto product, int id)
        {
            try
            {
                await _productService.UpdateProductAsync(product, id);
            }
            catch (Exception ex)
            {
                return NotFound(new { ErrorMessage = ex.Message });
            }

            return Ok(new { SuccesedMessage = "Product has been updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.RemoveProductAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(new { ErrorMessage = ex.Message });
            }

            return Ok(new { SuccesedMessage = "Product has been removed" });
        }
    }
}