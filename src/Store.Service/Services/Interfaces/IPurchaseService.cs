using Store.Service.DTOs;

namespace Store.Service.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> CreatePurchaseAsync(PurchaseDTO purchaseDTO);
        Task<ResultService<PurchaseDetailDTO>> GetByPurchaseIdAsync(int purchaseId);
        Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAllPurchasesAsync();
        Task<ResultService<PurchaseDTO>> UpdatePurchaseAsync(PurchaseDTO purchaseDTO);
        Task<ResultService> DeletePurchaseAsync(int purchaseId);

    }
}
