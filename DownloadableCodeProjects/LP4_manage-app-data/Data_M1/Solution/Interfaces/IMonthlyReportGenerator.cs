using System;

namespace Data_M1;

public interface IMonthlyReportGenerator
{
    void GenerateMonthlyReport();
    void GenerateCurrentMonthToDateReport();
    void GeneratePrevious30DayReport();
}