using ConsoleApp.Services;
using MaxSumLibrary.Services;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var consoleService = new MainService(new FileService(), new LineService(), new ConsoleService());
            consoleService.Run();
        }
    }
}