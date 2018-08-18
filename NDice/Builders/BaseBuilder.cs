using System;

namespace NDice.Builders
{
    public abstract class BaseBuilder<TDie, TBuilder>
    where TDie : Die
    where TBuilder : BaseBuilder<TDie, TBuilder>
    {
        protected TBuilder _instance = null;
        protected int _sides = 6;
        protected string[] _labels;
        protected bool _hasLabels;

        protected IRandomizable _rnd = new SystemRandomizer();

        public BaseBuilder() => _instance = (TBuilder)this;

        public virtual TBuilder WithLabels(params string[] labels)
        {
            _labels = labels;
            _sides = _labels.Length;
            _hasLabels = true;
            return _instance;
        }

        public TBuilder WithRandomizer(IRandomizable rnd)
        {
            _rnd = rnd;
            return _instance;
        }

        public TBuilder WithRandomizer(Func<int, int> roller)
        {
            _rnd = new AnonymousRandomizer(roller);
            return _instance;
        }

        public virtual TBuilder WithSides(int sides)
        {
            if (!_hasLabels)
            {
                _sides = sides;
            }

            return _instance;
        }

        public abstract TDie Build();

        public static implicit operator TDie(BaseBuilder<TDie, TBuilder> builder) => builder.Build();
    }
}