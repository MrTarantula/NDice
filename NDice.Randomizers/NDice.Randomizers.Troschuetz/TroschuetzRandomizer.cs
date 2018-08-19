using NDice;
using Troschuetz.Random;

namespace NDice.Randomizers
{
    /// <summary>Uses <c>Troschuetz.Random</c>> to roll the die.</summary>
    public class TroschuetzRandomizer : IRandomizable
    {
        private TRandom _rnd;

        public TroschuetzRandomizer() : this(new TRandom()) { }
        public TroschuetzRandomizer(TRandom rnd) => _rnd = rnd;
        public int Get(int maxValue) => _rnd.Next(maxValue);
    }
}