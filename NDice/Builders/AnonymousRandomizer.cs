using System;

namespace NDice.Builders
{
    public class AnonymousRandomizer : IRandomizable
    {
        private Func<int, int> _roller;
        public AnonymousRandomizer(Func<int, int> roller) => _roller = roller;
        
        public int Get(int maxValue) => _roller(maxValue);
    }
}