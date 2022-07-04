using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IPurchaseRepository
    {
        Task<Purchase> GetByIdAsync(int id);
        Task<ICollection<Purchase>> GetPurchasesAsync();
        Task<Purchase> CreatePurchaseAsync(Purchase purchase);
        Task UpdateAsync(Purchase purchase);
        Task DeleteAsync(Purchase purchase);
    }
}
