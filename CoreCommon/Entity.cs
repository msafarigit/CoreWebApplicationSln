using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCommon
{
    public abstract class Entity : IEntity, ICloneable
    {
        public int ID { get; set; }

        public virtual object[] GetIdentifier()
        {
            return new object[] { this.ID };
        }

        public virtual void SetIdentifier(params object[] values)
        {
            try
            {
                this.ID = Convert.ToInt32(values[0]);
            }
            catch (Exception)
            {
                this.ID = default(int);
                throw;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
