using System;

namespace Data_M1;

public interface IYearlyReportGenerator
{
    void GeneratePreviousYearReport();
    void GenerateCurrentYearToDateReport();
    void GenerateLast365DaysReport();
}
