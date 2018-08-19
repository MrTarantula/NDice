using System;

namespace NDice.Builders
{
    /// <summary>Base type for creating die builders.</sumary>
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

        /// <summary>Adds sides to die.static If labels are also added, number of labels will determine the number of sides.</summary>
        /// <param name="sides">Number of sides of the die.</param>
        public virtual TBuilder WithSides(int sides)
        {
            if (!_hasLabels)
            {
                _sides = sides;
            }

            return _instance;
        }

        /// <summary>Adds labels to die. Specifying sides isn't necessary and will be overridden bu the number of labels.</summary>
        /// <param name="labels">Labels for the die.</param>
        public virtual TBuilder WithLabels(params string[] labels)
        {
            _labels = labels;
            _sides = _labels.Length;
            _hasLabels = true;
            return _instance;
        }

        /// <summary>Adds randomizer to die.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        public TBuilder WithRandomizer(IRandomizable rnd)
        {
            _rnd = rnd;
            return _instance;
        }

        /// <summary>Adds randomizer to die.</summary>
        /// <param name="roller">Expression to be used when rolling the die.</param>
        public TBuilder WithRandomizer(Func<int, int> roller)
        {
            _rnd = new AnonymousRandomizer(roller);
            return _instance;
        }

        /// <summary>Builds the die. If builder is instantiated with explicit type of die, this call is not needed.</summary>
        public abstract TDie Build();

        public static implicit operator TDie(BaseBuilder<TDie, TBuilder> builder) => builder.Build();
    }
}