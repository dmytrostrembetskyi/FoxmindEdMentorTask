using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApp.Services.Abstract;
using MaxSumLibrary.Models;

namespace ConsoleApp.Services
{
    public class ConsoleService : IConsoleService
    {
        public void PrintWelcome()
        {
            Console.WriteLine("Greetings, my lord!");
        }

        public string? AskInputFile()
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

        public void PrintInput(List<LineModel> lines)
        {
            Console.WriteLine("Your input is:");
            lines.ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        public void PrintResults(int indexWithMaxSum, List<int> indexesWithInvalidLine)
        {
            Console.WriteLine("Results:");
            Console.WriteLine($"Line with max sum: {indexWithMaxSum}");
            Console.WriteLine($"Invalid lines: {string.Join(", ", indexesWithInvalidLine)}");
        }
    }
}