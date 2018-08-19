namespace NDice
{
    /// <summary>Behaves like a fair die, until it is tapped. Then it behaves like a weighted die until it is tapped again.</summary>
    public class TappersDie : WeightedDie
    {
        private Die _die;

        /// <summary>When true, the die is weighted.static When false, the die behaves like an unweighted die.</summary>
        public bool Tapped { get; private set; }

        /// <summary>Initializes a new tapper's die with the default of six sides.</summary>
        public TappersDie() : base()
        {
            Tapped = false;
            _die = new Die(6);
        }

        /// <summary>Initializes a new tapper's die with the specified number of sides. Default is six.</summary>
        /// <param name="tapped">Whether the die is tapped (weighted) or not (unweighted). Default is false.</param>
        /// <param name="sides">Size of the die. Default is six.</param>
        public TappersDie(bool tapped, int sides = 6) : base(sides)
        {
            Tapped = tapped;
            _die = new Die(sides);
        }

        /// <summary>Initializes a new tapper's die with known weights. Number of sides is the <c>Length</c> of the weights.</summary>
        /// <param name="tapped">Whether the die is tapped (weighted) or not (unweighted). Default is false.</param>
        /// <param name="weights">Pre-calculated weights of the sides of the die.</param>
        public TappersDie(bool tapped, params int[] weights) : base(weights)
        {
            Tapped = tapped;
            _die = new Die(weights.Length);
        }

        /// <summary>Initializes a new tapper's die with the specified number of sides. Default is six.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        public TappersDie(IRandomizable rnd) : base(rnd)
        {
            Tapped = false;
            _die = new Die(_rnd, 6);
        }

        /// <summary>Initializes a new tapper's die with the specified number of sides. Default is six.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="tapped">Whether the die is tapped (weighted) or not (unweighted). Default is false.</param>
        /// <param name="sides">Size of the die. Default is six.</param>
        public TappersDie(IRandomizable rnd, bool tapped, int sides = 6) : base(rnd, sides)
        {
            Tapped = tapped;
            _die = new Die(_rnd, sides);
        }

        /// <summary>Initializes a new tapper's die with known weights. Number of sides is the <c>Length</c> of the weights.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="tapped">Whether the die is tapped (weighted) or not (unweighted). Default is false.</param>
        /// <param name="weights">Pre-calculated weights of the sides of the die.</param>
        public TappersDie(IRandomizable rnd, bool tapped, params int[] weights) : base(rnd, weights)
        {
            Tapped = tapped;
            _die = new Die(_rnd, weights.Length);
        }

        /// <summary>Initializes a new tapper's die with known weights. Number of sides is the <c>Length</c> of the weights.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="tapped">Whether the die is tapped (weighted) or not (unweighted). Default is false.</param>
        /// <param name="weights">Pre-calculated weights of the sides of the die. Total of weights must add up to 1.0.</param>
        public TappersDie(IRandomizable rnd, bool tapped, params double[] weights) : base(rnd, weights)
        {
            Tapped = tapped;
            _die = new Die(_rnd, weights.Length);
        }

        /// <summary>Initializes a new gambler's die with known weights. Number of sides is the <c>Length</c> of the weights.</summary>
        /// <param name="weights">Pre-calculated weights of the sides of the die. Total of weights must add up to 1.0.</param>
        public TappersDie(params double[] weights) : this(false, weights) { }

        /// <summary>Initializes a new gambler's die with known weights. Number of sides is the <c>Length</c> of the weights.</summary>
        /// <param name="tapped">Whether the die is tapped (weighted) or not (unweighted). Default is false.</param>
        /// <param name="weights">Pre-calculated weights of the sides of the die. Total of weights must add up to 1.0.</param>
        public TappersDie(bool tapped, params double[] weights) : this(new SystemRandomizer(), tapped = false, weights) { }

        /// <summary>Initializes a new tapper's die with known weights. Number of sides is the <c>Length</c> of the weights.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="weights">Pre-calculated weights of the sides of the die. Total of weights must add up to 1.0.</param>
        public TappersDie(IRandomizable rnd, params double[] weights) : this(rnd, false, weights) { }

        /// <summary>Initializes a new tapper's die with the specified number of sides. Default is six.</summary>
        /// <param name="sides">Size of the die. Default is six.</param>
        public TappersDie(int sides) : this(false, sides) { }

        /// <summary>Initializes a new tapper's die with known weights. Number of sides is the <c>Length</c> of the weights.</summary>
        /// <param name="weights">Pre-calculated weights of the sides of the die.</param>
        public TappersDie(params int[] weights) : this(false, weights) { }

        /// <summary>Initializes a new tapper's die with the specified number of sides.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="sides">Size of the die.</param>
        public TappersDie(IRandomizable rnd, int sides) : this(rnd, false, sides) { }

        /// <summary>Initializes a new tapper's die with known weights. Number of sides is the <c>Length</c> of the weights.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="weights">Pre-calculated weights of the sides of the die.</param>
        public TappersDie(IRandomizable rnd, params int[] weights) : this(rnd, false, weights) { }

        /// <summary>Rolls the die.</summary>
        /// <returns>Returns the side rolled.</returns>
        public override int Roll() => Current = Tapped ? base.Roll() : _die.Roll();

        /// <summary>Toggles the die between tapped and untapped.</summary>
        public void Tap() => Tapped = !Tapped;
    }
}
