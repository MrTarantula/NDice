namespace NDice.Builders
{
    /// <summary>Fluent builder for die.</sumary>
    public class DieBuilder : BaseBuilder<Die, DieBuilder>
    {
        /// <summary>Builds the die. If builder is instantiated with explicit type of die, this call is not needed.</summary>
        public override Die Build()
        {
            var die = new Die(_rnd, _sides);
            die.Labels = _labels;
            return die;
        }
    }
}