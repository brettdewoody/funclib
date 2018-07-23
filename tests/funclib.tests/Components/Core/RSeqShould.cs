﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class RSeqShould
    {
        [Test]
        public void RSeq_should_reverse_a_vector()
        {
            var expected = list(9, 8, 7, 6, 5, 4, 3, 2, 1, 0);
            var actual = rseq(vec(range(10)));

            Assert.AreEqual(expected, actual);
        }
    }
}
