﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class MinShould
    {
        [Test]
        public void Min_should_return_the_value_passed()
        {
            var expected = 100;
            var actual = new Min().Invoke(100);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Min_should_return_the_min_value_from_passed_in_values()
        {
            var expected = 1;
            var actual = new Min().Invoke(1, 2, 3, 4, 5);

            Assert.AreEqual(expected, actual);
        }
    }
}