using System.IO;
using MaxSumLibrary.Services.Abstract;

namespace MaxSumLibrary.Services
{
    public class FileService : IFileService
    {
        public string[] Read(string? specifiedPath)
        {
            var pathToUse = specifiedPath ?? GetDefaultFilePath();
            return File.ReadAllLines(pathToUse);
        }

        public string GetDefaultFilePath()
        {
            var fileName = "source.txt";
            var sourceFilePath = Path.Combine("..", "..", "..", "..", "..", fileName);
            return sourceFilePath;
        }
    }
}