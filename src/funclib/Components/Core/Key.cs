﻿using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the key of the <see cref="KeyValuePair"/>.
    /// </summary>
    public class Key :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the key of the <see cref="KeyValuePair"/>.
        /// </summary>
        /// <param name="e">An <see cref="KeyValuePair"/> object.</param>
        /// <returns>
        /// Returns the key of the <see cref="KeyValuePair"/>.
        /// </returns>
        public object Invoke(object e) => ((KeyValuePair)e).Key;
    }
}
