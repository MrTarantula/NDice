using System;

namespace NDice.Builders
{
    /// <summary>Base type for creating weighted die builders.</sumary>
    public abstract class BaseWeightedBuilder<TDie, TBuilder> : BaseBuilder<TDie, TBuilder>
    where TDie : WeightedDie
    where TBuilder : BaseWeightedBuilder<TDie, TBuilder>
    {
        protected int[] _weights;
        protected bool _hasWeights = false;

        /// <summary>Adds sides to die.static If labels or weights are also added, number of labels or weights will determine the number of sides.</summary>
        /// <param name="sides">Number of sides of the die.</param>
        public override TBuilder WithSides(int sides)
        {
            if (!_hasLabels && !_hasWeights)
            {
                _sides = sides;
            }

            return _instance;
        }

        /// <summary>Adds labels to die. Specifying sides isn't necessary and will be overridden bu the number of labels.</summary>
        /// <param name="labels">Labels for the die.</param>
        public override TBuilder WithLabels(params string[] labels)
        {
            if (_hasWeights && _weights.Length != labels.Length)
            {
                throw new NDiceException("Weights and labels must be the same length");
            }

            _labels = labels;
            _sides = _labels.Length;
            _hasLabels = true;
            return _instance;
        }

        /// <summary>Adds weights to die. Specifying sides isn't necessary and will be overridden bu the number of weights.</summary>
        /// <param name="weights">Pre-calculated weights of the sides of the die.</param>
        public TBuilder WithWeights(params int[] weights)
        {
            if (_hasLabels && _labels.Length != weights.Length)
            {
                throw new NDiceException("Weights and labels must be the same length");
            }

            _weights = weights;
            _sides = _weights.Length;
            _hasWeights = true;
            return _instance;
        }

        /// <summary>Adds weights to die. Specifying sides isn't necessary and will be overridden bu the number of weights.</summary>
        /// <param name="weights">Pre-calculated weights of the sides of the die. Total of weights must add up to 1.0.</param>
        public TBuilder WithWeights(params double[] weights)
        {
            if (_hasLabels && _labels.Length != weights.Length)
            {
                throw new NDiceException("Weights and labels must be the same length");
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
                throw new NDiceException($"Weights must add up to 1.0. Current sum: {total}");
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