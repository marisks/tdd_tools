using ExpectBetter;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class AssertionTests
    {
[Fact]
public void it_should_assert()
{
    var actual = 2 + 2;

    actual.Should().Be(4);
    actual.Should().BeGreaterThan(1);
    actual.Should().BeLessThan(5);
}

[Fact]
public void it_expects()
{
    var actual = 2 + 2;

    Expect.The(actual).ToEqual(4);
    Expect.The(actual).ToBeGreaterThan(1);
    Expect.The(actual).ToBeLessThan(5);
}
    }
}