﻿using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ChunkAppend :
        IFunction<object, object, object>
    {
        public object Invoke(object b, object x) => ((Collections.ChunkBuffer)b).Add(x);
    }
}