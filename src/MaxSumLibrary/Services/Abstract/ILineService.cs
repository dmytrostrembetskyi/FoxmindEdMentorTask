using System.Collections.Generic;
using MaxSumLibrary.Models;

namespace MaxSumLibrary.Services.Abstract
{
    public interface ILineService
    {
        List<LineModel> Lines { get; set; }
        void InitLines(string[] lines);
        void FillAllInfo();
        void FillIsValid();
        void FillSourceValues();
        void FillParsedValues();
        void FillSum();
        int FindIndexWithMaxSum();
        List<int> FindIndexesWithInvalidLine();
    }
}