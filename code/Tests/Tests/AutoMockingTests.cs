using System.Linq;
using FakeItEasy;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoFakeItEasy;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace Tests
{
    public class AutoMockingTests
    {
        [Fact]
        public void it_creates_fake()
        {
            var fixture = new Fixture()
                .Customize(new AutoFakeItEasyCustomization());
            var fake = fixture.Create<IAmDependency>();

            fake.ReturnOne("the string");

            A.CallTo(() => fake.ReturnOne(A<string>._))
                .MustHaveHappened();
        }

        [Fact]
        public void it_injects_fake()
        {
            var fixture = new Fixture()
                .Customize(new AutoFakeItEasyCustomization());
            var expected = fixture.Freeze<IAmDependency>();
            var consumer = fixture.Create<Consumer>();

            var actual = consumer.Dependency;

            Assert.Same(expected, actual);
        }

        [Theory, TestConventions]
        public void it_injects_fake2(
            [Frozen] IAmDependency expected,
            Consumer consumer)
        {
            var actual = consumer.Dependency;

            Assert.Same(expected, actual);
        }

        [Theory]
        [InlineAutoFakeData(1)]
        [InlineAutoFakeData(2)]
        [InlineAutoFakeData(3)]
        public void it_injects_fake_and_provides_data(
            int number,
            [Frozen] IAmDependency expected,
            Consumer consumer)
        {
            var numbers = new[] {1, 2, 3};
            var actual = consumer.Dependency;

            Assert.Same(expected, actual);
            Assert.True(numbers.Contains(number));
        }

        public class TestConventionsAttribute : AutoDataAttribute
        {
            public TestConventionsAttribute()
                : base(new Fixture()
                    .Customize(new TestConventions()))
            {
            }
        }

        public class InlineAutoFakeData : CompositeDataAttribute
        {
            public InlineAutoFakeData(params object[] values)
                : base(
                    new InlineDataAttribute(values),
                    new TestConventionsAttribute())
            {
            }
        }

        public class TestConventions : CompositeCustomization
        {
            public TestConventions()
                : base(
                    new TestConventionsCustomization(),
                    new AutoFakeItEasyCustomization())
            {
            }
        }

        public class TestConventionsCustomization : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                // Register some defaults
                // fixture.Register(A.Fake<UserManager<UserAccount>>);

                // Register custom customizations
                // fixture.Customizations.Add(new PhoneSpecimenBuilder());
            }
        }

        public class Consumer
        {
            public IAmDependency Dependency { get; private set; }

            public Consumer(IAmDependency dependency)
            {
                Dependency = dependency;
            }
        }

        public interface IAmDependency
        {
            string ReturnOne(string theString);
        }
    }
}