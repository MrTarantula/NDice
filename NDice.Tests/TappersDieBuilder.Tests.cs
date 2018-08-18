using System;
using System.Collections.Generic;
using NDice.Builders;
using Xunit;

namespace NDice.Tests
{
    [Trait("Category", "Builders")]
    public class TappersDieBuilderTests
    {
        public static SystemRandomizer rnd = new SystemRandomizer();
        public static string[] labels = { "test0", "test1", "test1", "test3", "test4", "test5", "test6", "test7", "test8", "test9" };
        public static int[] weights = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static double[] doubleWeights = { 0.1, 0.1, 0.1, 0.1, 0.05, 0.15, 0.1, 0.1, 0.1, 0.1 };

        public static IEnumerable<object[]> DieBuilders()
        {
            yield return new object[] { new TappersDieBuilder() };

            yield return new object[] { new TappersDieBuilder()
            .WithSides(10)
            .WithLabels(labels)
            .WithWeights(weights)
            .WithRandomizer(rnd)
            .Tapped()
            .Untapped()
            .Tapped()
            .WithRandomizer(rnd)
            .WithWeights(weights)
            .WithLabels(labels)
            .WithSides(10) };

            yield return new object[] { new TappersDieBuilder()
            .WithSides(10)
            .WithLabels(labels)
            .WithWeights(weights)
            .WithRandomizer(i => i = 3)
            .Tapped()
            .Untapped()
            .Tapped()
            .WithRandomizer(i => i = 3)
            .WithWeights(weights)
            .WithLabels(labels)
            .WithSides(10) };

            yield return new object[] { new TappersDieBuilder()
            .WithSides(10)
            .WithLabels(labels)
            .WithWeights(doubleWeights)
            .WithRandomizer(rnd)
            .Tapped()
            .Untapped()
            .Tapped()
            .WithRandomizer(rnd)
            .WithWeights(doubleWeights)
            .WithLabels(labels)
            .WithSides(10) };

            yield return new object[] { new TappersDieBuilder()
            .WithSides(10)
            .WithLabels(labels)
            .WithWeights(doubleWeights)
            .WithRandomizer(i => i = 3)
            .Tapped()
            .Untapped()
            .Tapped()
            .WithRandomizer(i => i = 3)
            .WithWeights(doubleWeights)
            .WithLabels(labels)
            .WithSides(10) };
        }

        [Theory]
        [MemberData(nameof(DieBuilders))]
        public void ConstructDieBuilders(TappersDieBuilder builder)
        {
            Assert.IsType<TappersDie>(builder.Build());
        }

        [Fact]
        public void Implicit()
        {
            TappersDie die = new TappersDieBuilder();

            Assert.IsType<TappersDie>(die);
        }
    }
}