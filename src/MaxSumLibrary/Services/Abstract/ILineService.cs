using System.Collections.Generic;
using MaxSumLibrary.Models;

namespace MaxSumLibrary.Services.Abstract
{
    public interface ILineService
    {
        List<LineModel> Lines { get; set; }
        void InitLines(string[] lines);
        void FillAllInfo();
        int FindIndexWithMaxSum();
        IEnumerable<int> FindIndexesWithInvalidLine();
    }
}