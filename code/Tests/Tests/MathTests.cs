using System;
using Xunit;
using Xunit.Extensions;

namespace Tests
{
    [Trait("Math", "adding")]
    public class MathTests
    {
        [Fact]
        public void two_plus_two_is_four()
        {
            Assert.Equal(4, 2 + 2);
        }
    }

    public class SetupTeardownTests : IDisposable
    {
        private int _resource;

        public SetupTeardownTests()
        {
            _resource = 5;
        }

        [Fact]
        public void resource_is_initialized()
        {
            Assert.Equal(_resource, 5);
        }

        public void Dispose()
        {
            _resource = 0;
        }
    }

    public class Theories
    {
        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(1, 3, 4)]
        [InlineData(3, 5, 8)]
        public void a_plus_b_has_correct_result(int a, int b, int expected)
        {
            Assert.Equal(expected, a + b);
        }
    }
}
