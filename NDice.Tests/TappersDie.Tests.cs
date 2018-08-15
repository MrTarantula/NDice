using System;
using Xunit;

namespace NDice.Tests
{
    [Trait("Category", "Tappers")]
    public class TappersDieTests
    {
        IRandomizable _rnd = new SystemRandomizer();

        [Fact]
        public void Tappers_DefaultNotTapped()
        {
            var die = new TappersDie();
            die.Tap();

            Assert.True(die.Tapped);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Tappers_Tapped(bool isTapped)
        {
            var die = new TappersDie(isTapped);
            die.Tap();

            Assert.Equal(die.Tapped, !isTapped);
        }

        [Fact]
        public void TappedRollInRange() {
            var die = new TappersDie();

            die.Tap();

            for (int i = 0; i < 100; i++)
            {
                Assert.InRange(die.Roll(), 0, die.Sides - 1);
            }

            die.Tap();

            for (int i = 0; i < 100; i++)
            {
                Assert.InRange(die.Roll(), 0, die.Sides - 1);
            }
        }
    }
}