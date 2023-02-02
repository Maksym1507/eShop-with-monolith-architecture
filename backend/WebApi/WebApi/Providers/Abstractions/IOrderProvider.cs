using WebApi.Data.Entities;
using WebApi.Models;
using WebApi.Responses;

namespace WebApi.Providers.Abstractions
{
    public interface IOrderProvider
    {
        Task<List<OrderEntity>?> ReadOrdersByUserIdAsync(string id);

        Task<List<OrderProductEntity>?> ReadOrderProductsByOrderIdAsync(int orderId);

        Task<int> AddOrderAsync(OrderEntity order, List<CartItemModel> items);
    }
}
