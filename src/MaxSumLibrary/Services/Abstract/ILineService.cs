using System.Collections.Generic;
using MaxSumLibrary.Models;

namespace MaxSumLibrary.Services.Abstract
{
    public interface ILineService
    {
        List<LineModel> Lines { get; set; }
        void SetModels(string[] lines);
        void FillAllInfo();
        void FillIsValid();
        void FillSeparatedValues();
        void FillParsedValues();
        void FillSum();
        int FindIndexWithMaxSum();
        List<int> FindIndexesWithInvalidLine();
    }
}