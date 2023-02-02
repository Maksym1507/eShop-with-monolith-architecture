using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Models;
using WebApi.Providers.Abstractions;
using WebApi.Services.Abstractions;

namespace WebApi.Provider
{
    public class OrderProvider : IOrderProvider
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public OrderProvider(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            IMapper mapper)
        {
            _dbContext = dbContextWrapper.DbContext;
            _mapper = mapper;
        }

        public async Task<int> AddOrderAsync(OrderEntity order, List<CartItemModel> items)
        {
            var result = await _dbContext.Orders.AddAsync(order);

            await _dbContext.OrderProducts.AddRangeAsync(items.Select(s => new OrderProductEntity()
            {
                OrderId = result.Entity.Id,
                ProductId = s.Product!.Id,
                Count = s.Count,
                Total = s.Price * s.Count
            }));

            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<List<OrderEntity>?> ReadOrdersByUserIdAsync(string userId)
        {
            return await _dbContext.Orders.Where(w => w.UserId == userId).Include(a => a.OrderProducts).ThenInclude(p => p.Product).ToListAsync();
        }

        public async Task<List<OrderProductEntity>?> ReadOrderProductsByOrderIdAsync(int orderId)
        {
            return await _dbContext.OrderProducts.Include(i => i.Product).Where(w => w.OrderId == orderId).ToListAsync();
        }
    }
}
