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
        public List<LineModel> MapToModel(string[] lines)
        {
            return lines.Select((line, index) => new LineModel(index, line)).ToList();
        }

        public List<LineModel> FillAllInfo(List<LineModel> lines)
        {
            FillIsValid(lines);
            FillSeparatedValues(lines);
            FillParsedValues(lines);
            FillSum(lines);
            return lines;
        }

        public void FillIsValid(List<LineModel> lines)
        {
            var invalidLineRegex = @"[^,.\s\d]|[.]{2,}";
            lines
                .ToList()
                .ForEach(line => line.IsValid = !Regex.Match(line.Source, invalidLineRegex).Success);
        }

        public void FillSeparatedValues(List<LineModel> lines)
        {
            lines
                .Where(line => line.IsValid)
                .ToList()
                .ForEach(line =>
                    line.SourceValues = line.Source.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList());
        }

        public void FillParsedValues(List<LineModel> lines)
        {
            lines
                .Where(line => line.IsValid && line.SourceValues.Count > 0)
                .ToList()
                .ForEach(line => line.ParsedValues = line.SourceValues
                    .Select(s => decimal.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture))
                    .ToList());
        }

        public void FillSum(List<LineModel> lines)
        {
            lines
                .Where(line => line.IsValid && line.ParsedValues.Count > 0)
                .ToList()
                .ForEach(line => line.Sum = line.ParsedValues.Sum());
        }

        public int FindIndexWithMaxSum(List<LineModel> lines)
        {
            return lines.OrderByDescending(line => line.Sum).First().Index;
        }

        public List<int> FindInvalidLineIndexes(List<LineModel> lines)
        {
            return lines.Where(line => !line.IsValid).Select(line => line.Index).ToList();
        }
    }
}