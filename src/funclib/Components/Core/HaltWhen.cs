﻿using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    public class HaltWhen :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object pred) => Invoke(pred, null);
        public object Invoke(object pred, object retf) =>
            new Function<object, object>(rf => new TransducerFunction(pred, retf, rf));


        public class TransducerFunction :
            ATransducerFunction
        {
            IFunction<object, object> _pred;
            IFunction<object, object, object> _retf;

            public TransducerFunction(object pred, object retf, object rf) :
                base(rf)
            {
                this._pred = (IFunction<object, object>)pred;
                this._retf = (IFunction<object, object, object>)retf;
            }

            #region Overrides
            public override object Invoke(object result)
            {
                if ((bool)truthy(and(isMap(result), contains(result, "::halt"))))
                {
                    return get(result, "::halt");
                }

                return ((IFunction<object, object>)this._rf).Invoke(result);
            }
            public override object Invoke(object result, object input)
            {
                if ((bool)truthy(this._pred.Invoke(input)))
                {
                    var haltVal = (bool)truthy(this._retf) ? this._retf.Invoke(((IFunction<object, object>)this._rf).Invoke(result), input) : input;
                    return reduced(hashMap("::halt", haltVal));
                }

                return ((IFunction<object, object, object>)this._rf).Invoke(result, input);
            }
            #endregion
        }
    }
}
