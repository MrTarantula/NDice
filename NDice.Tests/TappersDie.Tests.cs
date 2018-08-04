using System;
using Xunit;
using NDice;

namespace NDice.Tests
{
    [Trait("Category", "Tappers")]
    public class TappersDieTests
    {
        [Fact]
        public void TappersDieTest()
        {
            var die = new TappersDie(true, 1, 1, 1, 1000000, 1, 1, 1);

            decimal iters = 10_000_000M;
            int[] result = new int[] { 0, 0, 0, 0, 0, 0, 0 };

            for (int run = 0; run < iters; run++)
            {
                result[die.Roll()]++;
            }

            Assert.True(result[0] / iters < 0.001M);
            Assert.True(result[1] / iters < 0.001M);
            Assert.True(result[2] / iters < 0.001M);
            Assert.True(result[3] / iters > 0.9M);
            Assert.True(result[4] / iters < 0.001M);
            Assert.True(result[5] / iters < 0.001M);
            Assert.True(result[6] / iters < 0.001M);
        }

        [Fact]
        public void TapTest()
        {
            var die = new TappersDie(true, 1, 1, 1, 1000000, 1, 1, 1);

            die.Tap();
            decimal iters = 1_000_000M;
            int[] result = new int[] { 0, 0, 0, 0, 0, 0, 0 };

            for (int run = 0; run < iters; run++)
            {
                result[die.Roll()]++;
            }

            Assert.True(Math.Abs(0.143M - result[0] / iters) < 0.001M, $"0 - {0.143M - result[0] / iters}");
            Assert.True(Math.Abs(0.143M - result[1] / iters) < 0.001M, $"1 - {0.143M - result[1] / iters}");
            Assert.True(Math.Abs(0.143M - result[2] / iters) < 0.001M, $"2 - {0.143M - result[2] / iters}");
            Assert.True(Math.Abs(0.143M - result[3] / iters) < 0.001M, $"3 - {0.143M - result[3] / iters}");
            Assert.True(Math.Abs(0.143M - result[4] / iters) < 0.001M, $"4 - {0.143M - result[4] / iters}");
            Assert.True(Math.Abs(0.143M - result[5] / iters) < 0.001M, $"5 - {0.143M - result[5] / iters}");
            Assert.True(Math.Abs(0.143M - result[6] / iters) < 0.001M, $"6 - {0.143M - result[6] / iters}");
        }

        [Fact]
        public void TappersTest()
        {
            var die = new TappersDie(false, 1, 1, 1, 1000000, 1, 1, 1);
            die.Tap();

            decimal iters = 10_000_000M;
            int[] result = new int[] { 0, 0, 0, 0, 0, 0, 0 };

            for (int run = 0; run < iters; run++)
            {
                result[die.Roll()]++;
            }

            Assert.True(result[0] / iters < 0.001M);
            Assert.True(result[1] / iters < 0.001M);
            Assert.True(result[2] / iters < 0.001M);
            Assert.True(result[3] / iters > 0.9M);
            Assert.True(result[4] / iters < 0.001M);
            Assert.True(result[5] / iters < 0.001M);
            Assert.True(result[6] / iters < 0.001M);
        }

         [Trait("Category", "Double")]
        [Fact]
        public void NormalizeWeights()
        {
            var die = new TappersDie(0.25, 0.25, 0.5);
            Assert.Equal(1, die.Weight[0]);
            Assert.Equal(1, die.Weight[1]);
            Assert.Equal(2, die.Weight[2]);
        }

        [Trait("Category", "Double")]
        [Fact]
        public void NormalizeWeights_Imprecise()
        {
            var die = new TappersDie(0.33, 0.33, 0.34);
            Assert.Equal(1, die.Weight[0]);
            Assert.Equal(1, die.Weight[1]);
            Assert.Equal(1, die.Weight[2]);
        }

        [Trait("Category", "Double")]
        [Theory]
        [InlineData(0.25, 0.33, 0.33)]
        [InlineData(0.25, 0.25, 0.75)]
        public void NormalizeWeights_ThrowIfNot1(double a, double b, double c) => Assert.Throws<Exception>(() => new TappersDie(a, b, c));
    }
}