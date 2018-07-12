﻿using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class InterposeShould
    {
        [Test]
        public void Interpose_should_return_a_lazy_seq()
        {
            var actual = new Interpose().Invoke(",", new Vector().Invoke("one", "two", "three"));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Interpose_should_return_a_list_of_items_with_the_sep_in_between_each()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke("one", ", ", "two", ", ", "three");
            var actual = new ToArray().Invoke(new Interpose().Invoke(", ", new Vector().Invoke("one", "two", "three")));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Interpose_should_concat_a_string_using_apply()
        {
            var expected = "one, two, three";
            var actual = new Apply().Invoke(new Str(), new Interpose().Invoke(", ", new Vector().Invoke("one", "two", "three")));

            Assert.AreEqual(expected, actual);
        }
    }
}
