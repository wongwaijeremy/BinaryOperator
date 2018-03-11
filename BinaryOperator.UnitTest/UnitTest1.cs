using System;
using Xunit;
using BinaryOperator.Core;

namespace BinaryOperator.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var intGroupoid = Groupoid<int>.From((a, b) => a + b);
            Assert.True(intGroupoid.Operation(1, 2) == 3);
        }
    }
}
