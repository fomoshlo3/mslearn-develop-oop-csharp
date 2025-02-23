using System;

namespace Data_M2;

public interface IQuarterlyReportGenerator
{
    void GenerateQuarterlyReport(Transaction[] transactions, DateOnly reportDate);
}
