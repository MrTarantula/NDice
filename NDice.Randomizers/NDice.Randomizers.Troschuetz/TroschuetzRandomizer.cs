using NDice;
using Troschuetz.Random;

namespace NDice.Randomizers
{
    /// <summary>Uses <c>Troschuetz.Random</c>> to roll the die.</summary>
    public class TroschuetzRandomizer : IRandomizable
    {
        private TRandom _rnd;

        public TroschuetzRandomizer() : this(new TRandom()) { }
        public TroschuetzRandomizer(TRandom rnd)
        {
            _rnd = rnd;

            // rnd needs to be primed. TODO: Remove this when no longer needed
            rnd.Next(6);
            rnd.Next(6);
            rnd.Next(6);
        }
        public int Get(int maxValue) => _rnd.Next(maxValue);
    }
}