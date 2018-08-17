namespace NDice.Builders
{
    public class GamblersDieBuilder : BaseWeightedBuilder<GamblersDie, GamblersDieBuilder>
    {
        public override GamblersDie Build()
        {
            GamblersDie die;
            if (_weights == null)
            {
                die = new GamblersDie(_rnd, _sides);
            }
            else
            {
                die = new GamblersDie(_rnd, _weights);
            }
            die.Labels = _labels;
            return die;
        }
    }
}