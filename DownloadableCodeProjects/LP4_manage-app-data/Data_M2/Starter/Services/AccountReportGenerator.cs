using System;

namespace Data_M2;

public class AccountReportGenerator : IMonthlyReportGenerator, IQuarterlyReportGenerator, IYearlyReportGenerator
{
    private readonly IBankAccount _account;

    public AccountReportGenerator(IBankAccount account)
    {
        _account = account;
    }

    public void GenerateMonthlyReport(Transaction[] transactions, DateOnly reportDate)
    {
        Console.WriteLine($"Generating the {reportDate.ToString("MMMM")} {reportDate.Year} report for account: {_account.AccountNumber}");
        // Logic for generating monthly report based on transaction history
    }

    public void GenerateCurrentMonthToDateReport(Transaction[] transactions, DateOnly endDate)
    {
        Console.WriteLine($"Generating current month-to-date report for account: {_account.AccountNumber}");
        // Logic for generating current month-to-date report based on transaction history
    }

    public void GeneratePrevious30DayReport(Transaction[] transactions, DateOnly endDate)
    {
        Console.WriteLine($"Generating previous 30 days report for account: {_account.AccountNumber}");
        // Logic for generating previous 30 days report based on transaction history
    }

    public void GenerateQuarterlyReport(Transaction[] transactions, DateOnly reportDate)
    {
        Console.WriteLine($"Generating quarterly report for account: {_account.AccountNumber}");
        // Logic for generating quarterly report based on transaction history
    }

    public void GeneratePreviousYearReport(Transaction[] transactions, DateOnly reportDate)
    {
        Console.WriteLine($"Generating previous year report for account: {_account.AccountNumber}");
        // Logic for generating previous year report based on transaction history
    }

    public void GenerateCurrentYearToDateReport(Transaction[] transactions, DateOnly endDate)
    {
        Console.WriteLine($"Generating current year-to-date report for account: {_account.AccountNumber}");
        // Logic for generating current year-to-date report based on transaction history
    }

    public void GenerateLast365DaysReport(Transaction[] transactions, DateOnly endDate)
    {
        Console.WriteLine($"Generating last 365 days report for account: {_account.AccountNumber}");
        // Logic for generating last 365 days report based on transaction history
    }
}