using System;

namespace NDice
{
    /// <summary>A fair die. It is not weighted, and as random as its randomizer can be.</summary>

    public class Die : IDie
    {
        /// <summary>Number of sides of the die.</sumary>
        public int Sides { get; protected set; }

        /// <summary>String labels for the die, zero-indexed. Side one would be <c>Labels[0]</c>.</sumary>
        public string[] Labels { get; set; }

        /// <summary>Current side rolled, zero-indexed.</sumary>
        public int Current { get; protected set; }

        /// <summary>Label of current side rolled, zero-indexed. </sumary>
        public string CurrentLabel => Labels[Current];

        protected IRandomizable _rnd;

        /// <summary>Initializes a new fair die with the specified number of sides. Default is six.</summary>
        /// <param name="sides">Number of sides on the die.</param>
        public Die(int sides = 6) : this(new SystemRandomizer(), sides) { }

        /// <summary>Initializes a new fair die with the specified number of sides. Default is six.</summary>
        /// <param name="rnd"><c>Random</c> object to be used when rolling the die.</param>
        /// <param name="sides">Number of sides on the die.</param>
        public Die(IRandomizable rnd, int sides = 6)
        {
            _rnd = rnd;
            Sides = sides;
        }

        /// <summary>Rolls the die.</summary>
        /// <returns>Returns the side rolled.</returns>
        public virtual int Roll()
        {
            int result = _rnd.Get(Sides);

            if (result > Sides - 1)
            {
                throw new NDiceException($"Randomizer returned {result}, which is larger than the number of sides of the die. Check randomizer implementation.");
            }

            return Current = result;
        }

        /// <summary>Rolls the die.</summary>
        /// <returns>Returns the label for the side rolled.</returns>
        public virtual string RollLabel()
        {
            Roll();
            return CurrentLabel;
        }
    }
}