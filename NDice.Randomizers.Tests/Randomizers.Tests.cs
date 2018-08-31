using System.Collections.Generic;
using Community.RandomOrg;
using NDice.Randomizers;
using Troschuetz.Random;
using Xunit;

namespace NDice.Randomizers.Tests
{
    public class RandomizersTests
    {
        public static RandomOrgClient client = new RandomOrgClient("4d80880f-2b77-414e-b0b8-9390499381af");
        public static TRandom trand = new TRandom();
        public static IEnumerable<object[]> Randomizers()
        {
            yield return new object[] { new RandomOrgRandomizer("4d80880f-2b77-414e-b0b8-9390499381af", 20) };
            yield return new object[] { new RandomOrgRandomizer("4d80880f-2b77-414e-b0b8-9390499381af") };
            yield return new object[] { new RandomOrgRandomizer(client) };
            yield return new object[] { new TroschuetzRandomizer() };
            yield return new object[] { new TroschuetzRandomizer(trand) };
            yield return new object[] { new SystemCryptoRandomizer() };
        }

        [Theory]
        [MemberData(nameof(Randomizers))]
        public void RollInRange(IRandomizable rnd)
        {
            var die = new Die(rnd, 10);

            for (int i = 0; i < 50; i++)
            {
                Assert.InRange(die.Roll(), 0, 10);
            }
        }

        [Fact]
        [Trait("Category", "Uniformity")]
        public void InitialRollUniformity_RandomOrg()
        {
            var results = new int[4];
            for (int x = 0; x < 20; x++)
            {
                var rnd = new RandomOrgRandomizer("4d80880f-2b77-414e-b0b8-9390499381af", 0);
                var die = new Die(rnd, 4);
                results[die.Roll()]++;
            }

            // All less than 30% is good enough for this test
            Assert.True(results[0] / 20 < 0.3, $"Side 0: {results[0]}");
            Assert.True(results[1] / 20 < 0.3, $"Side 1: {results[1]}");
            Assert.True(results[2] / 20 < 0.3, $"Side 2: {results[2]}");
            Assert.True(results[3] / 20 < 0.3, $"Side 3: {results[3]}");
        }

        [Fact]
        [Trait("Category", "Uniformity")]
        public void InitialRollUniformity_SystemCrypto()
        {
            var results = new int[4];
            for (int x = 0; x < 100; x++)
            {
                var rnd = new SystemCryptoRandomizer();
                var die = new Die(rnd, 4);
                results[die.Roll()]++;
            }

            // All less than 30% is good enough for this test
            Assert.True(results[0] / 100 < 0.3, $"Side 0: {results[0]}");
            Assert.True(results[1] / 100 < 0.3, $"Side 1: {results[1]}");
            Assert.True(results[2] / 100 < 0.3, $"Side 2: {results[2]}");
            Assert.True(results[3] / 100 < 0.3, $"Side 3: {results[3]}");
        }

        [Fact]
        [Trait("Category", "Uniformity")]
        public void InitialRollUniformity_Troschuetz()
        {
            var results = new int[4];
            for (int x = 0; x < 1000; x++)
            {
                var rnd = new TroschuetzRandomizer();
                var die = new Die(rnd, 4);
                results[die.Roll()]++;
            }

            // All less than 30% is good enough for this test
            Assert.True(results[0] / 1000 < 0.3, $"Side 0: {results[0]}");
            Assert.True(results[1] / 1000 < 0.3, $"Side 1: {results[1]}");
            Assert.True(results[2] / 1000 < 0.3, $"Side 2: {results[2]}");
            Assert.True(results[3] / 1000 < 0.3, $"Side 3: {results[3]}");
        }
    }
}
