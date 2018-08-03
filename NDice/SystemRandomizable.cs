using System;

namespace NDice
{
    public class SystemRandomizable : IRandomizable
    {
        private Random _rnd;

        public SystemRandomizable() : this(new Random()) { }
        public SystemRandomizable(Random rnd) => _rnd = rnd;
        public int Get(int maxValue) => _rnd.Next(maxValue);
    }
}