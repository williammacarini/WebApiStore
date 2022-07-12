using Store.Service.DTOs;

namespace Store.Service.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResultService<ProductDTO>> CreateProductAsync(ProductDTO product);
        Task<ResultService<ProductDTO>> GetProductByIdAsync(int productId);
        Task<ResultService<ICollection<ProductDTO>>> GetAllProductsAsync();
        Task<ResultService> UpdateProductAsync(ProductDTO productDTO);
        Task<ResultService> DeleteProductAsync(int id);
    }
}
