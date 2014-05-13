using System.Linq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace Tests
{
    public class FixtureCreationTests
    {
[Fact]
public void it_sets_property()
{
    var sut = new Fixture();

    var actual = sut.Create<Sample>();

    Assert.NotNull(actual.TheString);
}

[Fact]
public void it_creates_many()
{
    var sut = new Fixture();

    var actual = sut.CreateMany<Sample>();

    Assert.True(actual.Count() > 1);
}

[Theory, AutoData]
public void it_populates_test_params(int number, string theString)
{
    Assert.True(number != 0);
    Assert.NotNull(theString);
}


public class Sample
{
    public string TheString { get; set; }
}
    }
}