using System;

namespace NDice
{
    /// <summary>Die with one or more sides weighted to have a higher probablility of occurrence.</summary>
    public class WeightedDie : Die
    {
        /// <summary>Weights for each side of the die, zero-indexed. Side one would be <c>Weight[0]</c>.</summary>
        public int[] Weight { get; protected set; }

        /// <summary>Initializes a new weighted die with the specified number of sides. Default is six.</summary>
        /// <param name="sides">Number of sides on the die.</param>
        public WeightedDie(int sides = 6) : this(new SystemRandomizer(), sides) { }

        /// <summary>Initializes a new weighted die with the specified number of sides. Default is six.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="sides">Number of sides on the die.</param>
        public WeightedDie(IRandomizable rnd, int sides = 6) : base(rnd, sides)
        {
            Weight = new int[Sides];

            for (int i = 0; i < Sides; i++)
            {
                Weight[i] = 1;
            }
        }

        /// <summary>Initializes a new weighted die with known weights.</summary>
        /// <param name="weights">Pre-calculated weights of the sides of the die. Total of weights must add up to 1.0.</param>
        public WeightedDie(params double[] weights) : this(new SystemRandomizer(), weights) { }

        /// <summary>Initializes a new weighted die with known weights.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="weights">Pre-calculated weights of the sides of the die. Total of weights must add up to 1.0.</param>
        public WeightedDie(IRandomizable rnd, params double[] weights) : base(rnd, weights.Length)
        {
            decimal total = 0M;
            decimal[] decWeights = Array.ConvertAll(weights, x => (decimal)x);

            var smallest = decWeights[0];
            int[] normalizedWeights = new int[decWeights.Length];

            foreach (var w in decWeights)
            {
                smallest = w < smallest ? w : smallest;
                total += w;
            }

            if (total != 1.0M)
            {
                throw new NDiceException($"Weights must add up to 1.0. Current sum: {total}");
            }

            var multiplier = 1 / smallest;

            for (int i = 0; i < decWeights.Length; i++)
            {
                normalizedWeights[i] = (int)(decWeights[i] * multiplier);
            }

            Weight = normalizedWeights;
        }

        /// <summary>Initializes a new weighted die with known weights.</summary>
        /// <param name="weights">Pre-calculated weights of the sides of the die.</param>
        public WeightedDie(params int[] weights) : this(new SystemRandomizer(), weights) { }

        /// <summary>Initializes a new weighted die with known weights.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="weights">Pre-calculated weights of the sides of the die.</param>
        public WeightedDie(IRandomizable rnd, params int[] weights) : base(rnd, weights.Length) => Weight = weights;

        /// <summary>Rolls the die.</summary>
        /// <returns>Returns the side rolled.</returns>
        public override int Roll()
        {
            int sum = 0;
            int target = 0;

            // Add up all of the states
            foreach (int w in Weight)
            {
                sum += w;
            }
            int result = _rnd.Get(sum);

            if (result > sum)
            {
                throw new NDiceException($"Randomizer returned {result}, which is larger than the number of sides of the die. Check randomizer implementation.");
            }

            // Find the target
            for (int rand = result; rand >= 0; target++)
            {
                rand -= Weight[target];
            }

            return Current = target - 1;
        }
    }
}