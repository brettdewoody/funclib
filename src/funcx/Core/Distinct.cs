﻿using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Distinct :
        IFunction<object>,
        IFunction<object, object>
    {
        public object Invoke() => new Function<object, object>(rf => new TransducerFunction(rf));
        public object Invoke(object coll)
        {
            return step(coll, new HashSet().Invoke());

            object step(object xs, object seen) =>
                new LazySeq(() => new Function().Invoke(xs, seen));
        }


        class Function :
            IFunction<object, object, object>
        {
            public object Invoke(object xs, object seen)
            {
                var f = new First().Invoke(xs);
                var s = new Seq().Invoke(xs);
                if ((bool)new Truthy().Invoke(s))
                {
                    if ((bool)new Contains().Invoke(seen, f))
                    {
                        return Invoke(new Rest().Invoke(s), seen);
                    }

                    return new Cons().Invoke(f, Invoke(new Rest().Invoke(s), new Conj().Invoke(seen, f)));
                }

                return null;
            }
        }

        public class TransducerFunction :
            ATransducerFunction
        {
            Volatile _seen;

            public TransducerFunction(object rf) :
                base(rf)
            {
                this._seen = (Volatile)new Volatile_().Invoke(new HashSet().Invoke());
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                if ((bool)new Contains().Invoke(this._seen, input))
                {
                    return result;
                }

                new VSwap_(this._seen, new Conj(), input).Invoke();
                return ((IFunction<object, object, object>)this._rf).Invoke(result, input);
            }
            #endregion
        }
    }
}