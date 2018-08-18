using System.Collections.Generic;
using NDice.Builders;
using Xunit;

namespace NDice.Tests
{
    [Trait("Category", "Builders")]
    public class DieBuilderTests
    {
        public static SystemRandomizer rnd = new SystemRandomizer();
        public static string[] labels = { "test0", "test1", "test1", "test3", "test4", "test5", "test6", "test7", "test8", "test9" };
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
        public void Labels()
        {
            Die die = new DieBuilder().WithLabels("test0", "test1", "test2").Build();
            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(die.RollLabel(), die.Labels[die.Current]);
            }
        }

        [Fact]
        public void ShouldAssignLabelsLengthToSides()
        {
            var die = new DieBuilder().WithLabels("test", "test2").WithSides(4).Build();
            Assert.Equal(2, die.Sides);
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