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
            _lineService.SetModels(sourceLines);
            _consoleService.PrintInput(_lineService.Lines);
            _lineService.FillAllInfo();
            var indexWithMaxSum = _lineService.FindIndexWithMaxSum();
            var invalidIndexes = _lineService.FindIndexesWithInvalidLine();
            _consoleService.PrintResults(indexWithMaxSum, invalidIndexes);
        }
    }
}