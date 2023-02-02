using AutoMapper;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Providers.Abstractions;
using WebApi.Responses;
using WebApi.Services.Abstractions;
using WebApi.Services.Interfaces;
using WebApi.View_Models;

namespace WebApi.Services
{
    public class OrderService : BaseDateService<ApplicationDbContext>, IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderProvider _orderProvider;
        private readonly ILogger<UserService> _loggerService;

        public OrderService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDateService<ApplicationDbContext>> logger,
            IOrderProvider orderProvider,
            ILogger<UserService> loggerService,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _orderProvider = orderProvider;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        public async Task<List<OrderResponse>> GetOrdersByUserIdAsync(string userId)
        {
            List<OrderResponse> orderList;

            var orders = await _orderProvider.ReadOrdersByUserIdAsync(userId);

            if (orders?.Count == 0)
            {
                _loggerService.LogWarning($"Not founded orders for user with id = {userId}");
                throw new Exception("You haven't ordered anything yet");
            }

            orderList = new List<OrderResponse>();

            List<OrderProductEntity>? orderProductsList;

            foreach (var order in orders!)
            {
                orderProductsList = await _orderProvider.ReadOrderProductsByOrderIdAsync(order.Id);

                var orderProducts = orderProductsList!.Select(s => _mapper.Map<OrderProductResponse>(s));

                orderList.Add(_mapper.Map<OrderResponse>(order));
            }

            return orderList;
        }

        public async Task<string> DoOrderAsync(OrderDto order)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var addedOrder = _mapper.Map<OrderEntity>(order);

                var orderId = await _orderProvider.AddOrderAsync(addedOrder, order.CartItems.ToList());

                _loggerService.LogWarning($"Order with id = {orderId} has been added");
                return "Order has been added";
            });
        }
    }
}
