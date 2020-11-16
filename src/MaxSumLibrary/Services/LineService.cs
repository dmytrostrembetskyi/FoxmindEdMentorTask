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

        public void SetModels(string[] lines)
        {
            Lines = lines.Select((line, index) => new LineModel(index, line)).ToList();
        }

        public void FillAllInfo()
        {
            FillIsValid();
            FillSeparatedValues();
            FillParsedValues();
            FillSum();
        }

        public void FillIsValid()
        {
            var invalidLineRegex = @"[^,.\s\d]|[.]{2,}";
            Lines
                .ToList()
                .ForEach(line => line.IsValid = !Regex.Match(line.Source, invalidLineRegex).Success);
        }

        public void FillSeparatedValues()
        {
            Lines
                .Where(line => line.IsValid)
                .ToList()
                .ForEach(line =>
                    line.SourceValues = line.Source.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList());
        }

        public void FillParsedValues()
        {
            Lines
                .Where(line => line.IsValid && line.SourceValues.Count > 0)
                .ToList()
                .ForEach(line => line.ParsedValues = line.SourceValues
                    .Select(s => decimal.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture))
                    .ToList());
        }

        public void FillSum()
        {
            Lines
                .Where(line => line.IsValid && line.ParsedValues.Count > 0)
                .ToList()
                .ForEach(line => line.Sum = line.ParsedValues.Sum());
        }

        public int FindIndexWithMaxSum()
        {
            return Lines.OrderByDescending(line => line.Sum).First().Index;
        }

        public List<int> FindIndexesWithInvalidLine()
        {
            return Lines.Where(line => !line.IsValid).Select(line => line.Index).ToList();
        }
    }
}