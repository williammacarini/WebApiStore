using Microsoft.AspNetCore.Mvc;
using Store.Service.DTOs;
using Store.Service.Services.Interfaces;

namespace WebApiStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductAsync([FromBody] ProductDTO productDTO)
        {
            var result = await _productService.CreateProductAsync(productDTO);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
