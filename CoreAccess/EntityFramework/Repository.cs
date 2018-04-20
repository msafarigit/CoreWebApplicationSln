using CoreCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreAccess.EntityFramework
{
    public class Repository<TEntity> : IRepositoryAsync<TEntity>, IRepository<TEntity> where TEntity : class, IEntity
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public void Delete(object identifier)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(object identifier)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity FindEntity(params object[] values)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindEntityAsync(params object[] values)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public object Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public object Insert(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public Task<object> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<object> InsertAsync(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Query()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> SelectQuery(string query, params object[] values)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
