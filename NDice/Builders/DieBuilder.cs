namespace NDice.Builders
{
    public class DieBuilder : BaseBuilder<Die, DieBuilder>
    {
        public override Die Build()
        {
            var die = new Die(_rnd, _sides);
            die.Labels = _labels;
            return die;
        }
    }
}