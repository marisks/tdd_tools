using System;
using Xunit;

namespace Tests
{
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
}
