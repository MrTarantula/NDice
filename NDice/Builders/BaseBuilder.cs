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
        protected IRandomizable _rnd = new SystemRandomizer();

        public BaseBuilder() => _instance = (TBuilder)this;

        public TBuilder WithLabels(params string[] labels)
        {
            _labels = labels;
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

        public TBuilder WithSides(int sides)
        {
            _sides = sides;
            return _instance;
        }

        public abstract TDie Build();

        public static implicit operator TDie(BaseBuilder<TDie, TBuilder> builder) => builder.Build();
    }
}