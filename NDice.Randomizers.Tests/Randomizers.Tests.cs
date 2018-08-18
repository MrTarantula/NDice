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
    }
}
