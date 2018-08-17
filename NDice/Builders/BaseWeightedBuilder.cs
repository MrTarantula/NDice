using System;

namespace NDice.Builders
{
    public abstract class BaseWeightedBuilder<TDie, TBuilder> : BaseBuilder<TDie, TBuilder>
    where TDie : WeightedDie
    where TBuilder : BaseWeightedBuilder<TDie, TBuilder>
    {
        protected int[] _weights;

        public TBuilder WithWeights(params int[] weights)
        {
            _weights = weights;
            return _instance;
        }

        public TBuilder WithWeights(params double[] weights)
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

            _weights = normalizedWeights;
            return _instance;
        }
    }
}