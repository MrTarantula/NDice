using System;

namespace NDice
{
    public class TappersDie : WeightedDie
    {
        private Die _die;
        public bool Tapped { get; private set; }

        public TappersDie() : base()
        {
            Tapped = false;
            _die = new Die(6);
        }

        public TappersDie(bool tapped, int sides = 6) : base(sides)
        {
            Tapped = tapped;
            _die = new Die(sides);
        }

        public TappersDie(bool tapped, params int[] weights) : base(weights)
        {
            Tapped = tapped;
            _die = new Die(weights.Length);
        }

        public TappersDie(Random rnd) : base(rnd)
        {
            Tapped = false;
            _die = new Die(6);
        }

        public TappersDie(Random rnd, bool tapped, int sides = 6) : base(rnd, sides)
        {
            Tapped = tapped;
            _die = new Die(sides);
        }

        public TappersDie(Random rnd, bool tapped, params int[] weights) : base(rnd, weights)
        {
            Tapped = tapped;
            _die = new Die(weights.Length);
        }

        public TappersDie(int sides) : this(false, sides) { }
        public TappersDie(params int[] weights) : this(false, weights) { }
        public TappersDie(Random rnd, int sides) : this(rnd, false, sides) { }
        public TappersDie(Random rnd, params int[] weights) : this(rnd, false, weights) { }

        /// <summary>Rolls the die.</summary>
        /// <returns>Returns the side rolled.</returns>
        public override int Roll() => Tapped ? base.Roll() : _die.Roll();

        public void Tap() => Tapped = !Tapped;
    }
}
