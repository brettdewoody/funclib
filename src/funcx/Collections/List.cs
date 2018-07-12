﻿using FunctionalLibrary.Collections.Internal;
using FunctionalLibrary.Core;
using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public class List : 
        ASeq,
        IReduce
    {
        public static readonly IList EMPTY = new EmptyList();

        readonly object _first;
        readonly IList _rest;
        
        internal List(object first) : this(first, null, 1) { }
        internal List(object first, IList rest, int count)
        {
            this._first = first;
            this._rest = rest;
            Count = count;
        }

        #region Creates
        public static IList Create(System.Collections.IList init)
        {
            ICollection ret = EMPTY;

            for (int i = init.Count - 1; i >= 0; --i)
                ret = ret.Cons(init[i]);

            return ret as IList;
        }

        public static IList Create(params object[] init)
        {
            ICollection ret = EMPTY;

            for (int i = init.Length - 1; i >= 0; --i)
                ret = ret.Cons(init[i]);

            return ret as IList;
        }
        #endregion

        #region Overrides
        public override int Count { get; }
        public override ISeq Cons(object o) => new List(o, this, Count + 1);
        public override object First() => this._first;
        public override ISeq Next() => Count == 1 ? null : this._rest;
        public override IStack Pop() => this._rest == null ? EMPTY : this._rest;
        #endregion

        public object Reduce(IFunction f)
        {
            object ret = First();
            for (var s = Next(); s != null; s = s.Next())
            {
                ret = ((IFunction<object, object, object>)f).Invoke(ret, s.First());
                if (ret is Reduced r)
                    return r.Deref();
            }

            return ret;
        }
        public object Reduce(IFunction f, object init)
        {
            object ret = ((IFunction<object, object, object>)f).Invoke(init, First());
            for (var s = Next(); s != null; s = s.Next())
            {
                if (ret is Reduced r)
                    return r.Deref();
                ret = ((IFunction<object, object, object>)f).Invoke(ret, s.First());
            }

            if (ret is Reduced r2)
                return r2.Deref();

            return ret;
        }
    }
}
