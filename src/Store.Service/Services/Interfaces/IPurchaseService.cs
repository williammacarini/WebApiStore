using Store.Service.DTOs;

namespace Store.Service.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> CreatePurchaseAsync(PurchaseDTO purchaseDTO);
    }
}
