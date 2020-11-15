using System.Collections.Generic;
using MaxSumLibrary.Models;

namespace MaxSumLibrary.Services.Abstract
{
    public interface ILineService
    {
        List<LineModel> MapToModel(string[] lines);
        List<LineModel> FillAllInfo(List<LineModel> sourceLines);
        void FillIsValid(List<LineModel> lines);
        void FillSeparatedValues(List<LineModel> lines);
        void FillParsedValues(List<LineModel> lines);
        void FillSum(List<LineModel> lines);
        int FindIndexWithMaxSum(List<LineModel> lines);
        List<int> FindInvalidLineIndexes(List<LineModel> lines);
    }
}