using System;
using System.Security.Cryptography;

namespace NDice.Randomizers
{
    /// <summary>
    /// Uses <c>System.Security.Cryptography.RNGCryptoServiceProvider</c> to roll the die. 
    /// Taken from <a href="https://gist.github.com/niik/1017834">this gist</a>.
    /// </summary>
    public class SystemCryptoRandomizer : IRandomizable
    {
        private RandomNumberGenerator _rnd;

        private byte[] _buffer;

        private int _bufferPosition;

        public SystemCryptoRandomizer() : this(RandomNumberGenerator.Create()) { }
        public SystemCryptoRandomizer(RandomNumberGenerator rnd) => _rnd = rnd;

        public int Get(int maxValue)
        {
            long diff = maxValue;

            while (true)
            {
                if (_buffer == null || _buffer.Length != 4 || (_buffer.Length - _bufferPosition) < 4)
                {
                    _buffer = new byte[4];
                    _rnd.GetBytes(_buffer);
                    _bufferPosition = 0;
                }

                uint rand = BitConverter.ToUInt32(_buffer, _bufferPosition);

                _bufferPosition += 4;

                long max = 1 + (long)uint.MaxValue;
                long remainder = max % diff;

                if (rand < max - remainder)
                    return (int)((rand % diff));
            }
        }
    }
}