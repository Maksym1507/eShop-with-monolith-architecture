using AutoMapper;
using WebApi.Data.Entities;
using WebApi.Responses;
using WebApi.Services;
using WebApi.ViewModels;

namespace WebApi.MapsConfigurations
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserEntity, UserResponse>();

            CreateMap<RegisterDto, UserEntity>()
                .ForMember(destination => destination.Password, opt => opt.MapFrom(src => HashPasswordService.HashPassword(src.Password!)))
                .AfterMap((source, destination) => destination.Id = Guid.NewGuid().ToString());
        }
    }
}
