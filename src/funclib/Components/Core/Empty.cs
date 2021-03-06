﻿using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns an empty <see cref="ICollection"/> of the same category as coll or null.
    /// </summary>
    public class Empty :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns an empty <see cref="ICollection"/> of the same category as coll or null.
        /// </summary>
        /// <param name="coll">An object to empty.</param>
        /// <returns>
        /// Returns an empty <see cref="ICollection"/> of the same category as coll. If coll
        /// doesn't implement the <see cref="ICollection"/> interface returns null.
        /// </returns>
        public object Invoke(object coll)
        {
            if (coll != null && coll is ICollection c)
                return c.Empty();
            
            return null;
        }
    }
}
