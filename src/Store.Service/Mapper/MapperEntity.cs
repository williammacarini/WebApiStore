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
            CreateMap<Purchase, PurchaseDetailDTO>()
                .ForMember(f => f.User, opt => opt.Ignore())
                .ForMember(f => f.Product, opt => opt.Ignore())
                .ConstructUsing((model, context) =>
                {
                    var dto = new PurchaseDetailDTO
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
