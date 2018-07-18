﻿using System;
using System.Text;

namespace funclib.Components.Core
{
    public class ReGroups :
        IFunction<object, object>
    {
        public object Invoke(object m)
        {
            var matcher = (funclib.ReMatcher)m;
            var gc = matcher.GroupCount();
            if (gc == 0)
                return matcher.Group();

            return loop(new Vector().Invoke());

            object loop(object ret, int c = 0)
            {
                if (c <= gc)
                    return loop(new Conj().Invoke(ret, matcher.Group(c)), (int)new Inc().Invoke(c));

                return ret;
            }
        }
    }
}
