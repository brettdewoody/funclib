﻿using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class PartitionAll :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        public object Invoke(object n) => new Function<object, object>(rf => new TransducerFunction(n, rf));
        public object Invoke(object n, object coll) => Invoke(n, n, coll);
        public object Invoke(object n, object step, object coll) =>
            new LazySeq(() =>
            {
                var s = new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    var seq = new DoAll().Invoke(new Take().Invoke(n, s));
                    return new Cons().Invoke(seq, Invoke(n, step, new NthRest().Invoke(s, step)));
                }
                return null;
            });

        public class TransducerFunction :
            ATransducerFunction
        {
            int _n;
            System.Collections.ArrayList _a;

            public TransducerFunction(object n, object rf) :
                base(rf)
            {
                this._n = Numbers.ConvertToInt(n);
                this._a = new System.Collections.ArrayList(this._n);
            }

            #region Overrides
            public override object Invoke(object result)
            {
                if (!(bool)new IsZero().Invoke(this._a.Count))
                {
                    var v = new Vec().Invoke(this._a.ToArray());
                    this._a.Clear();
                    result = new Unreduce().Invoke(((IFunction<object, object, object>)this._rf).Invoke(result, v));
                }

                return ((IFunction<object, object>)this._rf).Invoke(result);
            }
            public override object Invoke(object result, object input)
            {
                this._a.Add(input);
                if (this._n == this._a.Count)
                {
                    var v = new Vec().Invoke(this._a.ToArray());
                    this._a.Clear();
                    return ((IFunction<object, object, object>)this._rf).Invoke(result, v);
                }

                return result;
            }
            #endregion
        }

    }
}