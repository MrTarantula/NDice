namespace NDice.Builders
{
    /// <summary>Fluent builder for tapper's die.</sumary>
    public class TappersDieBuilder : BaseWeightedBuilder<TappersDie, TappersDieBuilder>
    {
        private bool _tapped = false;

        /// <summary>Taps the die (sets <c>Tapped</c> to true.</summary>
        public TappersDieBuilder Tapped()
        {
            _tapped = true;
            return this;
        }

        /// <summary>Taps the die (sets <c>Tapped</c> to false.</summary>
        public TappersDieBuilder Untapped()
        {
            _tapped = false;
            return this;
        }

        /// <summary>Builds the tapper's die. If builder is instantiated with explicit type of die, this call is not needed.</summary>
        public override TappersDie Build()
        {
            TappersDie die;

            if (_hasWeights)
            {
                die = new TappersDie(_rnd, _tapped, _weights);
            }
            else
            {
                die = new TappersDie(_rnd, _tapped, _sides);
            }

            die.Labels = _labels;
            return die;
        }
    }
}