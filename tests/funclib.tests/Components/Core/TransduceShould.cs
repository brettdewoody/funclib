﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class TransduceShould
    {
        object xf;

        [SetUp]
        public void SetUp()
        {
            xf = new Comp().Invoke(new Filter().Invoke(new IsOdd()), new Take().Invoke(10));
        }

        [Test]
        public void Transduce_should_return_the_numbers_as_a_sequence()
        {
            var expected = new Vector().Invoke(1, 3, 5, 7, 9, 11, 13, 15, 17, 19);
            var actual = new Transduce().Invoke(xf, new Conj(), new Range().Invoke());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Transduce_should_return_sumed_values()
        {
            var expected = 100;
            var actual = new Transduce().Invoke(xf, new Plus(), new Range().Invoke());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Transduce_should_return_sumed_values_with_seed_value()
        {
            var expected = 117;
            var actual = new Transduce().Invoke(xf, new Plus(), 17, new Range().Invoke());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Transduce_should_return_string_when_called_via_str()
        {
            var expected = "135791113151719";
            var actual = new Transduce().Invoke(xf, new Str(), new Range().Invoke());

            Assert.AreEqual(expected, actual);
        }
    }
}