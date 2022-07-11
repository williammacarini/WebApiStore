using AutoMapper;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Service.DTOs;
using Store.Service.DTOs.Validations;
using Store.Service.Services.Interfaces;

namespace Store.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ProductDTO>> CreateProductAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail<ProductDTO>("Objeto deve ser informado!");

            var result = new ProductDTOValidator().Validate(productDTO);

            if (!result.IsValid)
                return ResultService.RequestError<ProductDTO>("Problema na validação!", result);

            var product = _mapper.Map<Product>(productDTO);
            var productAdded = await _productRepository.CreateProductAsync(product);
            return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(productAdded));
        }
    }
}
