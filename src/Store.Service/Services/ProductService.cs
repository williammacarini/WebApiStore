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

        public async Task<ResultService<ProductDto>> CreateProductAsync(ProductDto productDto)
        {
            if (productDto == null)
                return ResultService.Fail<ProductDto>("Objeto deve ser informado!");

            var result = new ProductDtoValidator().Validate(productDto);

            if (!result.IsValid)
                return ResultService.RequestError<ProductDto>("Problema na validação!", result);

            var product = _mapper.Map<Product>(productDto);
            var productAdded = await _productRepository.CreateProductAsync(product);
            return ResultService.Ok(_mapper.Map<ProductDto>(productAdded));
        }

        public async Task<ResultService<ICollection<ProductDto>>> GetAllProductsAsync()
        {
            var result = await _productRepository.GetProductsAsync();
            return ResultService.Ok(_mapper.Map<ICollection<ProductDto>>(result));
        }

        public async Task<ResultService<ProductDto>> GetProductByIdAsync(int productId)
        {
            var result = await _productRepository.GetByIdAsync(productId);
            if (result == null)
                return ResultService.Fail<ProductDto>("Produto não encontrado!");

            return ResultService.Ok(_mapper.Map<ProductDto>(result));
        }

        public async Task<ResultService> UpdateProductAsync(ProductDto productDto)
        {
            if (productDto == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new ProductDtoValidator().Validate(productDto);

            if (!validation.IsValid)
                return ResultService.RequestError("Problemas na validação!", validation);

            var product = await _productRepository.GetByIdAsync(productDto.ProductId);
            if (product == null)
                return ResultService.Fail("Produto não encontrado!");

            product = _mapper.Map(productDto, product);
            await _productRepository.UpdateAsync(product);
            return ResultService.Ok("Produto editado!");
        }
        public async  Task<ResultService> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return ResultService.Fail("Produto não encontrado!");

            await _productRepository.DeleteAsync(product);
            return ResultService.Ok($"Producto do Id: {id} foi deletado!");
        }
    }
}
