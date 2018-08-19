namespace NDice
{
    /// <summary>
    /// Weighted die that obeys the Gambler's Fallacy. The weight shifts after each roll, 
    /// so that the longer a side has not been rolled, the higher its probability of occurrence for the next roll.
    /// </summary>
    public class GamblersDie : WeightedDie
    {
        /// <summary>Initializes a new gambler's die with the specified number of sides. Default is six.</summary>
        /// <param name="sides">Number of sides on the die.</param>
        public GamblersDie(int sides = 6) : base(sides) { }

        /// <summary>Initializes a new gambler's die with known weights. Number of sides is the <c>Length</c> of the weights.</summary>
        /// <param name="weights">Pre-calculated weights of the sides of the die.</param>
        public GamblersDie(params int[] weights) : base(weights) { }

        /// <summary>Initializes a new gambler's die with the specified number of sides. Default is six.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="sides">Number of sides on the die.</param>
        public GamblersDie(IRandomizable rnd, int sides = 6) : base(rnd, sides) { }

        /// <summary>Initializes a new gambler's die with known weights.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="weights">Pre-calculated weights of the sides of the die.</param>
        public GamblersDie(IRandomizable rnd, params int[] weights) : base(rnd, weights) { }

        /// <summary>Initializes a new gambler's die with known weights. Number of sides is the <c>Length</c> of the weights.</summary>
        /// <param name="weights">Pre-calculated weights of the sides of the die. Total of weights must add up to 1.0.</param>
        public GamblersDie(params double[] weights) : this(new SystemRandomizer(), weights) { }

        /// <summary>Initializes a new gambler's die with known weights. Number of sides is the <c>Length</c> of the weights.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="weights">Pre-calculated weights of the sides of the die. Total of weights must add up to 1.0.</param>
        public GamblersDie(IRandomizable rnd, params double[] weights) : base(rnd, weights) { }

        /// <summary>Rolls the die.</summary>
        /// <returns>Returns the side rolled.</returns>
        public override int Roll()
        {
            var target = base.Roll();

            // Update the weights
            for (int i = 0; i < Sides; i++)
            {
                if (i == target)
                {
                    Weight[i] = 1;
                }
                else
                {
                    Weight[i]++;
                }
            }

            return Current;
        }
    }
}