﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class KeysShould
    {
        [Test]
        public void Keys_should_return_only_the_keys_of_a_map()
        {
            var expected = new funclib.Components.Core.List().Invoke(":keys", ":some");
            var actual = new Keys().Invoke(arrayMap(":keys", "and", ":some", "values"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Keys_should_return_null_if_empty_map()
        {
            Assert.IsNull(new Keys().Invoke(arrayMap()));
        }

        [Test]
        public void Keys_should_return_null_if_passed_null()
        {
            Assert.IsNull(new Keys().Invoke(null));
        }
    }
}