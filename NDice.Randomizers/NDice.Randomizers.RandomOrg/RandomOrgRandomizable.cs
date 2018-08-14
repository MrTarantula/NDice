using System;
using System.Collections.Generic;
using Community.RandomOrg;

namespace NDice.Randomizers.RandomOrg
{
    public class RandomOrgRandomizable : IRandomizable
    {
        private RandomOrgClient _client;
        private IReadOnlyList<int> _cache;
        private int _cacheSize = 10;
        private int _index = 0;
        private int _lastMax;

        public RandomOrgRandomizable(string apiKey) : this(new RandomOrgClient(apiKey)) { }
        public RandomOrgRandomizable(RandomOrgClient client) => _client = client;

        public int Get(int maxValue)
        {
            int result;
            if (_lastMax != maxValue)
            {
                result = _client.GenerateIntegersAsync(1, 0, maxValue, false).Result.Random.Data[0];
            }
            else if (_cache == null || _index == _cacheSize)
            {
                _cache = _client.GenerateIntegersAsync(_cacheSize, 0, maxValue, false).Result.Random.Data;
                _index = 0;
                result = _cache[_index++];
            }
            else
            {
                result = _cache[_index++];
            }

            _lastMax = maxValue;
            return result;
        }
    }
}
