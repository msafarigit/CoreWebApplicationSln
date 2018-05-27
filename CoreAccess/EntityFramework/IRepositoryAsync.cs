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
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<int> CountAsync();
        Task<TEntity> FindEntityAsync(params object[] values);
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);
        Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate);
        Task<object> InsertAsync(TEntity entity);
        Task<object> InsertAsync(IEnumerable<TEntity> entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(object identifier);
        Task DeleteAsync(TEntity entity);
        Task<IDbContextTransaction> StartTransactionAsync();
    }
}
