﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class PartitionByShould
    {
        [Test]
        public void PartitionBy_should_when_result_changes()
        {
            var expected = list(list(1, 2), list(3), list(4, 5));
            var actual = new PartitionBy().Invoke(new Function<object, object>(x => x.Equals(3)), new Vector().Invoke(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }
    }
}
