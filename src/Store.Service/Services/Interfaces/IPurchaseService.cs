using Store.Service.DTOs;

namespace Store.Service.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDto>> CreatePurchaseAsync(PurchaseDto purchaseDTO);
        Task<ResultService<PurchaseDetailDto>> GetByPurchaseIdAsync(int purchaseId);
        Task<ResultService<ICollection<PurchaseDetailDto>>> GetAllPurchasesAsync();
        Task<ResultService<PurchaseDto>> UpdatePurchaseAsync(PurchaseDto purchaseDTO);
        Task<ResultService> DeletePurchaseAsync(int purchaseId);
    }
}
