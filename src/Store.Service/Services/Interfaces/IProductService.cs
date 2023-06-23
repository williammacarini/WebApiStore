using Store.Service.DTOs;

namespace Store.Service.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResultService<ProductDto>> CreateProductAsync(ProductDto product);
        Task<ResultService<ProductDto>> GetProductByIdAsync(int productId);
        Task<ResultService<ICollection<ProductDto>>> GetAllProductsAsync();
        Task<ResultService> UpdateProductAsync(ProductDto productDTO);
        Task<ResultService> DeleteProductAsync(int id);
    }
}
