﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsSeqShould
    {
        [Test]
        public void IsSeq_should_return_true_if_ISeq()
        {
            Assert.IsTrue((bool)isSeq(new Seq().Invoke(new Vector().Invoke(1))));
            Assert.IsTrue((bool)isSeq(list(1, 2, 3)));
            Assert.IsTrue((bool)isSeq(new Seq().Invoke(new Range().Invoke(1, 5))));
        }

        [Test]
        public void IsSeq_should_return_false_if_not_ISeq()
        {
            Assert.IsFalse((bool)isSeq(1));
            Assert.IsFalse((bool)isSeq(new Vector().Invoke(1)));
            Assert.IsFalse((bool)isSeq(hashMap(":a", 1, ":b", 2)));
        }
    }
}
