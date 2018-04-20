﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCommon
{
    public interface IEntity
    {
        int ID { get; set; }
        void SetIdentifier(params object[] values);
        object[] GetIdentifier();
    }
}
