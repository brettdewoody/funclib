﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class MinusShould
    {
        [Test]
        public void Minus_should_nagate_one_by_passed_in_number()
        {
            var expected = -2;
            var actual = new Minus().Invoke(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Minus_should_throw_an_exception_if_not_passed_a_number()
        {
            Assert.Throws<InvalidCastException>(() => new Minus().Invoke(""));
        }

        [Test]
        public void Minus_should_minus_passed_in_numbers()
        {
            var expected = 0;
            var actual = new Minus().Invoke(2, 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Minus_should_minus_all_passing_mulitple_items()
        {
            var expected = 3;
            var actual = new Minus().Invoke(6, 2, 1);

            Assert.AreEqual(expected, actual);
        }
    }
}