using System;

namespace NDice
{
    public class NDiceException : Exception
    {
        public NDiceException() : base() { }
        public NDiceException(string message) : base(message) { }
        public NDiceException(string message, Exception innerException) : base(message, innerException) { }
    }
}