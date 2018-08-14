using System.Collections.Generic;
using NDice.Randomizers.RandomOrg;
using NDice.Randomizers.Troschuetz;
using Xunit;

namespace NDice.Randomizers.Tests
{
    public class RandomOrgTests
    {
        public static IEnumerable<object[]> Randomizers()
        {
            yield return new object[] { new RandomOrgRandomizable("4d80880f-2b77-414e-b0b8-9390499381af") };
            yield return new object[] { new TroschuetzRandomizable() };
        }

        [Theory]
        [MemberData(nameof(Randomizers))]
        public void RollInRange(IRandomizable rnd)
        {
            var die = new Die(rnd, 10);

            for (int i = 0; i < 100; i++)
            {
                Assert.InRange(die.Roll(), 0, 10);
            }
        }
    }
}
