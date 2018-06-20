﻿using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsVolatile :
        IFunction<object, object>
    {
        public object Invoke(object x) => new IsInstance().Invoke(typeof(Volatile), x);
    }
}