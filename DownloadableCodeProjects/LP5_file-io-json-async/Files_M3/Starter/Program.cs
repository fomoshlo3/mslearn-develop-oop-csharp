using Files_M2;

using System;
using System.IO;
using System.Text;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Console.WriteLine("Demonstrate JSON file storage and retrieval using BankCustomer, BankAccount, and Transaction classes");

        // Create a Bank object
        Bank bank = new Bank();

        // Create a bank customer named Niki Demetriou
        string firstName = "Niki";
        string lastName = "Demetriou";
        BankCustomer bankCustomer = new BankCustomer(firstName, lastName);

        // Add Checking, Savings, and MoneyMarket accounts to bankCustomer
        bankCustomer.AddAccount(new CheckingAccount(bankCustomer, bankCustomer.CustomerId, 5000));
        bankCustomer.AddAccount(new SavingsAccount(bankCustomer, bankCustomer.CustomerId, 15000));
        bankCustomer.AddAccount(new MoneyMarketAccount(bankCustomer, bankCustomer.CustomerId, 90000));

        // Add the bank customer to the bank object
        bank.AddCustomer(bankCustomer);

        // Simulate one month of transactions for customer Niki Demetriou
        DateOnly startDate = new DateOnly(2025, 2, 1);
        DateOnly endDate = new DateOnly(2025, 2, 28);
        bankCustomer = SimulateDepositsWithdrawalsTransfers.SimulateActivityDateRange(startDate, endDate, bankCustomer);

        // Get the current directory of the executable program
        string currentDirectory = Directory.GetCurrentDirectory();

        // Use currentDirectory to create a directory path named BankLogs
        string bankLogsDirectoryPath = Path.Combine(currentDirectory, "BankLogs");
        if (!Directory.Exists(bankLogsDirectoryPath))
        {
            Directory.CreateDirectory(bankLogsDirectoryPath);
            //Console.WriteLine($"Created directory: {bankLogsDirectoryPath}");
        }

        // Step 1: Use JsonSerializer.Serialize to serialize a transaction object and display the JSON string
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 1: Use JsonSerializer.Serialize to serialize a transaction object and display the JSON string.");

        // Get the first transaction from the first account of the bank customer
        Transaction singleTransaction = bankCustomer.Accounts[0].Transactions.ElementAt(0);

        // Serialize the transaction object using JsonSerializer
        string transactionJson = JsonSerializer.Serialize(singleTransaction);

        // Display the JSON string
        Console.WriteLine($"\nJSON string: {transactionJson}");

        // Console.WriteLine("\n\nPress Enter to continue...");
        // Console.ReadLine();

        // Step 2: Use JsonSerializer.Deserialize to deserialize a json string and access the Transaction.
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 2: Use JsonSerializer.Deserialize to deserialize a json string and access the Transaction.");

        /*

        Deserialize Error: 
        
        When deserializing the JSON string to a Transaction object, a runtime error occurs due to the structure of 
        the Transaction class.

        Add the following code and then run the program to see the runtime error that occurs during deserialization:

        // Deserialize the JSON string using JsonSerializer.Deserialize
        Transaction deserializedTransaction = JsonSerializer.Deserialize<Transaction>(transactionJson);
        Console.WriteLine($"\nDeserialized transaction object: {deserializedTransaction.ReturnTransaction()}");

        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();


        Explanation and Fix:

        A runtime error occurs during deserialization of the Transaction object because the Transaction class 
        has private fields and read-only properties without public setters. The JsonSerializer in .NET requires
        public setters and a parameterless constructor to properly deserialize objects.

        The Transaction class in the Models folder must be updated as follows:

        1. Remove readonly from the fields
        2. Add setters to the properties
        3. Create a parameterless constructor.

        After updating the Transaction class, run the application again to see the deserialization process work correctly.

        */

        // Deserialize the JSON string using JsonSerializer.Deserialize
        Transaction? deserializedTransaction = JsonSerializer.Deserialize<Transaction>(transactionJson);

        if (deserializedTransaction == null)
        {
            Console.WriteLine("Deserialization failed. Check the Transaction class for public setters and a parameterless constructor.");
        }
        else
        {
            // Use the Transaction.ReturnTransaction method to display transaction information
            Console.WriteLine($"\nDeserialized transaction object: {deserializedTransaction.ReturnTransaction()}");
        }

        // Console.WriteLine("\n\nPress Enter to continue...");
        // Console.ReadLine();

        // Step 3: Serialize and store the transactions for a BankAccount object
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 3: Serialize and store the transactions for a BankAccount object.");

        // Serialize account transactions using JsonSerializer.Serialize
        string transactionsJson = JsonSerializer.Serialize(bankCustomer.Accounts[0].Transactions);
        Console.WriteLine($"\nbankCustomer.Accounts[0].Transactions serialized to JSON: \n{transactionsJson}");

        // Construct a file path where the serialized transactions (JSON string) can be stored
        string transactionsJsonFilePath = Path.Combine(bankLogsDirectoryPath, "Transactions", bankCustomer.Accounts[0].AccountNumber.ToString() + "-transactions" + ".json");

        // Create the parent directory for the serialized transactions file
        var directoryPath = Path.GetDirectoryName(transactionsJsonFilePath);
        if (directoryPath != null && !Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Store the serialized JSON string to a file
        File.WriteAllText(transactionsJsonFilePath, transactionsJson);
        Console.WriteLine($"\nSerialized transactions saved to: {transactionsJsonFilePath}");

        // Console.WriteLine("\n\nPress Enter to continue...");
        // Console.ReadLine();

        // Step 4: Read the transactions JSON file, deserialize into a Transactions collection, and display transactions in a loop
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 4: Read the transactions JSON file, deserialize into a Transactions collection, and display transactions in a loop.");

        // Use File.ReadAllText to read the JSON file and assign the text contents to a string.
        string transactionsJsonFromFile = File.ReadAllText(transactionsJsonFilePath);

        // Deserialize the JSON string using JsonSerializer.Deserialize
        var transactionsJsonDeserialized = JsonSerializer.Deserialize<IEnumerable<Transaction>>(transactionsJsonFromFile);

        // Loop through the deserialized transactions and display each transaction
        if (transactionsJsonDeserialized == null)
        {
            Console.WriteLine("Deserialization failed. Check the Transaction class for public setters and a parameterless constructor.");
        }
        else
        {
            Console.WriteLine("\nDeserialized transactions:");
            foreach (var transaction in transactionsJsonDeserialized)
            {
                Console.WriteLine(transaction.ReturnTransaction());
            }
        }

        // Console.WriteLine("\n\nPress Enter to continue...");
        // Console.ReadLine();

        // Step 5: Serialize and store a BankAccount object using JsonSerializer with JsonSerializerOptions
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 5: Serialize and store a BankAccount object using JsonSerializer.");

        // Configure JsonSerializerOptions
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            MaxDepth = 64, // Increase the maximum depth if needed
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve // Handle circular references
        };

        //Serialize the CheckingAccount object using JsonSerializer.Serialize with options
        string accountJson = JsonSerializer.Serialize(bankCustomer.Accounts[0], options);
        Console.WriteLine(accountJson);

        // Create a file path for the CheckingAccount object
        string accountFilePath = Path.Combine(bankLogsDirectoryPath, "Account", bankCustomer.Accounts[0].AccountNumber + ".json");

        // Create the parent directory for the serialized account file
        var accountDirectoryPath = Path.GetDirectoryName(accountFilePath);
        if (accountDirectoryPath != null && !Directory.Exists(accountDirectoryPath))
        {
            Directory.CreateDirectory(accountDirectoryPath);
        }

        // Save the JSON to a file
        File.WriteAllText(accountFilePath, accountJson);
        Console.WriteLine($"Serialized account saved to: {accountFilePath}");

        // Console.WriteLine("\n\nPress Enter to continue...");
        // Console.ReadLine();

        // Step 6: Read the serialized account file, deserialize into a BankAccount object, and then access bankAccount members
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /*

        Deserialize Error: 
        
        When deserializing the JSON string to a BankAccount object, a runtime error occurs due to the structure of
        the BankAccount class:

        Exception has occurred: CLR/System.NotSupportedException. An unhandled exception of type 
        'System.NotSupportedException' occurred in System.Text.Json.dll: Deserialization of types without a 
        parameterless constructor, a singular parameterized constructor, or a parameterized constructor 
        annotated with 'JsonConstructorAttribute' is not supported.

        The BankAccount class is designed with restricted access policies for properties and fields. It also uses 
        constructors that require specific parameters, so a parameterless constructor may not work. Direct serialization
        and deserialization of a BankAccount object is not the best option. This is where Data Transfer Objects (DTOs)
        come into play.
        
        Data Transfer Objects (DTOs) enable you to create a separate object with public properties and a parameterless
        constructor. You can then map the properties from the original object to the DTO object and serialize the DTO object
        instead. This approach allows you to serialize and deserialize objects without violating the encapsulation of the
        original object.
        
        */

        Console.WriteLine("\nStep 6: Read the serialized account file, deserialize into a BankAccount object, and then access bankAccount members.");

        // read the JSON from the file
        string accountJsonFromFile = File.ReadAllText(accountFilePath);

        // Deserialize the JSON string using JsonSerializer.Deserialize with options
        try
        {
            BankAccount? deserializedAccount = JsonSerializer.Deserialize<BankAccount>(accountJsonFromFile, options);

            // Demonstrate the deserialized BankAccount object
            if (deserializedAccount == null)
            {
                Console.WriteLine("Deserialization failed. Check the BankAccount class for public setters and a parameterless constructor.");
            }
            else
            {
                Console.WriteLine($"\nDeserialized BankAccount object: {deserializedAccount.DisplayAccountInfo()}");
                Console.WriteLine($"Transactions for Account Number: {deserializedAccount.AccountNumber}");

                foreach (var transaction in deserializedAccount.Transactions)
                {
                    Console.WriteLine(transaction.ReturnTransaction());
                }
            }
        }
        catch (Exception ex)
        {
            string displayMessage = "Exception has occurred: " + ex.Message.Split('.')[0] + ".";
            displayMessage += "\n\nConsider using Data Transfer Objects (DTOs) for serializing and deserializing complex and nested objects.";
            Console.WriteLine(displayMessage);
        }

        // Console.WriteLine("\n\nPress Enter to continue...");
        // Console.ReadLine();

        // Step 7: Use a Data Transfer Object to store bank account info, and store account transactions separately
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 7: Use a Data Transfer Object to store bank account info, and store account transactions separately.");

        /*

        Create a new class named BankAccountDTO in the Services folder. This class will be used as a Data Transfer Object (DTO) 
        to store account information in a format that can be serialized and deserialized without violating the encapsulation of 
        the BankAccount class.

        */

        // Create directory paths for Account and Transaction files
        string accountsDirectoryPath = Path.Combine(bankLogsDirectoryPath, "Accounts");
        Directory.CreateDirectory(accountsDirectoryPath);

        string transactionsDirectory = Path.Combine(bankLogsDirectoryPath, "Transactions");
        Directory.CreateDirectory(transactionsDirectory);

        BankAccount customerAccount1 = (BankAccount)bankCustomer.Accounts[0];

        // Create a jsonAccountDTOFilePath for the BankAccount object
        string jsonAccountDTOFilePath = Path.Combine(accountsDirectoryPath, customerAccount1.AccountNumber.ToString() + ".json");

        // Create a bankAccountDTO object from the BankAccount object and serialize it as JSON
        BankAccountDTO bankAccountDTO = BankAccountDTO.MapToDTO((BankAccount)customerAccount1);
        string jsonAccountDTO = JsonSerializer.Serialize(bankAccountDTO, options);

        // Save the serialized jsonAccountDTO to a file in the Accounts directory using the AccountNumber value as the filename  (.json)
        File.WriteAllText(jsonAccountDTOFilePath, jsonAccountDTO);
        Console.WriteLine($"Serialized account saved to: {jsonAccountDTOFilePath}");

        // For each account, serialize the Transactions collection, and save the JSON to a file in the Transactions directory
        string jsonTransactions = JsonSerializer.Serialize(customerAccount1.Transactions);

        // Create a jsonTransactionsFilePath for the Transactions collection
        string jsonTransactionsFilePath = Path.Combine(transactionsDirectory, customerAccount1.AccountNumber.ToString() + "T" + ".json");

        // Save the serialized jsonTransactionDTO to a file in the Transactions directory using the TransactionId value as the filename  (.json)
        File.WriteAllText(jsonTransactionsFilePath, jsonTransactions);
        Console.WriteLine($"Serialized account transactions saved to: {jsonTransactionsFilePath}");

        // Console.WriteLine("\n\nPress Enter to continue...");
        // Console.ReadLine();

        // Step 8: Read JSON files and use Data Transfer Objects to construct an account with associated transactions
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 8: Read JSON files and use Data Transfer Objects to construct an account with associated transactions.");

        // Load the BankAccountDTO info from the JSON file
        jsonAccountDTO = File.ReadAllText(jsonAccountDTOFilePath);

        // Deserialize the JSON string into a BankAccountDTO object using JsonSerializer.Deserialize
        var accountDTO = JsonSerializer.Deserialize<BankAccountDTO>(jsonAccountDTO, options);

        if (accountDTO == null)
        {
            Console.WriteLine("Deserialization failed. Check the BankAccountDTO class for public setters and a parameterless constructor.");
        }
        else
        {
            // create a bank account using the recovered data
            var recoveredBankAccount = new BankAccount(bankCustomer, bankCustomer.CustomerId, accountDTO.Balance, accountDTO.AccountType);

            // load the transactions file into a JSON formatted string
            jsonTransactions = File.ReadAllText(jsonTransactionsFilePath);

            // deserialize the JSON string into a collection of Transaction objects
            var transactions = JsonSerializer.Deserialize<IEnumerable<Transaction>>(jsonTransactions, options);

            if (transactions == null)
            {
                Console.WriteLine("Deserialization failed. Check the Transaction class for public setters and a parameterless constructor.");
            }
            else
            {
                // add the transactions to the recovered account
                foreach (var transaction in transactions)
                {
                    recoveredBankAccount.AddTransaction(transaction);
                }

                // display the recovered account information
                Console.WriteLine($"\nRecovered BankAccount object: {recoveredBankAccount.DisplayAccountInfo()}");
                Console.WriteLine($"Transactions for Account Number: {recoveredBankAccount.AccountNumber}\n");

                foreach (var transaction in recoveredBankAccount.Transactions)
                {
                    Console.WriteLine(transaction.ReturnTransaction());
                }
            }
        }

        // Console.WriteLine("\n\nPress Enter to continue...");
        // Console.ReadLine();

        // Step 9: Use a helper class and Data Transfer Objects to store and retrieve accounts
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 9: Create helper classes that store and retrieve accounts using the DTOs.");

        /*

        Create a new class named JsonStorage in the Services folder. This class will contain methods to save BankAccount and BankAccount
        objects to JSON files using the DTO classes. When saving a BankAccount, the associated transactions will also be saved to a separate
        JSON file.

        Create a new class named JsonRetrieval in the Services folder. This class will contain methods to load BankAccount and BankAccount
        objects from JSON files using the DTO classes. When loading a BankAccount, the associated transactions will also be loaded from a
        separate JSON file.

        */

        // Get the customer's checking account
        BankAccount checkingAccount = (CheckingAccount)bankCustomer.Accounts[0];

        // Use the JsonStorage.SaveBankAccount method to save account info to JSON files (an account file using BankAccountDTO and a separate transactions file)
        JsonStorage.SaveBankAccount(checkingAccount, bankLogsDirectoryPath);

        // Construct the file path for the checking account
        //string retrieveAccountFilePath = Path.Combine(bankLogsDirectoryPath, "Accounts", checkingAccount.AccountNumber + ".json");
        string retrieveAccountFilePath = JsonRetrieval.ReturnAccountFilePath(bankLogsDirectoryPath, checkingAccount.AccountNumber);

        // Use the JsonStorage.LoadBankAccount method to load account info from JSON files (an account file using BankAccountDTO and a separate transactions file)
        BankAccount retrievedAccount = JsonRetrieval.LoadBankAccount(retrieveAccountFilePath, transactionsDirectory, bankCustomer);

        // Display the retrieved account information
        Console.WriteLine($"The owner of the retrieved account is: {retrievedAccount.Owner.ReturnFullName()}");
        Console.WriteLine($"{retrievedAccount.Owner.ReturnFullName()} has the following {retrievedAccount.Owner.Accounts.Count} accounts:");
        foreach (var account in retrievedAccount.Owner.Accounts)
        {
            Console.WriteLine($"Account number: {account.AccountNumber} is a {account.AccountType} account.");
        }

        Console.WriteLine($"\nRetrieved {retrievedAccount.AccountType} account info: {retrievedAccount.DisplayAccountInfo()}");

        Console.WriteLine($"The following transactions were retrieved for {retrievedAccount.Owner.ReturnFullName()}'s {retrievedAccount.AccountType} account: \n");

        foreach (var transaction in retrievedAccount.Transactions)
        {
            Console.WriteLine(transaction.ReturnTransaction());
        }

        // Console.WriteLine("\n\nPress Enter to continue...");
        // Console.ReadLine();

        // Step 10: Use Data Transfer Objects to store and retrieve BankCustomer objects
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 10: Use Data Transfer Objects to store and retrieve BankCustomer objects.");

        /*


        NOTE: Add InterestRate to the IBankAccount interface


        Create a new class named BankCustomerDTO in the Services folder. This class will be used as a Data Transfer Object (DTO) 
        to store customer information in a format that can be serialized and deserialized without violating the encapsulation of 
        the BankCustomer class.

        Update the JsonStorage with methods to save BankCustomer objects to JSON files using the DTO classes. When saving a BankCustomer,
        the associated accounts will also be saved to separate JSON files.

        Update the JsonRetrieval class to load BankCustomer objects from JSON files using the DTO classes. When loading a BankCustomer,
        the associated accounts will also be loaded from separate JSON files.

        */

        string customersDirectoryPath = Path.Combine(bankLogsDirectoryPath, "Customers");
        Directory.CreateDirectory(customersDirectoryPath);

        JsonStorage.SaveBankCustomer(bankCustomer, bankLogsDirectoryPath);
        Console.WriteLine($"Bank customer information for {bankCustomer.ReturnFullName()} saved to JSON file.");

        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();

        // construct the customer file path (customersDirectoryPath + bankCustomer.CustomerId + ".json")
        string customerFilePath = Path.Combine(customersDirectoryPath, bankCustomer.CustomerId + ".json");

        // public static BankCustomer LoadBankCustomer(Bank bank, string filePath, string accountsDirectoryPath, string transactionsDirectoryPath)
        BankCustomer retrievedCustomer = JsonRetrieval.LoadBankCustomer(bank, customerFilePath, accountsDirectoryPath, transactionsDirectory);

        Console.WriteLine($"\nRetrieved customer information for {retrievedCustomer.ReturnFullName()}:");
        Console.WriteLine($"Customer ID: {retrievedCustomer.CustomerId}");
        Console.WriteLine($"First Name: {retrievedCustomer.FirstName}");
        Console.WriteLine($"Last Name: {retrievedCustomer.LastName}");
        Console.WriteLine($"Number of accounts: {retrievedCustomer.Accounts.Count}");

        foreach (var account in retrievedCustomer.Accounts)
        {
            Console.WriteLine($"\nAccount number: {account.AccountNumber} is a {account.AccountType} account.");
            Console.WriteLine($" - Balance: {account.Balance}");
            Console.WriteLine($" - Interest Rate: {account.InterestRate}");
            Console.WriteLine($" - Transactions:");
            foreach (var transaction in account.Transactions)
            {
                Console.WriteLine($"    {transaction.ReturnTransaction()}");
            }
        }

        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();




        /* 

        Generate 24 months of account transactions for all approved customers and save the data to JSON files.
        
        Console.WriteLine("\n\nPress Enter to generate customer logs...");
        Console.ReadLine();
        CreateDataLogs.GenerateCustomerData();

        Console.WriteLine("\n\nPress Enter to read customer logs...");
        Console.ReadLine();
        LoadCustomerLogs.ReadCustomerData(bank);

        Console.WriteLine("\n\nPress Enter to display customer logs...");
        Console.ReadLine();
        foreach (var customer in bank.GetAllCustomers())
        {
            Console.WriteLine($"\nCustomer: {customer.ReturnFullName()}");
            foreach (var account in customer.Accounts)
            {
                Console.WriteLine($"\nAccount Number: {account.AccountNumber}");
                Console.WriteLine($"Account Type: {account.AccountType}");
                Console.WriteLine($"Balance: {account.Balance}");
                Console.WriteLine($"Interest Rate: {account.InterestRate}");
                Console.WriteLine($"Transactions:");
                foreach (var transaction in account.Transactions)
                {
                    Console.WriteLine(transaction.ReturnTransaction());
                }
            }
        }

        */

        // Step ??: Clean up by deleting all the files and directories
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 16: Clean up by deleting all the files and directories.");

        Console.WriteLine("\n\nPress Enter to delete BankLogs and exit the app...");
        Console.ReadLine();

        Directory.Delete(bankLogsDirectoryPath, true);
    }
}
