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
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        int Count();
        IQueryable<TEntity> GetAll();
        TEntity FindEntity(params object[] values);
        ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        object Insert(TEntity entity);
        object Insert(IEnumerable<TEntity> entity);
        void Update(TEntity entity);
        void Delete(object identifier);
        void Delete(TEntity entity);
        IQueryable<TEntity> Query();
        IQueryable<TEntity> SelectQuery(string query, params object[] values);
        IDbContextTransaction StartTransaction();
    }
}
