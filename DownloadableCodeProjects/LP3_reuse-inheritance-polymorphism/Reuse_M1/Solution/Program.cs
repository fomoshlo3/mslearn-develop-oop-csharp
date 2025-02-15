using Reuse_M1;
using System.Globalization;

void DisplayCustomerInfo(BankCustomer customer, params BankAccount[] accounts)
{
    Console.WriteLine(customer.DisplayCustomerInfo());
    foreach (var account in accounts)
    {
        Console.WriteLine(account.DisplayAccountInfo());
    }
}

void DisplayTableHeader()
{
    Console.WriteLine("+-----------------------+-------------+-------------------+-------------------+-------------------+--------+-------------------+");
    Console.WriteLine("| Account Type          | Customer ID | Starting Balance  | Transaction Type  | Transaction Amount| Fees   | Ending Balance    |");
    Console.WriteLine("+-----------------------+-------------+-------------------+-------------------+-------------------+--------+-------------------+");
}

void DisplayTableRow(string accountType, string customerId, double startingBalance, string transactionType, double transactionAmount, double fees, double endingBalance)
{
    Console.WriteLine($"| {accountType,-21} | {customerId,-11} | {startingBalance,17:C} | {transactionType,-17} | {transactionAmount,17:C} | {fees,6:C} | {endingBalance,17:C} |");
    Console.WriteLine("+-----------------------+-------------+-------------------+-------------------+-------------------+--------+-------------------+");
}

void DemonstrateTransfer(BankAccount fromAccount, BankAccount toAccount, double amount)
{
    double startingBalanceFrom = fromAccount.Balance;
    double startingBalanceTo = toAccount.Balance;
    double fees = 0;

    Console.WriteLine($"Transferring ${amount} from {fromAccount.AccountType} to {toAccount.AccountType}...");
    if (fromAccount.Transfer(toAccount, amount))
    {
        Console.WriteLine("Transfer successful.");
    }
    else
    {
        Console.WriteLine("Transfer failed.");
    }

    DisplayTableRow(fromAccount.AccountType, fromAccount.CustomerId, startingBalanceFrom, "Transfer Out", amount, fees, fromAccount.Balance);
    DisplayTableRow(toAccount.AccountType, toAccount.CustomerId, startingBalanceTo, "Transfer In", amount, fees, toAccount.Balance);
}

void DemonstrateApplyInterest(BankAccount account, double years)
{
    double startingBalance = account.Balance;
    double fees = 0;

    Console.WriteLine($"Applying interest for {years} year(s) for {account.AccountType}...");
    account.ApplyInterest(years);

    DisplayTableRow(account.AccountType, account.CustomerId, startingBalance, "Apply Interest", 0, fees, account.Balance);
}

void DemonstrateApplyRefund(BankAccount account, double refund)
{
    double startingBalance = account.Balance;
    double fees = 0;

    Console.WriteLine($"Applying refund of ${refund} for {account.AccountType}...");
    account.ApplyRefund(refund);

    DisplayTableRow(account.AccountType, account.CustomerId, startingBalance, "Apply Refund", refund, fees, account.Balance);
}

void DemonstrateIssueCashiersCheck(BankAccount account, double amount)
{
    double startingBalance = account.Balance;
    double fees = 0;

    Console.WriteLine($"Issuing cashier's check for ${amount} for {account.AccountType}...");
    if (account.IssueCashiersCheck(amount))
    {
        Console.WriteLine("Cashier's check issued.");
    }
    else
    {
        Console.WriteLine("Insufficient funds to issue cashier's check.");
    }

    DisplayTableRow(account.AccountType, account.CustomerId, startingBalance, "Issue Cashier's Check", amount, fees, account.Balance);
}

void DemonstrateWithdraw(BankAccount account, double amount)
{
    double startingBalance = account.Balance;
    double fees = 0;

    Console.WriteLine($"Withdrawing ${amount} from {account.AccountType}...");
    if (account.Withdraw(amount))
    {
        Console.WriteLine("Withdrawal successful.");
    }
    else
    {
        Console.WriteLine("Withdrawal failed.");
    }

    DisplayTableRow(account.AccountType, account.CustomerId, startingBalance, "Withdraw", amount, fees, account.Balance);
}

void DemonstrateDeposit(BankAccount account, double amount)
{
    double startingBalance = account.Balance;
    double fees = 0;

    Console.WriteLine($"Depositing ${amount} into {account.AccountType}...");
    account.Deposit(amount);

    DisplayTableRow(account.AccountType, account.CustomerId, startingBalance, "Deposit", amount, fees, account.Balance);
}

void DemonstrateResetWithdrawalLimit(SavingsAccount account)
{
    double startingBalance = account.Balance;
    double fees = 0;

    Console.WriteLine($"Resetting withdrawal limit for {account.AccountType}...");
    account.ResetWithdrawalLimit();

    DisplayTableRow(account.AccountType, account.CustomerId, startingBalance, "Reset Withdrawal Limit", 0, fees, account.Balance);
}

// Create three instances of the BankCustomer class and use the customers to create various combinations of account types for each customer
Console.WriteLine("Creating BankCustomer objects...");
BankCustomer customer1 = new BankCustomer("Tim", "Shao");
BankCustomer customer2 = new BankCustomer("Lisa", "Shao");
BankCustomer customer3 = new BankCustomer("Sandy", "Zoeng");

// Create various combinations of account types for each customer
CheckingAccount checking1 = new CheckingAccount(customer1.CustomerId, 500);
SavingsAccount savings1 = new SavingsAccount(customer1.CustomerId, 1000);
MoneyMarketAccount moneyMarket1 = new MoneyMarketAccount(customer1.CustomerId, 2000);
CertificateOfDeposit cd1 = new CertificateOfDeposit(customer1.CustomerId, 5000);

CheckingAccount checking2 = new CheckingAccount(customer2.CustomerId, 1000);
SavingsAccount savings2 = new SavingsAccount(customer2.CustomerId, 2000);
MoneyMarketAccount moneyMarket2 = new MoneyMarketAccount(customer2.CustomerId, 3000);
CertificateOfDeposit cd2 = new CertificateOfDeposit(customer2.CustomerId, 4000);

CheckingAccount checking3 = new CheckingAccount(customer3.CustomerId, 1500);
SavingsAccount savings3 = new SavingsAccount(customer3.CustomerId, 2500);
MoneyMarketAccount moneyMarket3 = new MoneyMarketAccount(customer3.CustomerId, 3500);
CertificateOfDeposit cd3 = new CertificateOfDeposit(customer3.CustomerId, 4500);

// Display the account information for each customer
Console.WriteLine("Customer 1:");
DisplayCustomerInfo(customer1, checking1, savings1, moneyMarket1, cd1);

Console.WriteLine("Customer 2:");
DisplayCustomerInfo(customer2, checking2, savings2, moneyMarket2, cd2);

Console.WriteLine("Customer 3:");
DisplayCustomerInfo(customer3, checking3, savings3, moneyMarket3, cd3);

// Demonstrate various operations
Console.WriteLine("\nDemonstrating various operations:");
DisplayTableHeader();

void DemonstrateOperations(BankAccount account)
{
    DemonstrateDeposit(account, 100);
    DemonstrateWithdraw(account, 100);
    DemonstrateApplyInterest(account, 1);
    DemonstrateApplyRefund(account, 50);
    DemonstrateIssueCashiersCheck(account, 100);
}

Console.WriteLine("\nChecking Account Operations:");
DemonstrateOperations(checking1);
DemonstrateOperations(checking2);
DemonstrateOperations(checking3);

Console.WriteLine("\nSavings Account Operations:");
DemonstrateOperations(savings1);
DemonstrateOperations(savings2);
DemonstrateOperations(savings3);
DemonstrateResetWithdrawalLimit(savings1);
DemonstrateResetWithdrawalLimit(savings2);
DemonstrateResetWithdrawalLimit(savings3);

Console.WriteLine("\nMoney Market Account Operations:");
DemonstrateOperations(moneyMarket1);
DemonstrateOperations(moneyMarket2);
DemonstrateOperations(moneyMarket3);

Console.WriteLine("\nCertificate of Deposit Account Operations:");
DemonstrateOperations(cd1);
DemonstrateOperations(cd2);
DemonstrateOperations(cd3);

// Demonstrate transfers
Console.WriteLine("\nDemonstrating Transfers:");
DemonstrateTransfer(savings1, checking1, 100);
DemonstrateTransfer(checking2, savings2, 100);
DemonstrateTransfer(moneyMarket3, cd3, 100);