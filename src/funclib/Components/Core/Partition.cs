﻿using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
    /// apart. If step is not supplied, defaults to n, i.e. the partitions do not 
    /// overlap. If a pad collections is supplied, use its elements a necessary
    /// to complete last partition up to n items. In case there are not enough
    /// padding elements, return a partition with  less than n items.
    /// </summary>
    public class Partition :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
        /// apart. If step is not supplied, defaults to n, i.e. the partitions do not 
        /// overlap. If a pad collections is supplied, use its elements a necessary
        /// to complete last partition up to n items. In case there are not enough
        /// padding elements, return a partition with  less than n items.
        /// </summary>
        /// <param name="n">A <see cref="int"/> specifying the size of each group.</param>
        /// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
        /// apart. If step is not supplied, defaults to n, i.e. the partitions do not 
        /// overlap. If a pad collections is supplied, use its elements a necessary
        /// to complete last partition up to n items. In case there are not enough
        /// padding elements, return a partition with  less than n items.
        /// </returns>
        public object Invoke(object n, object coll) => Invoke(n, n, coll);
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
        /// apart. If step is not supplied, defaults to n, i.e. the partitions do not 
        /// overlap. If a pad collections is supplied, use its elements a necessary
        /// to complete last partition up to n items. In case there are not enough
        /// padding elements, return a partition with  less than n items.
        /// </summary>
        /// <param name="n">A <see cref="int"/> specifying the size of each group.</param>
        /// <param name="step">A <see cref="int"/> specifying the starting point for each group.</param>
        /// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
        /// apart. If step is not supplied, defaults to n, i.e. the partitions do not 
        /// overlap. If a pad collections is supplied, use its elements a necessary
        /// to complete last partition up to n items. In case there are not enough
        /// padding elements, return a partition with  less than n items.
        /// </returns>
        public object Invoke(object n, object step, object coll) =>
            lazySeq(() =>
            {
                var s = seq(coll);
                if ((bool)truthy(s))
                {
                    var p = doAll(take(n, s));
                    if (n.Equals(count(p)))
                        return cons(p, Invoke(n, step, nthRest(s, step)));
                }
                return null;
            });
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
        /// apart. If step is not supplied, defaults to n, i.e. the partitions do not 
        /// overlap. If a pad collections is supplied, use its elements a necessary
        /// to complete last partition up to n items. In case there are not enough
        /// padding elements, return a partition with  less than n items.
        /// </summary>
        /// <param name="n">A <see cref="int"/> specifying the size of each group.</param>
        /// <param name="step">A <see cref="int"/> specifing the starting point for each group.</param>
        /// <param name="pad">A collection to pad results with.</param>
        /// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
        /// apart. If step is not supplied, defaults to n, i.e. the partitions do not 
        /// overlap. If a pad collections is supplied, use its elements a necessary
        /// to complete last partition up to n items. In case there are not enough
        /// padding elements, return a partition with  less than n items.
        /// </returns>
        public object Invoke(object n, object step, object pad, object coll) =>
            lazySeq(() =>
            {
                var s = seq(coll);
                if ((bool)truthy(s))
                {
                    var p = doAll(take(n, s));
                    if (n.Equals(count(p)))
                        return cons(p, Invoke(n, step, pad, nthRest(s, step)));

                    return list(take(n, concat(p, pad)));
                }
                return null;
            });
    }
}
