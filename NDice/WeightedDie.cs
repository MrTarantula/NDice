using System;

namespace NDice
{
    public class WeightedDie : Die
    {
        /// <summary>Weights for each side of the die, zero-indexed. Side one would be <c>Weight[0]</c>.</summary>
        public int[] Weight { get; protected set; }

        /// <summary>Initializes a new weighted die with the specified number of sides. Default is six.</summary>
        /// <param name="size">Size of the die.</param>
        public WeightedDie(int size = 6) : this(new SystemRandomizer(), size) { }

        /// <summary>Initializes a new weighted die with the specified number of sides. Default is six. Bring your own <c>Random</c> object.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="size">Size of the die.</param>
        public WeightedDie(IRandomizable rnd, int size = 6) : base(rnd, size)
        {
            Weight = new int[Sides];

            for (int i = 0; i < Sides; i++)
            {
                Weight[i] = 1;
            }
        }

        public WeightedDie(params double[] weights) : this(new SystemRandomizer(), weights) { }
        
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
                throw new Exception("Weights must add up to 1.0");
            }

            var multiplier = 1 / smallest;

            for (int i = 0; i < decWeights.Length; i++)
            {
                normalizedWeights[i] = (int)(decWeights[i] * multiplier);
            }

            Weight = normalizedWeights;
        }

        public WeightedDie(params int[] weights) : this(new SystemRandomizer(), weights) { }

        /// <summary>Initializes a new weighted die with known weights. Bring your own <c>Random</c> object.</summary>
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

            // Find the target
            for (int rand = _rnd.Get(sum); rand >= 0; target++)
            {
                rand -= Weight[target];
            }

            return Current = target - 1;
        }
    }
}
