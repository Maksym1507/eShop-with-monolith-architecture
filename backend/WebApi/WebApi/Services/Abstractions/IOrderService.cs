using WebApi.Responses;
using WebApi.View_Models;

namespace WebApi.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderResponse>> GetOrdersByUserIdAsync(string userId);

        Task<string> DoOrderAsync(OrderDto order);
    }
}
