using System;
using System.Collections.Generic;
using Xunit;

namespace NDice.Tests
{
    [Trait("Category", "Common")]
    public class CommonTests
    {
        public static SystemRandomizable rnd = new SystemRandomizable();
        public static IEnumerable<object[]> Constructors_NoRandom()
        {
            yield return new object[] { new Die() };
            yield return new object[] { new Die(6) };

            yield return new object[] { new WeightedDie() };
            yield return new object[] { new WeightedDie(6) };
            yield return new object[] { new WeightedDie(1, 2, 3, 4, 5, 6) };
            yield return new object[] { new WeightedDie(0.25, 0.25, 0.125, 0.125, 0.25) };
            yield return new object[] { new WeightedDie(new int[] { 1, 2, 3, 4, 5, 6 }) };
            yield return new object[] { new WeightedDie(new double[] { 0.25, 0.25, 0.125, 0.125, 0.25 }) };

            yield return new object[] { new GamblersDie() };
            yield return new object[] { new GamblersDie(6) };
            yield return new object[] { new GamblersDie(1, 2, 3, 4, 5, 6) };
            yield return new object[] { new GamblersDie(0.25, 0.25, 0.125, 0.125, 0.25) };
            yield return new object[] { new GamblersDie(new int[] { 1, 2, 3, 4, 5, 6 }) };
            yield return new object[] { new GamblersDie(new double[] { 0.25, 0.25, 0.125, 0.125, 0.25 }) };

            yield return new object[] { new TappersDie() };
            yield return new object[] { new TappersDie(6) };
            yield return new object[] { new TappersDie(1, 2, 3, 4, 5, 6) };
            yield return new object[] { new TappersDie(0.25, 0.25, 0.125, 0.125, 0.25) };
            yield return new object[] { new TappersDie(new int[] { 1, 2, 3, 4, 5, 6 }) };
            yield return new object[] { new TappersDie(new double[] { 0.25, 0.25, 0.125, 0.125, 0.25 }) };
        }

        public static IEnumerable<object[]> Constructors_Random()
        {
            yield return new object[] { new Die(rnd) };
            yield return new object[] { new Die(rnd, 6) };

            yield return new object[] { new WeightedDie(rnd) };
            yield return new object[] { new WeightedDie(rnd, 6) };
            yield return new object[] { new WeightedDie(rnd, 1, 2, 3, 4, 5, 6) };
            yield return new object[] { new WeightedDie(rnd, 0.25, 0.25, 0.125, 0.125, 0.25) };
            yield return new object[] { new WeightedDie(rnd, new int[] { 1, 2, 3, 4, 5, 6 }) };
            yield return new object[] { new WeightedDie(rnd, new double[] { 0.25, 0.25, 0.125, 0.125, 0.25 }) };

            yield return new object[] { new GamblersDie(rnd) };
            yield return new object[] { new GamblersDie(rnd, 6) };
            yield return new object[] { new GamblersDie(rnd, 1, 2, 3, 4, 5, 6) };
            yield return new object[] { new GamblersDie(rnd, 0.25, 0.25, 0.125, 0.125, 0.25) };
            yield return new object[] { new GamblersDie(rnd, new int[] { 1, 2, 3, 4, 5, 6 }) };
            yield return new object[] { new GamblersDie(rnd, new double[] { 0.25, 0.25, 0.125, 0.125, 0.25 }) };

            yield return new object[] { new TappersDie(rnd) };
            yield return new object[] { new TappersDie(rnd, 6) };
            yield return new object[] { new TappersDie(rnd, 1, 2, 3, 4, 5, 6) };
            yield return new object[] { new TappersDie(rnd, 0.25, 0.25, 0.125, 0.125, 0.25) };
            yield return new object[] { new TappersDie(rnd, new int[] { 1, 2, 3, 4, 5, 6 }) };
            yield return new object[] { new TappersDie(rnd, new double[] { 0.25, 0.25, 0.125, 0.125, 0.25 }) };
        }

        [Theory]
        [MemberData(nameof(Constructors_NoRandom))]
        [MemberData(nameof(Constructors_Random))]
        public void Constructors(Die die)
        {
            Assert.True(die.Sides > 0);
        }

        [Theory]
        [MemberData(nameof(Constructors_NoRandom))]
        [MemberData(nameof(Constructors_Random))]
        public void RollInRange(Die die)
        {
            for (int i = 0; i < 100; i++)
            {
                Assert.InRange(die.Roll(), 0, die.Sides - 1);
            }
        }

        [Theory]
        [MemberData(nameof(Constructors_NoRandom))]
        [MemberData(nameof(Constructors_Random))]
        public void RollAndCurrentAreEqual(Die die)
        {
            for (int i = 0; i < 100; i++)
            {
                Assert.Equal(die.Roll(), die.Current);
            }
        }
    }
}