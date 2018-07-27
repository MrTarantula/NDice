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
    }
}