using CoreCommon;
using System;
using System.Collections.Concurrent;
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
        private ConcurrentDictionary<string, object> _repositoryCache;//Flyweight pattern
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

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            return this.GetRepositoryAsync<TEntity>();
        }

        //Flyweight Factory Method: It is quite common to have flyweight objects to be immutable objects so that they automatically share the same memory space.
        //You use it when you typically have the same information segment in a large number of
        //objects and you decide to share this information between all of these large number of
        //objects instead of having the same copy of information contained inside all of them.
        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class, IEntity
        {
            if (this._repositoryCache == null)
            {
                this._repositoryCache = new ConcurrentDictionary<string, object>();
            }

            string entityName = typeof(TEntity).Name;
            object repository;
            if (!_repositoryCache.TryGetValue(entityName, out repository))
                return (IRepositoryAsync<TEntity>)repository;

            Type repositoryType = typeof(Repository<>);
            //Type[] typeArguments = new Type[] { typeof(TEntity) };
            object[] args = new object[] { this };
            this._repositoryCache.AddOrUpdate(entityName, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), args), (key, oldRepository) => Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), args));
            return (IRepositoryAsync<TEntity>)_repositoryCache[entityName];
        }

        public int SaveChanges()
        {
            return this._entityContext.SaveChanges();
        }

        public int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return this._entityContext.SaveChanges(acceptAllChangesOnSuccess);
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
