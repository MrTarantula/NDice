using System;

namespace NDice.Builders
{
    ///<summary>Randomizer that uses a provided function to roll the die.</summary>
    public class AnonymousRandomizer : IRandomizable
    {
        private Func<int, int> _roller;
        public AnonymousRandomizer(Func<int, int> roller) => _roller = roller;
        
        public int Get(int maxValue) => _roller(maxValue);
    }
}