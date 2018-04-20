using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IEntityContext _entityContext;
        private bool _disposed;
        
        public IEntityContext EntityContext
        {
            get { return _entityContext; }
        }

        public UnitOfWork(IEntityContext entityContext)
        {
            this._entityContext = entityContext;
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        IRepository<TEntity> IUnitOfWork.Repository<TEntity>()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    try
                    {
                        if (this._entityContext != null)
                        {
                            this._entityContext.Dispose();
                            this._entityContext = null;
                        }
                    }
                    catch (ObjectDisposedException)
                    {
                    }
                }
                this._disposed = true;
            }
        }
    }
}
