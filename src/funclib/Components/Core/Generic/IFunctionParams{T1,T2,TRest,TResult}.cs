﻿using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core.Generic
{
    public interface IFunctionParams<T1, T2, TRest, TResult> : IFunctionParams
    {
        TResult Invoke(T1 arg1, T2 arg2, params TRest[] rest);
    }
}
