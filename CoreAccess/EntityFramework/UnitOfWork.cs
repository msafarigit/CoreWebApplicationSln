using CoreCommon;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreAccess.EntityFramework
{
    public class UnitOfWork : IUnitOfWorkAsync, IUnitOfWork, IDisposable
    {
        private IEntityContextAsync _entityContext;
        private DbTransaction _transaction;
        private Dictionary<string, object> _repositories;
        private bool _disposed;

        public IEntityContextAsync EntityContext
        {
            get { return _entityContext; }
        }

        public UnitOfWork()
        {
            this._entityContext = ApplicationDbContext.EntityContext();
        }

        public UnitOfWork(IEntityContextAsync entityContext)
        {
            this._entityContext = entityContext;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity
        {
            return this.RepositoryAsync<TEntity>();
        }

        public IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IEntity
        {
            if (this._repositories == null)
            {
                this._repositories = new Dictionary<string, object>();
            }

            string entityName = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(entityName))
            {
                Type repositoryType = typeof(Repository<>);
                //Type[] typeArguments = new Type[] { typeof(TEntity) };
                //object[] args = new object[] { this };
                this._repositories.Add(entityName, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), this));
            }
            return (IRepositoryAsync<TEntity>)_repositories[entityName];
        }

        public int SaveChanges()
        {
            return this._entityContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            return await this._entityContext.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await this._entityContext.SaveChangesAsync(cancellationToken);
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
