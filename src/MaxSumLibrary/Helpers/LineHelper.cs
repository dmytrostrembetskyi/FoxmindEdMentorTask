using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace MaxSumLibrary.Helpers
{
    public static class LineHelper
    {
        public static bool IsValid(string source)
        {
            var invalidLineRegex = @"[^,.\s\d-]|[.-]{2,}";
            return !Regex
                .Match(source, invalidLineRegex)
                .Success;
        }

        public static string[] Separate(string source)
        {
            return source.Split(",", StringSplitOptions.RemoveEmptyEntries);
        }

        public static IEnumerable<decimal> Parse(IEnumerable<string> sourceValues)
        {
            return sourceValues.Select(source =>
                decimal.Parse(source, NumberStyles.Any, CultureInfo.InvariantCulture));
        }
    }
}