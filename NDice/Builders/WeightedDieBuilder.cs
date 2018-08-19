using System;

namespace NDice.Builders
{
        /// <summary>Fluent builder for weighted die.</sumary>
    public class WeightedDieBuilder : BaseWeightedBuilder<WeightedDie, WeightedDieBuilder>
    {
        /// <summary>Builds the weighted die. If builder is instantiated with explicit type of die, this call is not needed.</summary>
        public override WeightedDie Build()
        {
            WeightedDie die;

            if (_hasWeights)
            {
                die = new WeightedDie(_rnd, _weights);
            }
            else
            {
                die = new WeightedDie(_rnd, _sides);
            }

            die.Labels = _labels;
            return die;
        }
    }
}