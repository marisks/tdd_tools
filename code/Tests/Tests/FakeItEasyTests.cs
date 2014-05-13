using FakeItEasy;
using Xunit;

namespace Tests
{
    public class FakeItEasyTests
    {
[Fact]
public void it_creates_stub()
{
    var stub = A.Fake<IAmDependency>();

    Assert.IsAssignableFrom<IAmDependency>(stub);
}

[Fact]
public void it_returns_value_for_stub()
{
    var expected = "some string";
    var stub = A.Fake<IAmDependency>();
    A.CallTo(() => stub.ReturnOne(A<string>._)).Returns(expected);

    var actual = stub.ReturnOne("abc");

    Assert.Equal(expected, actual);
}

[Fact]
public void it_returns_value_for_stub_with_specific_input()
{
    var expected = "another string";
    var input = "input";
    var stub = A.Fake<IAmDependency>();
    A.CallTo(() => stub.ReturnOne(input)).Returns(expected);

    var actual = stub.ReturnOne(input);
    var actual2 = stub.ReturnOne("abc");
    
    Assert.Equal(expected, actual);
    Assert.Equal(string.Empty, actual2);
}

[Fact]
public void it_verifies_mock_call()
{
    var mock = A.Fake<IAmDependency>();

    mock.ReturnOne("abc");

    A.CallTo(() => mock.ReturnOne(A<string>._))
        .MustHaveHappened();
}

[Fact]
public void it_verifies_mock_call_with_specific_parameter()
{
    var expected = "some string";
    var mock = A.Fake<IAmDependency>();

    mock.ReturnOne(expected);

    A.CallTo(() => mock.ReturnOne(expected))
        .MustHaveHappened();
}

[Fact]
public void it_verifies_mock_call_with_parameter_matches_condition()
{
    var expected = "another";
    var mock = A.Fake<IAmDependency>();

    mock.ReturnOne("another string");

    A.CallTo(() => mock.ReturnOne(A<string>.That.Matches(m => m.StartsWith(expected))))
        .MustHaveHappened();
}

public interface IAmDependency
{
    string ReturnOne(string theString);
}
    }

    
}