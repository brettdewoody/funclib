﻿using funclib.Components.Core;
using System;
using System.Text;

namespace funclib.Collections
{
    public interface IReduceKV
    {
        object ReduceKV(object f, object init);
    }
}
