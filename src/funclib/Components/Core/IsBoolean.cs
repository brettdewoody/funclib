﻿using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is a <see cref="bool"/>, otherwise <see cref="false"/>.
    /// </summary>
    public class IsBoolean :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is a <see cref="bool"/>, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is a <see cref="bool"/>, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x) => new IsInstance().Invoke(typeof(bool), x);
    }
}