﻿using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Cat :
        IFunction<object, object>
    {
        public object Invoke(object rf) => new TransducerFunction(rf);

        public class TransducerFunction :
            ATransducerFunction
        {
            object _rrf;

            public TransducerFunction(object rf) : 
                base(rf)
            {
                this._rrf = new PreservingReduced().Invoke(rf);
            }

            #region Override
            public override object Invoke(object result, object input) => new Reduce().Invoke(this._rrf, result, input);
            #endregion
        }
    }
}