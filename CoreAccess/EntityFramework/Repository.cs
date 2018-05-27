using CoreCommon;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreAccess.EntityFramework
{
    //class Repository<TEntity> is Bridge for UnitOfWork Abstraction
    public class Repository<TEntity> : IRepositoryAsync<TEntity>, IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly IEntityContextAsync _context;
        //protected readonly DbSet _context;

        public Repository(IEntityContextAsync context)
        {
            _context = context;
        }

        public virtual int Count()
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(object identifier)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAsync(object identifier)
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity FindEntity(params object[] values)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> FindEntityAsync(params object[] values)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            //AsNoTracking: Memory Usage, Application Speed, Committed All on Save Changes
            throw new NotImplementedException();
        }

        public virtual object Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual object Insert(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<object> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<object> InsertAsync(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> Query()
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> SelectQuery(string query, params object[] values)
        {
            throw new NotImplementedException();
        }

        public virtual IDbContextTransaction StartTransaction()
        {
            throw new NotImplementedException();
        }

        public virtual Task<IDbContextTransaction> StartTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
