using NDice;
using Troschuetz.Random;

namespace NDice.Randomizers.Troschuetz
{
    public class TroschuetzRandomizable : IRandomizable
    {
        private TRandom _rnd;

        public TroschuetzRandomizable() : this(new TRandom()) { }
        public TroschuetzRandomizable(TRandom rnd) => _rnd = rnd;
        public int Get(int maxValue) => _rnd.Next(maxValue);
    }
}