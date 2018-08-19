using System;
using System.Collections.Generic;
using Xunit;

namespace NDice.Tests
{
    public class WeightedDieTests
    {
        public static SystemRandomizer rnd = new SystemRandomizer();
        public static IEnumerable<object[]> NonUniformWeightedDice()
        {
            yield return new object[] { new WeightedDie(4, 3, 2, 1) };
            yield return new object[] { new WeightedDie(rnd, 4, 3, 2, 1) };
            yield return new object[] { new WeightedDie(0.4, 0.3, 0.2, 0.1) };
            yield return new object[] { new WeightedDie(rnd, 0.4, 0.3, 0.2, 0.1) };
        }

        public static IEnumerable<object[]> NormalizedDouble()
        {
            yield return new object[] { new WeightedDie(0.25, 0.25, 0.5), new int[] { 1, 1, 2 } };
            yield return new object[] { new WeightedDie(0.125, 0.125, 0.25, 0.25, 0.125, 0.125), new int[] { 1, 1, 2, 2, 1, 1 } };
            yield return new object[] { new WeightedDie(0.33, 0.33, 0.34), new int[] { 1, 1, 1 } };
            yield return new object[] { new WeightedDie(0.4, 0.3, 0.2, 0.1), new int[] { 4, 3, 2, 1 } };
            yield return new object[] { new WeightedDie(0.01, 0.09, 0.4, 0.5), new int[] { 1, 9, 40, 50 } };
        }

        [Theory]
        [MemberData(nameof(NonUniformWeightedDice))]
        [Trait("Category", "Uniformity")]
        public void NonUniform_Inferred(Die die)
        {
            decimal iters = 2_000_000M;
            int[] result = new int[] { 0, 0, 0, 0 };

            for (int run = 0; run < iters; run++)
            {
                result[die.Roll()]++;
            }

            Assert.True(Math.Abs(0.4M - result[0] / iters) < 0.001M, $"Side one is outside of uniformity tolerance: {Math.Abs(0.4M - result[0] / iters)}");
            Assert.True(Math.Abs(0.3M - result[1] / iters) < 0.001M, $"Side two is outside of uniformity tolerance: {Math.Abs(0.3M - result[1] / iters)}");
            Assert.True(Math.Abs(0.2M - result[2] / iters) < 0.001M, $"Side three is outside of uniformity tolerance: {Math.Abs(0.2M - result[2] / iters)}");
            Assert.True(Math.Abs(0.1M - result[3] / iters) < 0.001M, $"Side four is outside of uniformity tolerance: {Math.Abs(0.1M - result[3] / iters)}");
        }

        [Theory]
        [MemberData(nameof(NormalizedDouble))]
        public void NormalizeDoubleWeights(WeightedDie die, params int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                Assert.Equal(values[i], die.Weight[i]);
            }
        }

        [Theory]
        [InlineData(0.25, 0.33, 0.33)]
        [InlineData(0.25, 0.25, 0.75)]
        [InlineData(0.9999999999998, 0.0000000000001)]
        public void NormalizeDoubleWeights_ThrowIfNot1(params double[] weights) => Assert.Throws<NDiceException>(() => new WeightedDie(weights));
    }
}