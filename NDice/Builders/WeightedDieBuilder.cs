using System;

namespace NDice.Builders
{
    public class WeightedDieBuilder : BaseBuilder<WeightedDie, WeightedDieBuilder>
    {
        protected int[] _weights;

        public WeightedDieBuilder WithWeights(params int[] weights)
        {
            _weights = weights;
            return this;
        }

        public WeightedDieBuilder WithWeights(params double[] weights)
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
            return this;
        }

        public override WeightedDie Build()
        {
            WeightedDie die;

            if (_weights == null)
            {
                die = new WeightedDie(_rnd, _sides);
            }
            else
            {
                die = new WeightedDie(_rnd, _weights);
            }

            die.Labels = _labels;
            return die;
        }
    }
}