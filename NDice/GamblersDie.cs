using System;

namespace NDice
{
    public class GamblersDie : WeightedDie
    {
        /// <summary>Initializes a new gambler's die with the specified number of sides. Default is six.</summary>
        /// <param name="size">Size of the die.</param>
        public GamblersDie(int size = 6) : base(size) { }

        /// <summary>Initializes a new gambler's die with known weights. Number of sides is the <c>Length</c> of the weights.</summary>
        /// <param name="weights">Pre-calculated weights of the sides of the die.</param>
        public GamblersDie(params int[] weights) : base(weights) { }

        /// <summary>Initializes a new gambler's die with the specified number of sides. Default is six. Bring your own <c>Random</c> object.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="size">Size of the die.</param>
        public GamblersDie(IRandomizable rnd, int size = 6) : base(rnd, size) { }

        /// <summary>Initializes a new gambler's die with known weights. Bring your own <c>Random</c> object.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="weights">Pre-calculated weights of the sides of the die.</param>
        public GamblersDie(IRandomizable rnd, params int[] weights) : base(rnd, weights) { }

        public GamblersDie(params double[] weights) : this(new SystemRandomizable(), weights) { }

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
