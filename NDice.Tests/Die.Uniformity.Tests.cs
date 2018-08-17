using System;
using System.Collections.Generic;
using Xunit;

namespace NDice.Tests
{
    [Trait("Category", "Uniformity")]
    public class UniformityTests
    {
        private static SystemRandomizer rnd = new SystemRandomizer();
        public static IEnumerable<object[]> UniformDice()
        {
            yield return new object[] { new Die() };
            yield return new object[] { new WeightedDie() };
            yield return new object[] { new GamblersDie() };
            yield return new object[] { new TappersDie(true) };
            yield return new object[] { new Die(rnd) };
            yield return new object[] { new WeightedDie(rnd) };
            yield return new object[] { new GamblersDie(rnd) };
            yield return new object[] { new TappersDie(rnd, true) };
        }

        [Theory]
        [MemberData(nameof(UniformDice))]
        public void Uniform(Die die)
        {
            int[] result = new int[die.Sides];
            decimal iters = 2_000_000M;

            for (int i = 0; i < iters; i++)
            {
                result[die.Roll()]++;
            }

            for (int i = 0; i < die.Sides; i++)
            {
                decimal roll = (result[i] - iters / die.Sides) / iters;
                Assert.True(0.001M > roll, $"{roll} is outside of uniformity tolerance of 0.001");
            }
        }
    }
}