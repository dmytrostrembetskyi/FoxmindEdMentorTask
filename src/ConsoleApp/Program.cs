using ConsoleApp.Services;
using MaxSumLibrary.Services;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var consoleService = new ConsoleService(new FileService(), new LineService());
            consoleService.Run();
        }
    }
}