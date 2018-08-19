namespace NDice.Builders
{
    /// <summary>Fluent builder for gambler's die.</sumary>
    public class GamblersDieBuilder : BaseWeightedBuilder<GamblersDie, GamblersDieBuilder>
    {
        /// <summary>Builds the gambler's die. If builder is instantiated with explicit type of die, this call is not needed.</summary>

        public override GamblersDie Build()
        {
            GamblersDie die;

            if (_hasWeights)
            {
                die = new GamblersDie(_rnd, _weights);
            }
            else
            {
                die = new GamblersDie(_rnd, _sides);
            }

            die.Labels = _labels;
            return die;
        }
    }
}