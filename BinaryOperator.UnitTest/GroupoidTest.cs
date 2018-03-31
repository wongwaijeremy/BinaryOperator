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
            var intGroupoid = Groupoid<int, int>.From((a, b) => a + b);
            Assert.Equal(intGroupoid.Operation(1, 2), 3);
        }

        [Fact]
        public void GroupoidMappingTest()
        {
            var stringGroupoid = Groupoid<string, string>.From((a, b) => a + b);
            var newGroupoid = stringGroupoid.Map(str => str.Length)
                .Map(count => count * 2)
                .Map(doubleCount => (double) doubleCount)
                .Map(deci => deci.ToString());
            var result = newGroupoid.Invoke("Hello World");
            Assert.Equal(result, "22");
        }
    }
}
