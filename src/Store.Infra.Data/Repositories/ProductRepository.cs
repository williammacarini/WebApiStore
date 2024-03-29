﻿using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Data.Context;

namespace Store.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(f => f.ProductId == id);
        }

        public async Task<ICollection<Product>> GetProductsAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetIdByCodeAsync(string code)
        {
            return (await _context.Product.FirstOrDefaultAsync(f => f.Code == code))?.ProductId ?? 0;
        }
    }
}
