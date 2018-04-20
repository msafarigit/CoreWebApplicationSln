using CoreCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IEntityContext EntityContext { get; }
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity;
        int SaveChanges();
        void Dispose(bool disposing);
    }
}
