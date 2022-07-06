using AutoMapper;
using Store.Domain.Entities;
using Store.Service.DTOs;

namespace Store.Service.Mapper
{
    public class MapperEntity : Profile
    {
        public MapperEntity()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            //CreateMap<Product, ProductDTO>().ReverseMap();
            //CreateMap<Purchase, PurchaseDTO>().ReverseMap();
        }
    }
}
