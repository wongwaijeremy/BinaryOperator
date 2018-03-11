using System;
using Xunit;
using BinaryOperator.Core;

namespace BinaryOperator.UnitTest
{
    public class GroupoidTest
    {    
        [Fact]
        public void GroupoidOperationTest()
        {
            var intGroupoid = Groupoid<int>.From((a, b) => a + b);
            Assert.Same(intGroupoid.Operation(1, 2), 3);
        }
    }
}
