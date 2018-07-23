﻿using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    class PreservingReduced :
        IFunction<object, object>
    {
        public object Invoke(object rf) =>
            func((object _1, object _2) =>
            {
                var ret = ((IFunction<object, object, object>)rf).Invoke(_1, _2);
                if ((bool)isReduced(ret))
                    return reduced(ret);
                return ret;
            });
    }
}
