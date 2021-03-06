﻿using funclib.Components.Core;
using funclib.Components.Core.Generic;
using NUnit.Framework;
using System.Collections;

namespace funclib.Tests.Components.Core
{
    public class AndShould
    {
        [Test]
        public void And_should_allow_passing_object()
        {
            var and = new And();

            Assert.AreEqual(true, and.Invoke(true, true));
            Assert.AreEqual(false, and.Invoke(true, false));
            Assert.AreEqual(false, and.Invoke(false, false));
            Assert.AreEqual(typeof(ArrayList), and.Invoke(new ArrayList(), new ArrayList()).GetType());
            Assert.AreEqual(1, and.Invoke(0, 1));
            Assert.AreEqual(0, and.Invoke(1, 0));
            Assert.AreEqual(false, and.Invoke(false, null));
            Assert.AreEqual(null, and.Invoke(null, false));
        }

        [Test]
        public void And_should_allow_passing_functions()
        {
            Assert.IsNotNull(funclib.Core.And(funclib.Core.Func(() => true), null));
        }

        [Test]
        public void And_should_return_true_with_nothing_is_passed()
        {
            Assert.AreEqual(true, funclib.Core.And());
        }

        [Test]
        public void And_should_execute_the_function_and_still_return_proper_value()
        {
            int i = 0;

            var actual = funclib.Core.And(new Function<object>(() => { i = i + 1; return null; }).Invoke(), false);

            Assert.IsNull(actual);
            Assert.AreEqual(i, 1);
        }

        [Test]
        public void And_should_not_evaluate_the_function_if_the_first_value_is_false()
        {
            int i = 0;

            var expected = false;
            var actual = funclib.Core.And(false, new Function<object>(() => { i = i + 1; return null; }));

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(i, 0);
        }
    }
}
