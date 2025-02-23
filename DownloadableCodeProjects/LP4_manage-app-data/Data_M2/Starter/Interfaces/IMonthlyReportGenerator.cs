using System;

namespace Data_M2;

public interface IMonthlyReportGenerator
{
    void GenerateMonthlyReport(Transaction[] transactions, DateOnly reportDate);
    void GenerateCurrentMonthToDateReport(Transaction[] transactions, DateOnly reportDate);
    void GeneratePrevious30DayReport(Transaction[] transactions, DateOnly reportDate);
}