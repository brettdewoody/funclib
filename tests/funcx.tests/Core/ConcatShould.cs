﻿using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class ConcatShould
    {
        [Test]
        public void Concat_should_join_two_vectors_together()
        {
            var actual = (object[])new ToArray().Invoke(new Concat().Invoke(new Vector().Invoke(1, 2), new Vector().Invoke(3, 4)));

            Assert.AreEqual(4, actual.Length);
            Assert.AreEqual(1, actual[0]);
            Assert.AreEqual(2, actual[1]);
            Assert.AreEqual(3, actual[2]);
            Assert.AreEqual(4, actual[3]);
        }

        [Test]
        public void Concat_should_join_muliple_items()
        {
            var actual = new Concat().Invoke(new Vector().Invoke("a", "b"), null, new Vector().Invoke(1, new Vector().Invoke(2, 3), 4));

            var str = actual.ToString();
        }
    }
}