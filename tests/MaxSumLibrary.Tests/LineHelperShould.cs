using System.Collections.Generic;
using System.Linq;
using MaxSumLibrary.Helpers;
using MaxSumLibrary.Models;
using Xunit;

namespace MaxSumLibrary.Tests
{
    public class LineHelperShould
    {
        [Theory]
        [InlineData("")]
        [InlineData("0")]
        [InlineData("15.999")]
        [InlineData("12, 2.0")]
        [InlineData("9.36, 0.9, 6.96")]
        [InlineData("6,,   7   ,,,0.8,,,6")]
        [InlineData("-8")]
        [InlineData(",-8,,80")]
        public void FindValidLine(string source)
        {
            Assert.True(LineHelper.IsValid(source));
        }

        [Theory]
        [InlineData("hello world")]
        [InlineData("1.....5,6")]
        [InlineData("10,     @,     11")]
        [InlineData(",---8")]
        public void FindInvalidLines(string source)
        {
            Assert.False(LineHelper.IsValid(source));
        }

        private static IEnumerable<object[]> SeparatedValues()
        {
            yield return new object[] {"15.999", new string[] {"15.999"}};
            yield return new object[] {"-8,80", new string[] {"-8", "80"}};
            yield return new object[] {"6,7,0.8", new string[] {"6", "7", "0.8"}};
        }

        [Theory]
        [MemberData(nameof(SeparatedValues))]
        public void SeparateValues(string source, string[] separatedValues)
        {
            Assert.Equal(separatedValues, LineHelper.Separate(source));
        }

        private static IEnumerable<object[]> SeparatedAndParsedValues()
        {
            yield return new object[] {new string[] {"6", "7"}, new List<decimal> {6m, 7m}};
            yield return new object[] {new string[] {"-8", "80", "0.6"}, new List<decimal> {-8, 80, 0.6m}};
        }

        [Theory]
        [MemberData(nameof(SeparatedAndParsedValues))]
        public void ParseValues(string[] separatedValues, List<decimal> parsedValues)
        {
            Assert.Equal(parsedValues, LineHelper.Parse(separatedValues));
        }
    }
}