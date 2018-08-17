namespace NDice.Builders
{
    public class TappersDieBuilder : BaseWeightedBuilder<TappersDie, TappersDieBuilder>
    {
        private bool _tapped = false;

        public TappersDieBuilder Tapped()
        {
            _tapped = true;
            return this;
        }

        public TappersDieBuilder Untapped()
        {
            _tapped = false;
            return this;
        }

        public override TappersDie Build()
        {
            TappersDie die;
            if (_weights == null)
            {
                die = new TappersDie(_rnd, _tapped, _sides);
            }
            else
            {
                die = new TappersDie(_rnd, _tapped, _weights);
            }
            die.Labels = _labels;
            return die;
        }
    }
}