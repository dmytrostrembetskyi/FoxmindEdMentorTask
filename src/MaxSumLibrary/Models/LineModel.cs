using System.Collections.Generic;

namespace MaxSumLibrary.Models
{
    public class LineModel
    {
        public LineModel(int index, string source)
        {
            Index = index;
            Source = source;
            SourceValues = new List<string>();
            ParsedValues = new List<decimal>();
        }

        public int Index { get; }
        public string Source { get; }
        public bool IsValid { get; set; }
        public List<string> SourceValues { get; set; }
        public List<decimal> ParsedValues { get; set; }
        public decimal Sum { get; set; }

        public override string ToString()
        {
            return $"Line: {Index}; Content: [{Source}]";
        }
    }
}