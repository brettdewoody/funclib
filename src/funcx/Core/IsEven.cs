﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsEven :
        IFunction<object, object>
    {
        public object Invoke(object n) =>
            (bool)new IsInteger().Invoke(n)
                ? new IsZero().Invoke(new BitAnd().Invoke(Numbers.ConvertToLong(n), 1))
                : throw new InvalidCastException($"Unable to cast object of type '{n.GetType().FullName}' to type '{typeof(int).FullName}'.");
    }
}