using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FinanceDbContext _context;
        private bool _disposed = false;
        private IDbContextTransaction _transaction;

        public UnitOfWork(FinanceDbContext context)
        {
            _context = context;
        }
        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                _transaction = null;  
            }
        }

        public void Dispose()
        {
            DisposeAsync(true);
            GC.SuppressFinalize(this);
        }


        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                _transaction = null; 
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        protected virtual async Task DisposeAsync(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        await _transaction.RollbackAsync();  
                    }
                    await _context.DisposeAsync();
                }

                _disposed = true;
            }
        }
    }
}
