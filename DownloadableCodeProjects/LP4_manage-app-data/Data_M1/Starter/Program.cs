using Data_M1;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Task 1: Review the app code - Interfaces, Models, and Services

        /*
        Task 2: Create date and time values using DateTime, DateOnly, TimeOnly, CultureInfo, Calendar, CalendarWeekRule, DayOfWeek, and TimeZoneInfo classes
            1. Get the current date and time
            2. Get the current date only
            3. Get the current time only
            4. Get the current day of the week
            5. Get the current day of the year
            6. Get the current week of the year
            7. Get the current month of the year
            8. Get the current quarter of the year
            9. Get the current year
            10. Get the number of days in the current month
            11. Get the number of days in the current year
            12. Get the number of days remaining in the current year
            13. Get the number of days remaining in the current month
            14. Get the number of days remaining in the current week
            15. Get the date for the first day of the current month
            16. Get the date for the last day of the current month
            17. Get the date for the first day of the current quarter
            18. Get the date for the last day of the current quarter
            19. Get the date for the first day of the current year
            20. Get the date for the first day of the previous month
            21. Add days to the current date
            22. Add months to the current date
            23. Add years to the current date
            24. Add minutes to the current time
            25. Add seconds to the current time
            26. Parse a date string
            27. Try to parse a date string
            28. Format a date using .ToString() method and "yyyy-MM-dd" format
            29. Use DateTimeOffset
            30. Get the current timezone
            31. Get the offset from UTC
            32. Display the timezone information
            33. Convert the current time to UTC
            34. Convert UTC time to a specific time zone
            35. Get all available time zones
            36. Get the date and time for 2/3/2025 at 11:15PM in a timezone 8 hours earlier than the current timezone
            37. Display the current date and time in the UTC timezone
        */


        // Task 3: Calculate date and time values for bank customer transactions

        // Use the following code to create a BankCustomer object and BankAccount objects
        Console.WriteLine("\nCreating BankCustomer and BankAccount objects...");
        string firstName = "Niki";
        string lastName = "Demetriou";
        BankCustomer customer1 = new StandardCustomer(firstName, lastName);

        // Create accounts for customer1
        BankAccount account1 = new CheckingAccount(customer1.CustomerId, 1000.00);
        BankAccount account2 = new SavingsAccount(customer1.CustomerId, 5000.00);

        // 1. Create a transaction for the current date and time. Deposit 100 into account1, description = "reimbursement"

        // 2. Create a transaction for yesterday at 1:15PM. Deposit 100 into account1, description = "reimbursement"

        // 3. Create a transaction for last Tuesday at 1:15PM. Deposit 100 into account1, description = "reimbursement"

        // 4. Create transactions for the first three days of December 2024. Use 1:15PM. Deposit 100 into account1, description = "reimbursement"

        // 5. Display the datedTransactions


        // Task 4: Use date ranges to simulate transactions programmatically
        Console.WriteLine("\nTask 4: Create transactions programmatically for a date range");

        // 1. Define a date range starting on December 12, 2024, and ending on February 20, 2025

        // 2. Generate transactions for the specified date range using the SimulateTransactions class
        Console.WriteLine($"\nGenerating transactions for the specified date range: {startDate} to {endDate}");

        // 3. Display the simulated transactions
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
    }
}
