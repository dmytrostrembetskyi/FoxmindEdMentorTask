using ConsoleApp.Services.Abstract;
using MaxSumLibrary.Services.Abstract;

namespace ConsoleApp.Services
{
    public class MainService : IMainService
    {
        private readonly IConsoleService _consoleService;
        private readonly IFileService _fileService;
        private readonly ILineService _lineService;

        public MainService(IFileService fileService, ILineService lineService, IConsoleService consoleService)
        {
            _fileService = fileService;
            _lineService = lineService;
            _consoleService = consoleService;
        }

        public void Run()
        {
            _consoleService.PrintWelcome();
            var sourceFilePath = _consoleService.AskInputFile();
            var sourceLines = _fileService.Read(sourceFilePath);
            var mappedLines = _lineService.MapToModel(sourceLines);
            _consoleService.PrintInput(mappedLines);
            var linesWithInfo = _lineService.FillAllInfo(mappedLines);
            var indexWithMaxSum = _lineService.FindIndexWithMaxSum(linesWithInfo);
            var invalidIndexes = _lineService.FindInvalidLineIndexes(linesWithInfo);
            _consoleService.PrintResults(indexWithMaxSum, invalidIndexes);
        }
    }
}