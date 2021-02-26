using System;
using System.Collections.Generic;
using System.Linq;
using MaxSumLibrary.Models;
using MaxSumLibrary.Services;
using Xunit;

namespace MaxSumLibrary.Tests
{
    public class LineModelShould
    {
        [Theory]
        [InlineData("6", 6)]
        [InlineData("12, 2.0", 14)]
        [InlineData(",-8,,80", 72)]
        [InlineData("6,,   7   ,,,0.8,,,6", 19.8)]
        public void FindSum(string sourceLine, decimal sum)
        {
            var line = new LineModel(sourceLine);
            line.FillAllInfo();
            Assert.Equal(sum, line.Sum);
        }
    }
}