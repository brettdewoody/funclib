﻿using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// For <see cref="funclib.Components.Core.LazySeq"/> that are produced via other functions and have side effects.
    /// The side effects are not produces until the sequence is consumed. <see cref="funclib.Components.Core.DoAll"/>
    /// walks though successive next, retains the head and returns it, thus causing the
    /// entire seq to reside in memory at one time.
    /// </summary>
    public class DoAll :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        /// <summary>
        /// For <see cref="funclib.Components.Core.LazySeq"/> that are produced via other functions and have side effects.
        /// The side effects are not produces until the sequence is consumed. <see cref="funclib.Components.Core.DoAll"/>
        /// walks though successive next, retains the head and returns it, thus causing the
        /// entire seq to reside in memory at one time.
        /// </summary>
        /// <param name="coll"><see cref="funclib.Components.Core.LazySeq"/> to consume.</param>
        /// <returns>
        /// Returns the <see cref="funclib.Components.Core.LazySeq"/> already consumed.
        /// </returns>
        public object Invoke(object coll)
        {
            funclib.Core.DoRun(coll);
            return coll;
        }
        /// <summary>
        /// For <see cref="funclib.Components.Core.LazySeq"/> that are produced via other functions and have side effects.
        /// The side effects are not produces until the sequence is consumed. <see cref="funclib.Components.Core.DoAll"/>
        /// walks though successive next, retains the head and returns it, thus causing the
        /// entire seq to reside in memory at one time.
        /// </summary>
        /// <param name="n">The <see cref="int"/> times to walk the sequence.</param>
        /// <param name="coll"><see cref="funclib.Components.Core.LazySeq"/> to consume.</param>
        /// <returns>
        /// Returns the <see cref="funclib.Components.Core.LazySeq"/> already consumed.
        /// </returns>
        public object Invoke(object n, object coll)
        {
            funclib.Core.DoRun(n, coll);
            return coll;
        }
    }
}
