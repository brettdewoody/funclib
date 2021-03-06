﻿using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class CompareShould
    {
        [Test]
        public void Compare_should_return_zero_when_two_collection_are_equal()
        {
            var expected = 0;
            var actual = funclib.Core.Compare(funclib.Core.Vector(1, 2, 3), funclib.Core.Vector(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Compare_should_return_negative_one_when_y_has_more_items_than_x()
        {
            var expected = -1;
            var actual = funclib.Core.Compare(funclib.Core.Vector(1, 2, 3), funclib.Core.Vector(0, 1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Compare_should_return_one_when_x_has_more_items_than_y()
        {
            var expected = 1;
            var actual = funclib.Core.Compare(funclib.Core.Vector(1, 2, 3), funclib.Core.Vector(2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Compare_should_return_one_when_y_is_null()
        {
            var expected = 1;
            var actual = funclib.Core.Compare(funclib.Core.Vector(1, 2, 3), null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Compare_should_return_negative_one_when_x_is_null()
        {
            var expected = -1;
            var actual = funclib.Core.Compare(null, funclib.Core.Vector(0, 1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Compare_should_return_correct_value_when_comparing_strings()
        {
            var expected = -1;
            var actual = funclib.Core.Compare("abc", "def");

            Assert.AreEqual(expected, actual);
        }
    }
}
