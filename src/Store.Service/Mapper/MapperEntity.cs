using AutoMapper;
using Store.Domain.Entities;
using Store.Service.DTOs;

namespace Store.Service.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Purchase, PurchaseDetailDto>()
                .ForMember(f => f.User, opt => opt.Ignore())
                .ForMember(f => f.Product, opt => opt.Ignore())
                .ConstructUsing((model, context) =>
                {
                    var dto = new PurchaseDetailDto
                    {
                        Product = model.Product.Name,
                        PurchaseId = model.PurchaseId,
                        Date = model.PurchaseDate,
                        User = model.User.Name
                    };
                    return dto;
                });
        }
    }
}
