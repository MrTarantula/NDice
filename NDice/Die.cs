using System;

namespace NDice
{
    public class Die : IDie
    {
        public int Sides { get; protected set; }
        public string[] Labels { get; set; }
        public int Current { get; protected set; }
        public string CurrentLabel => Labels[Current];

        protected IRandomizable _rnd;

        /// <summary>Initializes a new fair die with the specified number of sides. Default is six.</summary>
        /// <param name="sides">Number of sides on the die.</param>
        public Die(int sides = 6) : this(new SystemRandomizer(), sides) { }

        /// <summary>Initializes a new fair die with the specified number of sides. Default is six. Bring your own <c>Random</c> object.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="sides">Number of sides on the die.</param>
        public Die(IRandomizable rnd, int sides = 6)
        {
            _rnd = rnd;
            Sides = sides;
        }

        /// <summary>Rolls the die.</summary>
        /// <returns>Returns the side rolled.</returns>
        public virtual int Roll() => Current = _rnd.Get(Sides);
        public virtual string RollLabel() {
            Roll();
            return CurrentLabel;
        }
    }
}