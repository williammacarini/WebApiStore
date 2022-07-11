using AutoMapper;
using Store.Domain.Entities;
using Store.Service.DTOs;

namespace Store.Service.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
