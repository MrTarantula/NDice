using System;
using System.Security.Cryptography;

namespace NDice.Randomizers
{
    public class SystemCryptoRandomizer : IRandomizable
    {
        private RNGCryptoServiceProvider _rnd;

        public SystemCryptoRandomizer() : this(new RNGCryptoServiceProvider()) { }
        public SystemCryptoRandomizer(RNGCryptoServiceProvider rnd) => _rnd = rnd;

        public int Get(int maxValue)
        {
            byte[] buffer = new byte[4];
            Int64 max = (1 + (Int64)UInt32.MaxValue);
            Int64 remainder = max % maxValue;
            UInt32 rand = UInt32.MaxValue;

            while (rand > max - remainder)
            {
                _rnd.GetBytes(buffer);
                rand = BitConverter.ToUInt32(buffer, 0);
            }

            return (Int32)(rand % maxValue);
        }
    }
}