using Microsoft.AspNetCore.Mvc;
using Store.Domain.Validations;
using Store.Service.DTOs;
using Store.Service.Services;
using Store.Service.Services.Interfaces;

namespace WebApiStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<ActionResult> CreatePurchaseAsync([FromBody] PurchaseDTO purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.CreatePurchaseAsync(purchaseDTO);
                if (result.IsSucess)
                    return Ok(result);
                
                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }

        }

        [HttpGet]
        public async Task<ActionResult> GetAllPurchasesAsync()
        {
                var result = await _purchaseService.GetAllPurchasesAsync();
                if (result.IsSucess)
                    return Ok(result);

                return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetByPurchaseIdAsync(int purchaseId)
        {
            var result = await _purchaseService.GetByPurchaseIdAsync(purchaseId);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePurchaseAsync([FromBody] PurchaseDTO purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.UpdatePurchaseAsync(purchaseDTO);
                if (result.IsSucess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeletePurchaseAsync(int purchaseId)
        {
            var result = await _purchaseService.DeletePurchaseAsync(purchaseId);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
