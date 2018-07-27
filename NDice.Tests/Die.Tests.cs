using System;
using Xunit;
using NDice;

namespace NDice.Tests
{
    [Trait("Category", "Die")]
    public class DieTests
    {
        Random _rnd = new Random();

        [Fact]
        public void ConstructFairDie() => Assert.IsType<Die>(new Die());

        [Fact]
        public void ConstructFairDie_Sides() => Assert.IsType<Die>(new Die(6));

        [Fact]
        [Trait("Category", "Random")]
        public void ConstructFairDie_Random() => Assert.IsType<Die>(new Die(_rnd));

        [Fact]
        [Trait("Category", "Random")]
        public void ConstructFairDie_Sides_Random() => Assert.IsType<Die>(new Die(_rnd, 6));

        [Theory]
        [InlineData(6)]
        [InlineData(20)]
        public void Uniform(int sides)
        {
            var die = new Die(sides);
            int[] result = new int[sides];
            decimal iters = 10_000_000M;

            for (int i = 0; i < iters; i++)
            {
                result[die.Roll()]++;
            }

            for (int i = 0; i < sides; i++)
            {
                decimal roll = (result[i] - iters / sides) / iters;
                Assert.True(0.001M > roll, $"{roll} is outside of uniformity tolerance of 0.001");
            }
        }
    }
}
