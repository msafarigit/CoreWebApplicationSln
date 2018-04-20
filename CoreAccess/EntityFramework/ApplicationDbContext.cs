using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAccess.EntityFramework
{
    public class ApplicationDbContext
    {
        public static Func<IEntityContextAsync> EntityContext;
    }
}
