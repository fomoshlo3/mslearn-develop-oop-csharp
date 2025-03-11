using Files_M2;

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Demonstrate File I/O operations in C#");

        // Step 1: Define file and directory paths
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 1: Use the Path class to construct file and directory paths. Use Path.Combine to combine a base path with specific file names.");
        
        string directoryPath = @"C:\Temp\SampleDirectory";
        string subDirectoryPath1 = Path.Combine(directoryPath, "SubDirectory1");
        string subDirectoryPath2 = Path.Combine(directoryPath, "SubDirectory2");
        string filePath = Path.Combine(directoryPath, "sample.txt");
        string appendFilePath = Path.Combine(directoryPath, "append.txt");
        string copyFilePath = Path.Combine(directoryPath, "copy.txt");
        string moveFilePath = Path.Combine(directoryPath, "moved.txt");

        Console.WriteLine($"Directory path: {directoryPath}");
        Console.WriteLine($"Text file paths ... Sample file path: {filePath}, Append file path: {appendFilePath}, Copy file path: {copyFilePath}, Move file path: {moveFilePath}");
        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();

        // Step 2: Use the Directory and File classes to create directories and files
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 2: Use the Directory and File classes to create directories and files.");
        
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            Console.WriteLine($"Created directory: {directoryPath}");
        }

        if (!Directory.Exists(subDirectoryPath1))
        {
            Directory.CreateDirectory(subDirectoryPath1);
            Console.WriteLine($"Created subdirectory: {subDirectoryPath1}");
        }

        if (!Directory.Exists(subDirectoryPath2))
        {
            Directory.CreateDirectory(subDirectoryPath2);
            Console.WriteLine($"Created subdirectory: {subDirectoryPath2}");
        }

        // Use the File class to create sample files in the subdirectories
        File.WriteAllText(Path.Combine(subDirectoryPath1, "file1.txt"), "Content of file1 in SubDirectory1");
        File.WriteAllText(Path.Combine(subDirectoryPath2, "file2.txt"), "Content of file2 in SubDirectory2");

        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();

        // Step 3: Use the Directory class to enumerate directories and files
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 3: Use the Directory class to enumerate directories and files.");
        
        foreach (var dir in Directory.GetDirectories(directoryPath))
        {
            Console.WriteLine($"Directory: {dir}");
        }
        foreach (var file in Directory.GetFiles(directoryPath))
        {
            Console.WriteLine($"File: {file}");
        }
        foreach (var subDir in Directory.GetDirectories(directoryPath))
        {
            foreach (var file in Directory.GetFiles(subDir))
            {
                Console.WriteLine($"File in {subDir}: {file}");
            }
        }
        
        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();

        // Step 4: Use the File class to write text to a file
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 4: Use the File class to write text to a file.");
        
        string label = "deposits";
        double[,] depositValues =
        {
            { 100.50, 200.75, 300.25 },
            { 150.00, 250.50, 350.75 },
            { 175.25, 275.00, 375.50 }
        };

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < depositValues.GetLength(0); i++)
        {
            sb.AppendLine($"{label}: {depositValues[i, 0]}, {depositValues[i, 1]}, {depositValues[i, 2]}");
        }

        // Split the string representation of the StringBuilder object into an array of strings 
        //  based on the environment's newline character, removing any empty entries.
        string[] lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        
        Console.WriteLine("Content to be written to the file:");
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
        File.WriteAllLines(filePath, lines);

        Console.WriteLine($"Written to file: {filePath}");
        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();

        // Step 5: Use the File class to read text from a file
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 5: Use the File class to read text from a file.");

        string[] readLines = File.ReadAllLines(filePath);
        Console.WriteLine("Content read from the file:");
        foreach (var line in readLines)
        {
            Console.WriteLine(line);
        }

        string readLabel = readLines[0].Split(':')[0];
        double[,] readDepositValues = new double[readLines.Length, 3];
        for (int i = 0; i < readLines.Length; i++)
        {
            string[] parts = readLines[i].Split(':');
            string[] values = parts[1].Split(',');
            for (int j = 0; j < values.Length; j++)
            {
                readDepositValues[i, j] = double.Parse(values[j]);
            }
        }

        Console.WriteLine($"Label: {readLabel}");
        Console.WriteLine("Deposit values:");
        for (int i = 0; i < readDepositValues.GetLength(0); i++)
        {
            Console.WriteLine($"{readDepositValues[i, 0]}, {readDepositValues[i, 1]}, {readDepositValues[i, 2]}");
        }
        
        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();

        // Step 6:Use the File class to append text to a file
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 6: Use the File class to append text to a file.");

        File.AppendAllText(appendFilePath, "Appended line\n");
        Console.WriteLine($"Appended to file: {appendFilePath}");
        
        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();

        // Step 7: Use the File class to check whether a file exists
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 7: Use the File class to check whether a file exists.");
        
        if (File.Exists(filePath))
        {
            Console.WriteLine($"File exists: {filePath}");
        }
        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();

        // Step 8: Use File to manage files - Copy, Move, and Delete a file
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 8: Copy, Move, and Delete a file.");

        // Copy a file
        File.Copy(filePath, copyFilePath, true);
        Console.WriteLine($"Copied file to: {copyFilePath}");

        // Move a file
        File.Move(copyFilePath, moveFilePath);
        Console.WriteLine($"Moved file to: {moveFilePath}");

        // Delete a file
        if (File.Exists(moveFilePath))
        {
            File.Delete(moveFilePath);
            Console.WriteLine($"Deleted file: {moveFilePath}");
        }
        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();

        // Step 9: Use the StreamWriter class to write lines of bank transaction data to a CSV file.
        //  Create a directory path named TransactionLogs in the executable's current directory.
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 9: Use the StreamWriter class to write lines of bank transaction data to a CSV file.");

        // Get the current directory of the executable program
        string currentDirectory = Directory.GetCurrentDirectory();
        Console.WriteLine($"Current directory: {currentDirectory}");

        // Use currentDirectory to create a directory path named TransactionLogs
        string transactionsDirectoryPath = Path.Combine(currentDirectory, "TransactionLogs");
        if (!Directory.Exists(transactionsDirectoryPath))
        {
            Directory.CreateDirectory(transactionsDirectoryPath);
            Console.WriteLine($"Created directory: {transactionsDirectoryPath}");
        }

        // Create a CSV file named transactions.csv in the TransactionLogs directory
        string csvFilePath = Path.Combine(transactionsDirectoryPath, "transactions.csv");
        
        // Simulate one month of transactions for customer Niki Demetriou
        string firstName = "Niki";
        string lastName = "Demetriou";
        BankCustomer customer = new BankCustomer(firstName, lastName);

        // Add CheckingAccount, SavingsAccount, and MoneyMarketAccount to the customer object using the customer.CustomerId
        customer.AddAccount(new CheckingAccount(customer, customer.CustomerId, 5000));
        customer.AddAccount(new SavingsAccount(customer, customer.CustomerId, 15000));
        customer.AddAccount(new MoneyMarketAccount(customer, customer.CustomerId, 90000));

        DateOnly startDate = new DateOnly(2025, 3, 1);
        DateOnly endDate = new DateOnly(2025, 3, 31);
        customer = SimulateDepositsWithdrawalsTransfers.SimulateActivityDateRange(startDate, endDate, customer);

        using (StreamWriter sw = new StreamWriter(csvFilePath))
        {
            sw.WriteLine("TransactionId,TransactionType,TransactionDate,TransactionTime,PriorBalance,TransactionAmount,SourceAccountNumber,TargetAccountNumber,Description");

            Console.WriteLine("Simulated transactions:");
            foreach (var account in customer.Accounts)
            {
                foreach (var transaction in account.Transactions)
                {
                    Console.WriteLine($"{transaction.TransactionId},{transaction.TransactionType},{transaction.TransactionDate},{transaction.TransactionTime},{transaction.PriorBalance},{transaction.TransactionAmount},{transaction.SourceAccountNumber},{transaction.TargetAccountNumber},{transaction.Description}");
                    sw.WriteLine($"{transaction.TransactionId},{transaction.TransactionType},{transaction.TransactionDate},{transaction.TransactionTime},{transaction.PriorBalance},{transaction.TransactionAmount},{transaction.SourceAccountNumber},{transaction.TargetAccountNumber},{transaction.Description}");
                }
            }
        }

        Console.WriteLine($"Written transaction data to CSV file: {csvFilePath}");
        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();

        // Step 10: Use the StreamReader class to read bank transaction lines from a CSV file
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 10: Use the StreamReader class to read bank transaction lines from a CSV file.");

        using (StreamReader sr = new StreamReader(csvFilePath))
        {
            string headerLine = sr.ReadLine(); // Read the header line
            Console.WriteLine("Read transaction data from CSV file:");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        
        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();

        // Step 11: Use the FileStream class to perform low-level file I/O operations
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 11: Use the FileStream class to perform low-level file I/O operations.");

        string fileStreamPath = Path.Combine(directoryPath, "filestream.txt");

        // Prepare transaction data from customer accounts
        sb = new StringBuilder();
        sb.AppendLine("TransactionId,TransactionType,TransactionDate,TransactionTime,PriorBalance,TransactionAmount,SourceAccountNumber,TargetAccountNumber,Description");

        foreach (var account in customer.Accounts)
        {
            foreach (var transaction in account.Transactions)
            {
                // Append transaction data to the StringBuilder object
                sb.AppendLine($"{transaction.TransactionId},{transaction.TransactionType},{transaction.TransactionDate},{transaction.TransactionTime},{transaction.PriorBalance},{transaction.TransactionAmount},{transaction.SourceAccountNumber},{transaction.TargetAccountNumber},{transaction.Description}");
            }
        }

        // Write transaction data to file using FileStream
        using (FileStream fs = new FileStream(fileStreamPath, FileMode.Create, FileAccess.Write))
        {
            // Convert the StringBuilder object to a byte array and write the byte array to the file
            byte[] info = new UTF8Encoding(true).GetBytes(sb.ToString());
            
            // Use the Write method to write the byte array to the file
            fs.Write(info, 0, info.Length);
            Console.WriteLine($"File length after write: {fs.Length} bytes");
            
            // Use the Flush method to ensure all data is written to the file
            fs.Flush(); 

            Console.WriteLine("Data flushed to the file.");
        }

        Console.WriteLine($"Wrote transaction data to file using FileStream: {fileStreamPath}");

        // Read transaction data from file using FileStream
        using (FileStream fs = new FileStream(fileStreamPath, FileMode.Open, FileAccess.Read))
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            int bytesRead;

            Console.WriteLine("Use FileStream to read transaction data from file:");
            while ((bytesRead = fs.Read(b, 0, b.Length)) > 0)
            {
                Console.WriteLine(temp.GetString(b, 0, bytesRead));
            }

            Console.WriteLine($"File length: {fs.Length} bytes");
            Console.WriteLine($"Current position: {fs.Position} bytes");

            // Use the Seek method to move to the beginning of the file
            fs.Seek(0, SeekOrigin.Begin);
            Console.WriteLine($"Position after seek: {fs.Position} bytes");

            // Use the FileStream.Read method to read the first 100 bytes
            bytesRead = fs.Read(b, 0, 100);
            Console.WriteLine($"Read first 100 bytes: {temp.GetString(b, 0, bytesRead)}");
        }
        
        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();

        // Step 13: Use the BinaryWriter and BinaryReader classes to create and read binary files
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 13: Use the BinaryWriter and BinaryReader classes to create and read binary files.");

        string binaryFilePath = Path.Combine(directoryPath, "binary.dat");
        using (BinaryWriter writer = new BinaryWriter(File.Open(binaryFilePath, FileMode.Create)))
        {
            writer.Write(1.25);
            writer.Write("Hello");
            writer.Write(true);
        }
        Console.WriteLine($"Written binary data to: {binaryFilePath}");

        using (BinaryReader reader = new BinaryReader(File.Open(binaryFilePath, FileMode.Open)))
        {
            double a = reader.ReadDouble();
            string b = reader.ReadString();
            bool c = reader.ReadBoolean();
            Console.WriteLine($"Read binary data: {a}, {b}, {c}");
        }
        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine();

        // Step 16: Clean up by deleting all the files and directories
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Console.WriteLine("\nStep 16: Clean up by deleting all the files and directories.");
        
        Directory.Delete(directoryPath, true);
        Console.WriteLine($"Deleted directory: {directoryPath}");
        
        Directory.Delete(transactionsDirectoryPath, true);
        Console.WriteLine($"Deleted directory: {transactionsDirectoryPath}");

        Console.WriteLine("\n\nPress Enter to exit...");
        Console.ReadLine();
    }
}