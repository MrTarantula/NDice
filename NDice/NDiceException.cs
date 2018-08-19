using System;
using System.Runtime.Serialization;

namespace NDice
{
    public class NDiceException : Exception
    {
        public NDiceException() : base() { }
        public NDiceException(string message) : base(message) { }
        public NDiceException(string message, Exception innerException) : base(message, innerException) { }
        protected NDiceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}