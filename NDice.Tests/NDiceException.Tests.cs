using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using Moq;
using Xunit;

namespace NDice.Tests
{
    public class NDiceExceptionTests
    {
        public class BadRandomizer : IRandomizable
        {
            public int Get(int maxValue) => 15000;
        }

        public class AccessProtectedCtorForNDiceException : NDiceException
        {
            public AccessProtectedCtorForNDiceException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
        }

        public static BadRandomizer rnd = new BadRandomizer();

        public static IEnumerable<object[]> BadDice()
        {
            yield return new object[] { new Die(rnd) };
            yield return new object[] { new WeightedDie(rnd) };
        }



        private static AccessProtectedCtorForNDiceException CreateExceptionForTest()
        {
            var info = new SerializationInfo(typeof(AccessProtectedCtorForNDiceException),
                       new FormatterConverter());
            info.AddValue("ClassName", string.Empty);
            info.AddValue("Message", string.Empty);
            info.AddValue("InnerException", new ArgumentException());
            info.AddValue("HelpURL", string.Empty);
            info.AddValue("StackTraceString", string.Empty);
            info.AddValue("RemoteStackTraceString", string.Empty);
            info.AddValue("RemoteStackIndex", 0);
            info.AddValue("ExceptionMethod", string.Empty);
            info.AddValue("HResult", 1);
            info.AddValue("Source", string.Empty);
            
            return new AccessProtectedCtorForNDiceException(info, new StreamingContext());
        }

        public static IEnumerable<object[]> Exceptions()
        {
            yield return new object[] { new NDiceException() };
            yield return new object[] { new NDiceException("test message") };
            yield return new object[] { new NDiceException("test message", new Exception("inner")) };
            yield return new object[] { CreateExceptionForTest() };
        }

        [Theory]
        [MemberData(nameof(BadDice))]
        public void ThrowWhenRolled(IDie die) => Assert.Throws<NDiceException>(() => die.Roll());

        [Theory]
        [MemberData(nameof(Exceptions))]
        public void NDiceExceptionConstructors(NDiceException ex) => Assert.IsAssignableFrom<NDiceException>(ex);
    }
}