using System;

namespace Reuse_M2;

public interface IMonthlyReportGenerator
{
    void GenerateMonthlyReport();
    void GenerateCurrentMonthToDateReport();
    void GeneratePrevious30DayReport();
}