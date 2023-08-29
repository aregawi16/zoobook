using Domain.IRepository;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Zoobook.Infrastracture;
using Zoobook.Infrastracture.Context;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        // Database contexts
        private ZoobookContext _zoobookContext;

        public IEmployeeRepository employeeRepository { get; }
      
        public UnitOfWork(ZoobookContext zoobookContext)
        {
            _zoobookContext = zoobookContext;
            employeeRepository = new EmployeeRepository(_zoobookContext);
           
        }

        #region IDisposable Implementation

        protected bool _isDisposed = false;

        protected void CheckDisposed() 
        {
            if (_isDisposed)
            {
                var ex = new ObjectDisposedException("The UnitOfWork is already disposed and cannot be used anymore.");
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_zoobookContext == null) return;

            // dispose the db context
            _zoobookContext.Dispose();

            _isDisposed = true;
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }

        #endregion
        public async Task<bool> SaveAsync()
        {

            using (var transaction = await _zoobookContext.Database.BeginTransactionAsync())
            {
                try
                {
                    CheckDisposed();
                    await _zoobookContext.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine(ex.Message);
                    this.UndoChangesOnDbContext();
                    transaction.Rollback();
                    return false;
                }
            }

        }
        private void UndoChangesOnDbContext()
        {
            var changedEntries = _zoobookContext.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged).ToList();
            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

    }
}
