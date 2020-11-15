using System;
using System.Collections.Generic;
using System.IO;
using MaxSumLibrary.Models;
using MaxSumLibrary.Services.Abstract;

namespace ConsoleApp.Services
{
    public class ConsoleService
    {
        private readonly IFileService _fileService;
        private readonly ILineService _lineService;

        public ConsoleService(IFileService fileService, ILineService lineService)
        {
            _fileService = fileService;
            _lineService = lineService;
        }

        public void Run()
        {
            PrintWelcome();
            var sourceFilePath = AskInputFile();
            var sourceLines = _fileService.Read(sourceFilePath);
            var mappedLines = _lineService.MapToModel(sourceLines);
            PrintInput(mappedLines);
            var linesWithInfo = _lineService.FillAllInfo(mappedLines);
            var indexWithMaxSum = _lineService.FindIndexWithMaxSum(linesWithInfo);
            var invalidIndexes = _lineService.FindInvalidLineIndexes(linesWithInfo);
            PrintResults(indexWithMaxSum, invalidIndexes);
        }

        private void PrintWelcome()
        {
            Console.WriteLine("Greetings, my lord!");
        }

        private string? AskInputFile()
        {
            var path = "";

            while (!File.Exists(path))
            {
                Console.WriteLine("Specify path to input file, or press Enter to use default file");
                path = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(path))
                    return null;
            }

            return path;
        }

        private void PrintInput(List<LineModel> lines)
        {
            Console.WriteLine("Your input is:");
            lines.ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        private void PrintResults(int indexWithMaxSum, List<int> invalidIndexes)
        {
            Console.WriteLine("Results:");
            Console.WriteLine($"Line with max sum: {indexWithMaxSum}");
            Console.WriteLine($"Invalid lines: {string.Join(", ", invalidIndexes)}");
        }
    }
}