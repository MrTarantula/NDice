using System;

namespace NDice.Builders
{
    public class WeightedDieBuilder : BaseWeightedBuilder<WeightedDie, WeightedDieBuilder>
    {
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