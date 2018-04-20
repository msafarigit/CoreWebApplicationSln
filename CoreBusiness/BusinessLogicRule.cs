using CoreAccess;
using CoreCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class BusinessLogicRule<TEntity> : IBusinessLogicRule<TEntity>
        where TEntity : class, IEntity, new()
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public void Delete(object identifier)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity FindEntity(params object[] values)
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
    }
}
