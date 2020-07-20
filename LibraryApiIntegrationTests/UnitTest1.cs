using System;
using Xunit;

namespace LibraryApiIntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(10, 10);
        }

        [Theory]
        [InlineData(10, 2, 12)]
        [InlineData(1, 1, 2)]
        public void CanAdd(int a, int b, int expected)
        {
            var answer = a + b;
            Assert.Equal(expected, answer);
        }
    }
}
