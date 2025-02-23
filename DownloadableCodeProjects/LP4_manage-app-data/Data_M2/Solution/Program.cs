using Data_M1;
using System.Globalization;
using System.Collections.ObjectModel;

class Program
{
    static void Main(string[] args)
    {
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Task 2: Create date and time values using DateTime, DateOnly, TimeOnly, CultureInfo, Calendar, CalendarWeekRule, DayOfWeek, and TimeZoneInfo classes

        // Get the current date and time
        DateTime now = DateTime.Now;
        Console.WriteLine($"\nCurrent date and time: {now}");

        // Get the current date only
        DateOnly today = DateOnly.FromDateTime(now);
        Console.WriteLine($"Current date only: {today}");

        // Get the current time only
        TimeOnly currentTime = TimeOnly.FromDateTime(now);
        Console.WriteLine($"Current time only: {currentTime}");

        // Get the current day of the week
        DayOfWeek dayOfWeek = today.DayOfWeek;
        Console.WriteLine($"Current day of the week: {dayOfWeek}");

        // Get the current day of the year
        int dayOfYear = today.DayOfYear;
        Console.WriteLine($"Current day of the year: {dayOfYear}");

        // Get the current week of the year
        CultureInfo culture = CultureInfo.CurrentCulture;
        CalendarWeekRule weekRule = culture.DateTimeFormat.CalendarWeekRule;
        DayOfWeek firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;
        Calendar calendar = culture.Calendar;
        int weekOfYear = calendar.GetWeekOfYear(now, weekRule, firstDayOfWeek);
        Console.WriteLine($"Current week of the year: {weekOfYear}");

        // Get the current month of the year
        int month = today.Month;
        Console.WriteLine($"Current month of the year: {month}");

        // Get the current quarter of the year
        int quarter = (month - 1) / 3 + 1;
        Console.WriteLine($"Current quarter of the year: {quarter}");

        // Get the current year
        int year = today.Year;
        Console.WriteLine($"Current year: {year}");

        // Get the number of days in the current month
        int daysInMonth = DateTime.DaysInMonth(year, month);
        Console.WriteLine($"Number of days in the current month: {daysInMonth}");

        // Get the number of days in the current year
        int daysInYear = DateTime.IsLeapYear(year) ? 366 : 365;
        Console.WriteLine($"Number of days in the current year: {daysInYear}");

        // Get the number of days remaining in the current year
        int daysRemaining = daysInYear - dayOfYear;
        Console.WriteLine($"Number of days remaining in the current year: {daysRemaining}");

        // Get the number of days remaining in the current month
        int daysRemainingInMonth = daysInMonth - today.Day;
        Console.WriteLine($"Number of days remaining in the current month: {daysRemainingInMonth}");

        // Get the number of days remaining in the current week
        int daysRemainingInWeek = 7 - (int)dayOfWeek;
        Console.WriteLine($"Number of days remaining in the current week: {daysRemainingInWeek}");

        // Get the date for the first day of the current month
        DateOnly firstDayOfMonth = new DateOnly(year, month, 1);
        Console.WriteLine($"First day of the current month: {firstDayOfMonth}");

        // Get the date for the last day of the current month
        DateOnly lastDayOfMonth = new DateOnly(year, month, daysInMonth);
        Console.WriteLine($"Last day of the current month: {lastDayOfMonth}");

        // Get the date for the first day of the current quarter
        int firstMonthOfQuarter = (quarter - 1) * 3 + 1;
        DateOnly firstDayOfQuarter = new DateOnly(year, firstMonthOfQuarter, 1);
        Console.WriteLine($"First day of the current quarter: {firstDayOfQuarter}");

        // Get the date for the last day of the current quarter
        int lastMonthOfQuarter = firstMonthOfQuarter + 2;
        int daysInQuarter = DateTime.DaysInMonth(year, firstMonthOfQuarter) + DateTime.DaysInMonth(year, firstMonthOfQuarter + 1) + DateTime.DaysInMonth(year, lastMonthOfQuarter);
        DateOnly lastDayOfQuarter = new DateOnly(year, lastMonthOfQuarter, DateTime.DaysInMonth(year, lastMonthOfQuarter));
        Console.WriteLine($"Last day of the current quarter: {lastDayOfQuarter}");

        // Get the date for the first day of the current year
        DateOnly firstDayOfYear = new DateOnly(year, 1, 1);
        Console.WriteLine($"First day of the current year: {firstDayOfYear}");

        // Get the date for the first day of the previous month
        DateOnly firstDayOfPreviousMonth = new DateOnly(today.Year, today.Month - 1, 1);
        Console.WriteLine($"First day of the previous month: {firstDayOfPreviousMonth}");

        // Add days to the current date
        DateTime futureDate = now.AddDays(10);
        Console.WriteLine($"Date 10 days from now: {futureDate}");

        // Add months to the current date
        DateTime futureMonth = now.AddMonths(1);
        Console.WriteLine($"Date 1 month from now: {futureMonth}");

        // Add years to the current date
        DateTime futureYear = now.AddYears(1);
        Console.WriteLine($"Date 1 year from now: {futureYear}");

        // Add minutes to the current time
        DateTime futureMinutes = now.AddMinutes(30);
        Console.WriteLine($"Time 30 minutes from now: {futureMinutes}");

        // Add seconds to the current time
        DateTime futureSeconds = now.AddSeconds(45);
        Console.WriteLine($"Time 45 seconds from now: {futureSeconds}");

        // Parse a date string
        DateTime parsedDate = DateTime.Parse("2025-02-03");
        Console.WriteLine($"Parsed date: {parsedDate}");

        // Try to parse a date string
        if (DateTime.TryParse("2025-02-03", out DateTime tryParsedDate))
        {
            Console.WriteLine($"Try parsed date: {tryParsedDate}");
        }

        // Format a date
        string formattedDate = now.ToString("yyyy-MM-dd");
        Console.WriteLine($"Formatted date: {formattedDate}");

        // Use DateTimeOffset
        DateTimeOffset nowOffset = DateTimeOffset.Now;
        Console.WriteLine($"Current date and time with offset: {nowOffset}");

        DateTimeOffset utcNowOffset = DateTimeOffset.UtcNow;
        Console.WriteLine($"Current date and time in UTC with offset: {utcNowOffset}");

        // Get the current timezone
        TimeZoneInfo localZone = TimeZoneInfo.Local;

        // Get the offset from UTC
        TimeSpan offset = localZone.GetUtcOffset(DateTime.Now);

        // Display the timezone information
        Console.WriteLine($"Local Time Zone: {localZone.DisplayName}");
        Console.WriteLine($"Offset from UTC: {offset}");

        // Convert the current time to UTC
        DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
        Console.WriteLine($"Current time in UTC: {utcTime}");

        // Convert UTC time to a specific time zone
        TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, easternZone);
        Console.WriteLine($"Current time in Eastern Time: {easternTime}");

        // Get all available time zones
        TimeZoneInfo[] timeZones = TimeZoneInfo.GetSystemTimeZones().ToArray();
        foreach (TimeZoneInfo timeZone in timeZones)
        {
            Console.WriteLine($"Time Zone: {timeZone.DisplayName}, ID: {timeZone.Id}");
        }

        // Example: Get the date and time for 2/3/2025 at 11:15PM in a timezone 8 hours earlier than the current timezone
        DateTime dateTime = new DateTime(2025, 2, 3, 23, 15, 0);
        DateTime newDateTime = dateTime.AddHours(-8);
        Console.WriteLine($"Date and time for 2/3/2025 at 11:15PM in a timezone 8 hours earlier: {newDateTime}");

        // Display the current date and time in the UTC timezone
        DateTime utcNow = DateTime.UtcNow;
        Console.WriteLine($"Current date and time in UTC: {utcNow}");


        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Task 3: Calculate date and time values for bank customer transactions

        // Use the following code to create a BankCustomer object and BankAccount objects
        Console.WriteLine("\nCreating BankCustomer and BankAccount objects...");
        string firstName = "Niki";
        string lastName = "Demetriou";
        BankCustomer customer1 = new StandardCustomer(firstName, lastName);

        // Create accounts for customer1
        BankAccount account1 = new CheckingAccount(customer1.CustomerId, 1000.00);
        BankAccount account2 = new SavingsAccount(customer1.CustomerId, 5000.00);

        // Create transactions for specified dates and times

        // 1. Create a transaction for the current date and time. Deposit 100 into account1, description = "reimbursement"
        Transaction datedTransaction1 = new Transaction(DateOnly.FromDateTime(now), TimeOnly.FromDateTime(now), 100.00, account1.AccountNumber, account1.AccountNumber, "Deposit", "reimbursement");

        // 2. Create a transaction for yesterday at 1:15PM. Deposit 100 into account1, description = "reimbursement"
        DateTime yesterday = now.AddDays(-1);
        DateTime yesterdayAt115PM = new DateTime(yesterday.Year, yesterday.Month, yesterday.Day, 13, 15, 0);
        Transaction datedTransaction2 = new Transaction(DateOnly.FromDateTime(yesterday), TimeOnly.FromDateTime(yesterdayAt115PM), 100.00, account1.AccountNumber, account1.AccountNumber, "Deposit", "reimbursement");

        // 3. Create a transaction for last Tuesday at 1:15PM. Deposit 100 into account1, description = "reimbursement"
        DateOnly dateToday = DateOnly.FromDateTime(now);

        // get the day of the week for today
        DayOfWeek dayNameToday = dateToday.DayOfWeek;

        // get the number of days to subtract to get to last Tuesday
        int daysToLastTuesday = ((int)dayNameToday + 7 - 2) % 7;
        DateOnly lastTuesday = dateToday.AddDays(-daysToLastTuesday);

        Transaction datedTransaction3 = new Transaction(lastTuesday, new TimeOnly(13, 15), 100.00, account1.AccountNumber, account1.AccountNumber, "Deposit", "reimbursement");

        // 4. Create transactions for the first three days of December 2024. Use 1:15PM. Deposit 100 into account1, description = "reimbursement"
        DateOnly firstDayOfDecember = new DateOnly(2024, 12, 1);
        TimeOnly time115PM = new TimeOnly(13, 15);

        Transaction datedTransaction4 = new Transaction(firstDayOfDecember, time115PM, 100.00, account1.AccountNumber, account1.AccountNumber, "Deposit", "reimbursement");
        Transaction datedTransaction5 = new Transaction(firstDayOfDecember.AddDays(1), time115PM, 100.00, account1.AccountNumber, account1.AccountNumber, "Deposit", "reimbursement");
        Transaction datedTransaction6 = new Transaction(firstDayOfDecember.AddDays(2), time115PM, 100.00, account1.AccountNumber, account1.AccountNumber, "Deposit", "reimbursement");

        // Display the datedTransactions
        Console.WriteLine("\nDisplaying the dated transactions...");
        Console.WriteLine(datedTransaction1.ReturnTransaction());
        Console.WriteLine(datedTransaction2.ReturnTransaction());
        Console.WriteLine(datedTransaction3.ReturnTransaction());
        Console.WriteLine(datedTransaction4.ReturnTransaction());
        Console.WriteLine(datedTransaction5.ReturnTransaction());
        Console.WriteLine(datedTransaction6.ReturnTransaction());


        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Task 4: Use date range to simulate transactions programmatically
        Console.WriteLine("\nTask 4: Create transactions programmatically for a date range");

        // Define a date range
        DateOnly startDate = new DateOnly(2024, 12, 12);
        DateOnly endDate = new DateOnly(2025, 2, 20);

        // Generate transactions for the specified date range using the SimulateTransactions class
        Console.WriteLine($"\nGenerating transactions for the specified date range: {startDate} to {endDate}");
        Transaction[] transactions = SimulateTransactions.SimulateTransactionsDateRange(startDate, endDate, account1, account2);

        // Display the simulated transactions
        Console.WriteLine("\nDisplaying the transactions...");
        int transactionCount = 0;
        foreach (Transaction transaction in transactions)
        {
            try
            {
                Console.WriteLine(transaction.ReturnTransaction());
                transactionCount++;
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Display the number of transactions processed
        Console.WriteLine($"\nNumber of transactions processed: {transactionCount}");









        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


        // MOVE TO MODULE 2: Generate BankCustomer and BankAccount reports for monthly, quarterly, and yearly periods. Reporting makes more senses using collections.

        // Generate two years of transactions based on current date
        Console.WriteLine("\nGenerating two years of transactions based on current date...");
        DateTime currentDate = DateTime.Now;
        DateOnly startDate2Years = DateOnly.FromDateTime(currentDate.AddYears(-2));
        DateOnly endDate2Years = DateOnly.FromDateTime(currentDate);
        Transaction[] transactions2Years = SimulateTransactions.SimulateTransactionsDateRange(startDate2Years, endDate2Years, account1, account2);

        // Call the AccountReportGenerator class to generate reports
        Console.WriteLine("\nGenerating reports for BankCustomer and BankAccount objects...");

        DateOnly reportDate = DateOnly.FromDateTime(currentDate);

        AccountReportGenerator reportGenerator = new AccountReportGenerator(account1);

        reportGenerator.GenerateMonthlyReport(transactions2Years, reportDate);
        reportGenerator.GenerateCurrentMonthToDateReport(transactions2Years, reportDate);
        reportGenerator.GeneratePrevious30DayReport(transactions2Years, reportDate);
        reportGenerator.GenerateQuarterlyReport(transactions2Years, reportDate);
        reportGenerator.GeneratePreviousYearReport(transactions2Years, reportDate);
        reportGenerator.GenerateCurrentYearToDateReport(transactions2Years, reportDate);
        reportGenerator.GenerateLast365DaysReport(transactions2Years, reportDate);

        // Call the CustomerReportGenerator class to generate reports
        Console.WriteLine("\nGenerating reports for BankCustomer objects...");
        CustomerReportGenerator customerReportGenerator = new CustomerReportGenerator(customer1);
        customerReportGenerator.GenerateMonthlyReport(account1: account1, transactions1: transactions2Years, reportDate: reportDate, account2: account2);
        customerReportGenerator.GenerateCurrentMonthToDateReport();
        customerReportGenerator.GeneratePrevious30DayReport();
        customerReportGenerator.GenerateQuarterlyReport();
        customerReportGenerator.GeneratePreviousYearReport();
        customerReportGenerator.GenerateCurrentYearToDateReport();
        customerReportGenerator.GenerateLast365DaysReport();



    }

}
