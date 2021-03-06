﻿using CoreCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAccess.EntityFramework
{
    public interface IUnitOfWork : IDisposable
    {
        IEntityContextAsync EntityContext { get; }
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        void Dispose(bool disposing);
    }
}
