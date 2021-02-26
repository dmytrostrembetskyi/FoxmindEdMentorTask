using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using MaxSumLibrary.Helpers;

namespace MaxSumLibrary.Models
{
    public class LineModel
    {
        public LineModel(int index, string source)
        {
            Index = index;
            Source = source;
        }

        public LineModel(string source)
        {
            Source = source;
        }

        public int Index { get; }
        public string Source { get; }
        public bool IsValid { get; set; }
        public string[]? SourceValues { get; set; }
        public List<decimal> ParsedValues { get; set; } = new List<decimal>();
        public decimal Sum { get; set; }

        public void FillAllInfo()
        {
            IsValid = LineHelper.IsValid(Source);
            if (!IsValid)
                return;
            SourceValues = LineHelper.Separate(Source);
            if (SourceValues.Any())
                ParsedValues = LineHelper.Parse(SourceValues).ToList();
            if (ParsedValues.Any())
                Sum = ParsedValues.Sum();
        }

        public override string ToString()
        {
            return $"Line: {Index}; Content: [{Source}]";
        }
    }
}