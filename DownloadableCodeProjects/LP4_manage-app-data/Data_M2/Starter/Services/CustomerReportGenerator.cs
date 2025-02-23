using System;

namespace Data_M2;

public class CustomerReportGenerator //: IMonthlyReportGenerator, IQuarterlyReportGenerator, IYearlyReportGenerator
{
    private readonly IBankCustomer _customer;

    public CustomerReportGenerator(IBankCustomer customer)
    {
        _customer = customer;
    }

    public void GenerateMonthlyReport(BankAccount account1, Transaction[] transactions1, DateOnly reportDate, BankAccount account2)
    {
        Console.WriteLine($"\nGenerating the {reportDate.ToString("MMMM")} {reportDate.Year} report for customer: {_customer.ReturnFullName()}");
        // Logic for generating monthly report based on transaction history}

    public void GenerateCurrentMonthToDateReport()
    {
        Console.WriteLine($"\nGenerating current month-to-date report for customer: {_customer.ReturnFullName()}");
        // Logic for generating current month-to-date report based on transaction history
    }

    public void GeneratePrevious30DayReport()
    {
        Console.WriteLine($"\nGenerating previous month report for customer: {_customer.ReturnFullName()}");
        // Logic for generating previous month report based on transaction history
    }

    public void GenerateQuarterlyReport()
    {
        Console.WriteLine($"\nGenerating quarterly report for customer: {_customer.ReturnFullName()}");
        // Logic for generating quarterly report based on transaction history
    }

    public void GeneratePreviousYearReport()
    {
        Console.WriteLine($"\nGenerating previous year report for customer: {_customer.ReturnFullName()}");
        // Logic for generating previous year report based on transaction history
    }

    public void GenerateCurrentYearToDateReport()
    {
        Console.WriteLine($"\nGenerating current year-to-date report for customer: {_customer.ReturnFullName()}");
        // Logic for generating current year-to-date report based on transaction history
    }

    public void GenerateLast365DaysReport()
    {
        Console.WriteLine($"\nGenerating last 365 days report for customer: {_customer.ReturnFullName()}");
        // Logic for generating last 365 days report based on transaction history
    }
}
/*

SourceAccountNumber

*/