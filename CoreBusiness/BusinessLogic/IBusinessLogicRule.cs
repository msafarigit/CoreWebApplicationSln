using CoreAccess;
using CoreAccess.EntityFramework;
using CoreCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.BusinessLogic
{
    public interface IBusinessLogicRule<TEntity> where TEntity : class, IEntity
    {
        IUnitOfWork UnitOfWork { get; set; }
        object Insert(TEntity entity);
        object Insert(IEnumerable<TEntity> entity);
        TEntity FindEntity(params object[] values);
        void Update(TEntity entity);
        void Delete(object identifier);
        void Delete(TEntity entity);
        IQueryable<TEntity> Query();
        IQueryable<TEntity> SelectQuery(string query, params object[] values);
    }
}
