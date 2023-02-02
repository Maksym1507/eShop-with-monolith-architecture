using AutoMapper;
using WebApi.Data.Entities;
using WebApi.Models;
using WebApi.Responses;
using WebApi.View_Models;

namespace WebApi.MapsConfigurations
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<OrderDto, OrderEntity>()
                .AfterMap((source, destination) => destination.CreatedAt = DateTime.UtcNow.Date);

            CreateMap<CartItemModel, OrderProductEntity>()
                .ForMember(destination => destination.Total, source => source.MapFrom(src => src.Price * src.Count));

            CreateMap<OrderEntity, OrderResponse>()
                .ForMember(destination => destination.OrderProducts, source => source.MapFrom(src => src.OrderProducts.ToArray()));

            CreateMap<OrderProductEntity, OrderProductResponse>();
        }
    }
}
