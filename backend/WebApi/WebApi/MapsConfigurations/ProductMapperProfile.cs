using AutoMapper;
using WebApi.Data.Entities;
using WebApi.View_Models;

namespace WebApi.MapsConfigurations
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<ProductDto, ProductEntity>();
        }
    }
}
