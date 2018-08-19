using System;
using System.Collections.Generic;
using NDice.Builders;
using Xunit;

namespace NDice.Tests
{
    [Trait("Category", "Builders")]
    public class WeightedDieBuilderTests
    {
        public static SystemRandomizer rnd = new SystemRandomizer();
        public static string[] labels = { "test0", "test1", "test1", "test3", "test4", "test5", "test6", "test7", "test8", "test9" };
        public static int[] weights = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static double[] doubleWeights = { 0.1, 0.1, 0.1, 0.1, 0.05, 0.15, 0.1, 0.1, 0.1, 0.1 };
        public static IEnumerable<object[]> DieBuilders()
        {
            yield return new object[] { new WeightedDieBuilder() };
            yield return new object[] { new WeightedDieBuilder()
            .WithSides(10)
            .WithLabels(labels)
            .WithWeights(weights)
            .WithRandomizer(rnd)
            .WithWeights(weights)
            .WithLabels(labels)
            .WithSides(10) };

            yield return new object[] { new WeightedDieBuilder()
            .WithSides(10)
            .WithLabels(labels)
            .WithWeights(weights)
            .WithRandomizer(i => i = 3)
            .WithWeights(weights)
            .WithLabels(labels)
            .WithSides(10) };

            yield return new object[] { new WeightedDieBuilder()
            .WithSides(10)
            .WithLabels(labels)
            .WithWeights(doubleWeights)
            .WithRandomizer(rnd)
            .WithWeights(doubleWeights)
            .WithLabels(labels)
            .WithSides(10) };

            yield return new object[] { new WeightedDieBuilder()
            .WithSides(10)
            .WithLabels(labels)
            .WithWeights(doubleWeights)
            .WithRandomizer(i => i = 3)
            .WithWeights(doubleWeights)
            .WithLabels(labels)
            .WithSides(10) };
        }

        [Theory]
        [MemberData(nameof(DieBuilders))]
        public void ConstructDieBuilders(WeightedDieBuilder builder)
        {
            Assert.IsType<WeightedDie>(builder.Build());
        }

        [Fact]
        public void ThrowWeights() => Assert.Throws<NDiceException>(() => new WeightedDieBuilder().WithLabels("test", "test2").WithWeights(1, 2, 3, 4));

        [Fact]
        public void ThrowWeightsDouble() => Assert.Throws<NDiceException>(() => new WeightedDieBuilder().WithLabels("test", "test2").WithWeights(0.1, 0.2, 0.3, 0.4));

        [Fact]
        public void ThrowLabels() => Assert.Throws<NDiceException>(() => new WeightedDieBuilder().WithWeights(1, 2, 3, 4).WithLabels("test", "test2"));

        [Fact]
        public void Implicit()
        {
            WeightedDie die = new WeightedDieBuilder();

            Assert.IsType<WeightedDie>(die);
        }

        [Theory]
        [InlineData(0.25, 0.33, 0.33)]
        [InlineData(0.25, 0.25, 0.75)]
        [InlineData(0.9999999999998, 0.0000000000001)]
        public void ThrowIfNot1(params double[] weights) => Assert.Throws<NDiceException>(() => new WeightedDieBuilder().WithWeights(weights).Build());
    }
}