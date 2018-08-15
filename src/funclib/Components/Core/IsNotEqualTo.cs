﻿using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
    /// </summary>
    public class IsNotEqualTo :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <returns>
        /// Returns false.
        /// </returns>
        public object Invoke(object x) => false;
        /// <summary>
        /// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test</param>
        /// <returns>
        /// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
        /// </returns>
        public object Invoke(object x, object y) => funclib.Core.Not(funclib.Core.IsEqualTo(x, y));
        /// <summary>
        /// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test against.</param>
        /// <param name="more">All other elements to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
        /// </returns>
        public object Invoke(object x, object y, params object[] more) => funclib.Core.Not(funclib.Core.Apply(funclib.Core.isEqualTo, x, y, more));
    }
}
