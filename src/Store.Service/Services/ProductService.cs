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

        public async Task<ResultService<ICollection<ProductDTO>>> GetAllProductsAsync()
        {
            var result = await _productRepository.GetProductsAsync();
            return ResultService.Ok<ICollection<ProductDTO>>(_mapper.Map<ICollection<ProductDTO>>(result));
        }

        public async Task<ResultService<ProductDTO>> GetProductByIdAsync(int productId)
        {
            var result = await _productRepository.GetByIdAsync(productId);
            if (result == null)
                return ResultService.Fail<ProductDTO>("Produto não encontrado!");

            return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(result));
        }

        public async Task<ResultService> UpdateProductAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new ProductDTOValidator().Validate(productDTO);

            if (!validation.IsValid)
                return ResultService.RequestError("Problemas na validação!", validation);

            var product = await _productRepository.GetByIdAsync(productDTO.ProductId);
            if (product == null)
                return ResultService.Fail("Produto não encontrado!");

            product = _mapper.Map<ProductDTO, Product>(productDTO, product);
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
