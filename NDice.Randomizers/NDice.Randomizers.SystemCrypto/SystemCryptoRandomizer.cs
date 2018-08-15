using System;
using System.Security.Cryptography;

namespace NDice.Randomizers
{
    public class SystemCryptoRandomizer : IRandomizable
    {
        private static RNGCryptoServiceProvider _rnd;

        public SystemCryptoRandomizer() : this(new RNGCryptoServiceProvider()) { }
        public SystemCryptoRandomizer(RNGCryptoServiceProvider rnd) => _rnd = rnd;

        public int Get(int maxValue)
        {
            int minValue = 0;
            byte[] buffer = new byte[4];

            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException("minValue");
            if (minValue == maxValue) return minValue;
            Int64 diff = maxValue - minValue;
            while (true)
            {
                _rnd.GetBytes(buffer);
                UInt32 rand = BitConverter.ToUInt32(buffer, 0);

                Int64 max = (1 + (Int64)UInt32.MaxValue);
                Int64 remainder = max % diff;
                if (rand < max - remainder)
                {
                    return (Int32)(minValue + (rand % diff));
                }
            }
        }
    }
}
