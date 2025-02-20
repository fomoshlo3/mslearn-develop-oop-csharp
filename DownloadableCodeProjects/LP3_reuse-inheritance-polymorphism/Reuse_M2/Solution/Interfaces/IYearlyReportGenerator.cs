using System;

namespace Reuse_M2;

public interface IYearlyReportGenerator
{
    void GeneratePreviousYearReport();
    void GenerateCurrentYearToDateReport();
    void GenerateLast365DaysReport();
}
