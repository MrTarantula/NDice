using System.Collections.Generic;
using NDice.Builders;
using Xunit;

namespace NDice.Tests
{
    [Trait("Category", "Builders")]
    public class DieBuilderTests
    {
        public static SystemRandomizer rnd = new SystemRandomizer();
        public static string[] labels = { "test", "test", "test", "test", "test", "test", "test", "test", "test", "test" };
        public static IEnumerable<object[]> DieBuilders()
        {
            yield return new object[] { new DieBuilder() };

            yield return new object[] { new DieBuilder()
            .WithSides(10)
            .WithLabels(labels)
            .WithRandomizer(rnd)
            .WithLabels(labels)
            .WithSides(10) };

            yield return new object[] { new DieBuilder()
            .WithSides(10)
            .WithLabels(labels)
            .WithRandomizer(i => i = 3)
            .WithLabels(labels)
            .WithSides(10) };
        }

        [Theory]
        [MemberData(nameof(DieBuilders))]
        public void ConstructDieBuilders(DieBuilder builder)
        {
            Assert.IsType<Die>(builder.Build());
        }

        [Fact]
        public void Implicit()
        {
            Die die = new DieBuilder();

            Assert.IsType<Die>(die);
        }

        [Fact]
        public void AnonRoll()
        {
            Die die = new DieBuilder().WithRandomizer(i => 2);

            Assert.Equal(2, die.Roll());
        }
    }
}