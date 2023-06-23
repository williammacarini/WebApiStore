using Microsoft.EntityFrameworkCore.Storage;
using Store.Domain.Repositories;
using Store.Infra.Data.Context;

namespace Store.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _storeContext;
        private IDbContextTransaction _dbContextTransaction;

        public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task BeginTransaction()
        {
            _dbContextTransaction = await _storeContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _dbContextTransaction.CommitAsync();
        }

        public void Dispose() => _dbContextTransaction?.Dispose();

        public async Task Rollback()
        {
            await _dbContextTransaction.RollbackAsync();
        }
    }
}
