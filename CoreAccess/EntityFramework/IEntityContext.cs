using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAccess.EntityFramework
{
    public interface IEntityContext : IDisposable
    {
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
    }
}
