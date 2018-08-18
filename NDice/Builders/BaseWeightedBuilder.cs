using System;

namespace NDice.Builders
{
    public abstract class BaseWeightedBuilder<TDie, TBuilder> : BaseBuilder<TDie, TBuilder>
    where TDie : WeightedDie
    where TBuilder : BaseWeightedBuilder<TDie, TBuilder>
    {
        protected int[] _weights;
        protected bool _hasWeights;

        public override TBuilder WithSides(int sides)
        {
            if (!_hasLabels && !_hasWeights)
            {
                _sides = sides;
            }

            return _instance;
        }

        public override TBuilder WithLabels(params string[] labels)
        {
            if (_hasWeights && _weights.Length != labels.Length)
            {
                throw new ArgumentException("Weights and labels must be the same length");
            }

            _labels = labels;
            _sides = _labels.Length;
            _hasLabels = true;
            return _instance;
        }

        public TBuilder WithWeights(params int[] weights)
        {
            if (_hasLabels && _labels.Length != weights.Length)
            {
                throw new ArgumentException("Weights and labels must be the same length");
            }

            _weights = weights;
            _sides = _weights.Length;
            _hasWeights = true;
            return _instance;
        }

        public TBuilder WithWeights(params double[] weights)
        {
            if (_hasLabels && _labels.Length != weights.Length)
            {
                throw new ArgumentException("Weights and labels must be the same length");
            }
            
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
            _sides = _weights.Length;
            _hasWeights = true;
            return _instance;
        }
    }
}