﻿using Store.Service.DTOs;

namespace Store.Service.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResultService<ProductDTO>> CreateProductAsync(ProductDTO product);
    }
}
