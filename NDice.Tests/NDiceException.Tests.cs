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

        public static BadRandomizer rnd = new BadRandomizer();

        public static IEnumerable<object[]> BadDice()
        {
            yield return new object[] { new Die(rnd) };
            yield return new object[] { new WeightedDie(rnd) };
        }

        public static IEnumerable<object[]> Exceptions()
        {
            yield return new object[] { new NDiceException() };
            yield return new object[] { new NDiceException("test message") };
            yield return new object[] { new NDiceException("test message", new Exception("inner")) };
        }

        [Theory]
        [MemberData(nameof(BadDice))]
        public void ThrowWhenRolled(IDie die) => Assert.Throws<NDiceException>(() => die.Roll());

        [Theory]
        [MemberData(nameof(Exceptions))]
        public void NDiceExceptionConstructors(NDiceException ex) => Assert.IsAssignableFrom<NDiceException>(ex);
    }
}