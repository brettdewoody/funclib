﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class EqualsShould
    {
        [Test]
        public void Equals_should_always_return_true_if_passed_a_single_value()
        {
            var actual = new IsEqualTo().Invoke(false);

            Assert.IsTrue((bool)actual);
        }

        [Test]
        public void Equals_should_test_equality_between_two_objects()
        {
            Assert.IsTrue((bool)new IsEqualTo().Invoke(1, 1));
            Assert.IsTrue((bool)new IsEqualTo().Invoke(new Vector().Invoke(1, 2), new Vector().Invoke(1, 2)));
            Assert.IsFalse((bool)new IsEqualTo().Invoke(1, "1"));
            Assert.IsFalse((bool)new IsEqualTo().Invoke(null, 1));
        }

        [Test]
        public void Equals_should_test_equality_with_unlimited_number_of_objects()
        {
            Assert.IsTrue((bool)new IsEqualTo().Invoke(1, 1, 1, 1));
            Assert.IsTrue((bool)new IsEqualTo().Invoke(new Vector().Invoke(1, 2), new Vector().Invoke(1, 2), new Vector().Invoke(1, 2)));
            Assert.IsFalse((bool)new IsEqualTo().Invoke(1, 1, "1"));
            Assert.IsFalse((bool)new IsEqualTo().Invoke(null, 1, 1, 1));
        }
    }
}