using System.Collections.Generic;
using MaxSumLibrary.Helpers;
using MaxSumLibrary.Services;
using Xunit;

namespace MaxSumLibrary.Tests
{
    public class LineServiceShould
    {
        private LineService _lineService;


        public LineServiceShould()
        {
            _lineService = new LineService();
        }

        private static IEnumerable<object[]> LinesWithMaxSum()
        {
            yield return new object[] {new[] {"15.999", "9.36, 0.9, 6.96", "6,,   7   ,,,0.8,,,6", ",-8,,80",}, 3};
            yield return new object[] {new[] {"0", "8,7,9", "-9,-6,5",}, 1};
        }

        [Theory]
        [MemberData(nameof(LinesWithMaxSum))]
        public void FindIndexWithMaxSum(string[] lines, int lineIndex)
        {
            _lineService.InitLines(lines);
            _lineService.FillAllInfo();
            Assert.Equal(lineIndex, _lineService.FindIndexWithMaxSum());
        }
        
        private static IEnumerable<object[]> IndexesWithInvalidLines()
        {
            yield return new object[] {new[] {"15.999", "hello world", "6,,  7 ,,0.8,,6", "1....5,6",}, new[] {1,3} };
            yield return new object[] {new[] {"15.999", "12, 2.0", "10,     @,     11", ",-8,,80",}, new[] {2} };
        }
        
        [Theory]
        [MemberData(nameof(IndexesWithInvalidLines))]
        public void FindIndexesWithInvalidLines(string[] lines, int[] indexesWithInvalidLines)
        {
            _lineService.InitLines(lines);
            _lineService.FillAllInfo();
            Assert.Equal(indexesWithInvalidLines, _lineService.FindIndexesWithInvalidLine());
        }
    }
}