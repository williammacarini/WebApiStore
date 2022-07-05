using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Data.Context;

namespace Store.Infra.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly StoreContext _context;

        public PurchaseRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Purchase> CreatePurchaseAsync(Purchase purchase)
        {
            _context.Add(purchase);
            await _context.SaveChangesAsync();
            return purchase;
        }

        public async Task DeleteAsync(Purchase purchase)
        {
            _context.Remove(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            return await _context.Purchase.FirstOrDefaultAsync(f => f.PurchaseId == id);
        }

        public async Task<ICollection<Purchase>> GetPurchasesAsync()
        {
            return await _context.Purchase.ToListAsync();
        }

        public async Task UpdateAsync(Purchase purchase)
        {
            _context.Update(purchase);
            await _context.SaveChangesAsync();
        }
    }
}
