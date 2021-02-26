using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using MaxSumLibrary.Models;
using MaxSumLibrary.Services.Abstract;

namespace MaxSumLibrary.Services
{
    public class LineService : ILineService
    {
        public LineService()
        {
            Lines = new List<LineModel>();
        }

        public List<LineModel> Lines { get; set; }

        public void InitLines(string[] lines)
        {
            Lines = lines
                .Select((line, index) => new LineModel(index, line))
                .ToList();
        }

        public void FillAllInfo()
        {
            Lines.ForEach(line => line.FillAllInfo());
        }

        public int FindIndexWithMaxSum()
        {
            return Lines
                .OrderByDescending(line => line.Sum)
                .First()
                .Index;
        }

        public IEnumerable<int> FindIndexesWithInvalidLine()
        {
            return Lines
                .Where(line => !line.IsValid)
                .Select(line => line.Index);
        }
    }
}