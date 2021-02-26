using System.Collections.Generic;
using MaxSumLibrary.Models;

namespace ConsoleApp.Services.Abstract
{
    public interface IConsoleService
    {
        void PrintWelcome();
        string? AskInputFile();
        void PrintInput(List<LineModel> lines);
        void PrintResults(int indexWithMaxSum, IEnumerable<int> indexesWithInvalidLine);
    }
}