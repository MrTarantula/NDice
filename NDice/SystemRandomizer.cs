using System;

namespace NDice
{
    public class SystemRandomizer : IRandomizable
    {
        private Random _rnd;

        public SystemRandomizer() : this(new Random()) { }
        public SystemRandomizer(Random rnd) => _rnd = rnd;
        public int Get(int maxValue) => _rnd.Next(maxValue);
    }
}