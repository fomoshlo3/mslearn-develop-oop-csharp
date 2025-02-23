using System;

namespace Data_M2;

public interface IYearlyReportGenerator
{
    void GeneratePreviousYearReport(Transaction[] transactions, DateOnly reportDate);
    void GenerateCurrentYearToDateReport(Transaction[] transactions, DateOnly reportDate);
    void GenerateLast365DaysReport(Transaction[] transactions, DateOnly reportDate);
}
