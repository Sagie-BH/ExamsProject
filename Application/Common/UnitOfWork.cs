using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Application.Common
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ExamPrjDbContext _context;
        private bool _disposed = false;
        private IDbContextTransaction _transaction = null;

        protected ExamPrjDbContext Context
        {
            get { return _context; }
        }

        public UnitOfWork(ExamPrjDbContext context)
        {
            _context = context;
            _transaction = _context.Database.BeginTransaction();
        }

        public Task<int> SaveChangesAsync()
        {
            Task<int> changes;
            try
            {
                 changes = _context.SaveChangesAsync();
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction = _context.Database.BeginTransaction();
            }
            return changes;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _transaction.Dispose();
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
