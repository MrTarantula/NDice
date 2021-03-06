﻿using System.Collections.Generic;
using Community.RandomOrg;

namespace NDice.Randomizers
{
    /// <summary>Uses random.org API to fetch random numbers from the web. Rolls are cached to prevent API calls when possible.</summary>
    public class RandomOrgRandomizer : IRandomizable
    {
        private readonly RandomOrgClient _client;
        private IReadOnlyList<int> _cache;
        private readonly int _cacheSize;
        private int _index;
        private int _lastMax;

        public RandomOrgRandomizer(string apiKey) : this(new RandomOrgClient(apiKey)) { }
        public RandomOrgRandomizer(string apiKey, int cacheSize) : this(new RandomOrgClient(apiKey), cacheSize) { }
        public RandomOrgRandomizer(RandomOrgClient client) : this(client, 10) { }
        public RandomOrgRandomizer(RandomOrgClient client, int cacheSize)
        {
            _client = client;
            _cacheSize = cacheSize;
        }

        public int Get(int maxValue)
        {
            int result;

            // For dice whose weights change, a number has to be requested each roll. 
            // For others, rolls are cached for efficiency
            if (_lastMax != maxValue || _lastMax == 0)
            {
                result = _client.GenerateIntegersAsync(1, 0, maxValue - 1, true).Result.Random.Data[0];
            }
            else if (_cache == null || _index == _cacheSize)
            {
                _cache = _client.GenerateIntegersAsync(_cacheSize, 0, maxValue - 1, true).Result.Random.Data;
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