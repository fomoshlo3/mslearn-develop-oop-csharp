using System;

namespace Data_M2;

public interface IMonthlyReportGenerator
{
    void GenerateMonthlyReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate);
    void GenerateCurrentMonthToDateReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate);
    void GeneratePrevious30DayReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate);

}