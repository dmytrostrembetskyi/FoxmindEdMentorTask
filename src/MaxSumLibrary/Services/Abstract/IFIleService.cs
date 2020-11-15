namespace MaxSumLibrary.Services.Abstract
{
    public interface IFileService
    {
        string[] Read(string? specifiedPath);
        string GetDefaultFilePath();
    }
}