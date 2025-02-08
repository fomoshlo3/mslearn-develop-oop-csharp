---
lab:
    title: 'Exercise - Update a class with properties and methods'
    description: 'Learn how to implement class properties using property accessors and access modifiers, and how to implement methods by adding methods to a class and by developing extension methods for existing classes.'
---


# Update a class with properties and methods

Classes use properties and methods to encapsulate data and behavior. Properties define the data that a class contains, and methods define the behavior that the class can perform.

In this exercise, you update an existing code project by developing properties and methods.

This exercise takes approximately **35** minutes to complete.

## Before you start

Before you can start this exercise, you will need to:

1. Ensure that you have the latest LTS version of the .NET SDK installed on your computer. You can download the latest version of the .NET SDK from the following URL: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code from the following URL: [https://code.visualstudio.com/](https://code.visualstudio.com/)
1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see [https://learn.microsoft.com/en-us/training/modules/install-configure-visual-studio-code/](https://learn.microsoft.com/en-us/training/modules/install-configure-visual-studio-code/)

## Exercise scenario

Suppose you're helping a non-profit company with a software project. You've decided to sharpen your object-oriented programming skills by creating a simple banking app. You have an initial version of the app that includes the following files:

- BankCustomer.cs: The BankCustomer class includes fields for first name, last name, and customer ID. The class also includes constructors that initialize the fields.
- BankAccount.cs: The BankAccount class includes fields for account number, balance, interest rate, account type, and customer ID. The class also includes constructors that initialize the fields.
- Program.cs: The Program.cs file includes code that creates instances of the BankCustomer and BankAccount classes and demonstrates how each class is used.

This exercise includes the following tasks:

1. Review the current version of your banking app
1. Create properties for the BankCustomer class
1. Create automatically implemented properties for the BankAccount class
1. Create read-only properties for the BankAccount class
1. Create methods for the BankCustomer and BankAccount classes
1. Create extension methods for the BankCustomer and BankAccount classes
1. Update the Program.cs file to demonstrate the updated classes, properties, and methods

## Review the current version of your banking app

In this task, you download the existing version of your banking app and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Implement classes, properties, and methods - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP1SampleApps.zip)

1. Extract the contents of the LP1SampleApps.zip file to a folder location on your computer.

1. Expand the LP1SampleApps folder, and then open the `Classes_M2` folder.

    The Classes_M2 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

    You should see the following project files:

    - BankAccount.cs
    - BankCustomer.cs
    - Classes_M2.csproj
    - Program.cs

1. Open the BankCustomer.cs file.

1. Take a minute to review the BankCustomer class.

    ```csharp

    using System;
    
    namespace Classes_M2;
    
    public class BankCustomer
    {
        private static int nextCustomerId;
        public string fName = "Tim";
        public string lName = "Shao";
        public readonly string customerId;
    
        static BankCustomer()
        {
            Random random = new Random();
            nextCustomerId = random.Next(10000000, 20000000);
        }
    
        public BankCustomer(string firstName, string lastName)
        {
            fName = firstName;
            lName = lastName;
            this.customerId = (nextCustomerId++).ToString("D10");
        }
        
    }

    ```

    The `BankCustomer` class includes fields for `fname` (first name), `lName` (last name), `customerId` (customer ID), and a static field `nextCustomerId`. The `nextCustomerId` field is used to generate a unique customer ID for each customer.

    The `BankCustomer` class also includes two constructors. The first constructor is a static constructor that initializes the `nextCustomerId` field with a random number eight-digit integer. The second constructor takes two parameters, `firstName` and `lastName`, and initializes the `fname` and `lName` fields with the values of the parameters. The constructor also increments `nextCustomerId` and uses the value to assign a unique value to `customerId`.

1. Open the BankAccount.cs file.

1. Take a minute to review the BankAccount class.

    ```csharp

    using System;
    
    namespace Classes_M2;
    
    public class BankAccount
    {
        private static int nextAccountNumber;
        public readonly int accountNumber;
        public double balance = 0;
        public static double interestRate;
        public string accountType = "Checking";
        public readonly string customerId;
    
        static BankAccount()
        {
            Random random = new Random();
            nextAccountNumber = random.Next(10000000, 20000000);
            interestRate = 0;
        }
    
        public BankAccount(string customerIdNumber)
        {
            this.accountNumber = nextAccountNumber++;
            this.customerId = customerIdNumber;
        }
    
        public BankAccount(string customerIdNumber, double balance, string accountType)
        {
            this.accountNumber = nextAccountNumber++;
            this.customerId = customerIdNumber;
            this.balance = balance;
            this.accountType = accountType;
        }
    }

    ```

    The `BankAccount` class includes fields for `accountNumber`, `balance`, `interestRate`, `accountType`, and `customerId`. The `accountNumber` field is read-only and is initialized in the instance constructors. The `balance` field is read-write and can be changed at any time. The `accountType` field is read-write and can be changed at any time. The `customerId` field is read-only and is initialized in the instance constructors. The `BankAccount` class also has a static field `nextAccountNumber` which is used to generate unique account numbers for each new account. This field is initialized in a static constructor, which is called only once when the class is first loaded. The static constructor uses the `Random` class to generate a random starting value for `nextAccountNumber`. Additionally, the static constructor initializes the static field `interestRate` to 0.

    The class also includes two instance constructors. The first instance constructor takes a single parameter, `customerIdNumber`, and initializes the `accountNumber` and `customerId` fields. The second instance constructor takes three parameters: `customerIdNumber`, `balance`, and `accountType`. This constructor initializes the accountNumber, customerId, balance, and accountType fields based on the provided values. Both constructors increment the nextAccountNumber to ensure that each new account has a unique account number. The static constructor initializes the `nextAccountNumber` and `interestRate` fields.

1. Open the Program.cs file.

1. Take a minute to review the code.

    ```csharp

    using Classes_M2;
    
    string firstName = "Tim";
    string lastName = "Shao";
    
    BankCustomer customer1 = new BankCustomer(firstName, lastName);
    
    firstName = "Lisa";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Sandy";
    lastName = "Zoeng";
    BankCustomer customer3 = new BankCustomer(firstName, lastName);
    
    Console.WriteLine($"BankCustomer 1: {customer1.fName} {customer1.lName} {customer1.customerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.fName} {customer2.lName} {customer2.customerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.fName} {customer3.lName} {customer3.customerId}");
    
    // Create accounts for customers
    BankAccount account1 = new BankAccount(customer1.customerId);
    BankAccount account2 = new BankAccount(customer2.customerId, 1500, "Checking");
    BankAccount account3 = new BankAccount(customer3.customerId, 2500, "Checking");
    
    Console.WriteLine($"Account 1: Account # {account1.accountNumber}, type {account1.accountType}, balance {account1.balance}, rate {BankAccount.interestRate}, customer ID {account1.customerId}");
    Console.WriteLine($"Account 2: Account # {account2.accountNumber}, type {account2.accountType}, balance {account2.balance}, rate {BankAccount.interestRate}, customer ID {account2.customerId}");
    Console.WriteLine($"Account 3: Account # {account3.accountNumber}, type {account3.accountType}, balance {account3.balance}, rate {BankAccount.interestRate}, customer ID {account3.customerId}");

    ```

    Top-level statements provide an implicit entry point for the app. The code in Program.cs demonstrates how to create and use `BankCustomer` and `BankAccount` objects. the code initializes customer details, creates three `BankCustomer` objects, and prints their information. Then, it creates three `BankAccount` objects for these customers, specifying different balances and account types, and prints the account details, including account number, type, balance, interest rate, and customer ID.

1. Run the app and review the output in the terminal window.

    Your app should produce output that's similar to the following example:

    ```plaintext

    BankCustomer 1: Tim Shao 0014653176
    BankCustomer 2: Lisa Shao 0014653177
    BankCustomer 3: Sandy Zoeng 0014653178
    Account 1: Account # 12885967, type Checking, balance 0, rate 0, customer ID 0014653176
    Account 2: Account # 12885968, type Checking, balance 1500, rate 0, customer ID 0014653177
    Account 3: Account # 12885969, type Checking, balance 2500, rate 0, customer ID 0014653178

    ```

    The customer IDs and account numbers in your output will be different from the example output. Remember that they're sequential values based on a randomly generated initial value.

## Implement properties for the BankCustomer class

In this task, you create properties for the `BankCustomer` class using `get` and `set` property accessors. Properties are used to encapsulate data and provide controlled access to the fields of a class. You create properties for the `FirstName` and `LastName` fields of the `BankCustomer` class. You also update the `Program.cs` file to use the new properties.

Use the following steps to complete this section of the exercise:

1. Open the BankCustomer.cs file.

1. To create a property for the `FirstName` field, add the following code to the bottom of `BankCustomer` class:

    ```csharp

    public string FirstName
    {
        get { return fName; }
        set { fName = value; }
    }

    ```

    The `FirstName` property is used to encapsulate the private field `fName` and provides controlled access to it.

    The `public` keyword indicates that the `FirstName` property is accessible from outside the class, meaning other classes and code can read and modify this property. The property is of type `string`, which means it holds text data.

    The property has two accessors: `get` and `set`. The `get` accessor is used to retrieve the value of the private field `fName`. When the property is accessed, the `get` accessor returns the current value of `fName`.

    The `set` accessor is used to assign a new value to the private field `fName`. The keyword `value` represents the value being assigned to the property. When a new value is assigned to `FirstName`, the `set` accessor sets `fName` to this new value.

1. To create a property for the `LastName` field, add the following code to the bottom of the `BankCustomer` class:

    ```csharp

    public string LastName
    {
        get { return lName; }
        set { lName = value; }
    }

    ```

    The `LastName` property works the same way as the `FirstName` property. It encapsulates the private field `lName` and provides controlled access to it.

1. Open the Program.cs file.

1. Locate the following code statements:

    ```C#

    Console.WriteLine($"BankCustomer 1: {customer1.fName} {customer1.lName} {customer1.customerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.fName} {customer2.lName} {customer2.customerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.fName} {customer3.lName} {customer3.customerId}");
    
    // Create accounts for customers
    BankAccount account1 = new BankAccount(customer1.customerId);
    BankAccount account2 = new BankAccount(customer2.customerId, 1500, "Checking");
    BankAccount account3 = new BankAccount(customer3.customerId, 2500, "Checking");

    ```

1. To implement the new `BankCustomer` properties, replace the code identified in the previous step with the following code snippet:

    ```csharp

    Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.customerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.customerId}");
    
    // Create accounts for customers
    BankAccount account1 = new BankAccount(customer1.customerId);
    BankAccount account2 = new BankAccount(customer2.customerId, 1500, "Checking");
    BankAccount account3 = new BankAccount(customer3.customerId, 2500, "Checking");
    
    // Demonstrate the use of BankCustomer properties
    customer1.FirstName = "Thomas";
    customer1.LastName = "Margand";
    // customer1.customerId = "1234567890"; // This line will not compile
    
    Console.WriteLine($"Updated BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");

    ```

    Notice that your code now uses the `FirstName` and `LastName` properties of the `BankCustomer` class to access the first name and last name of each customer. The code also demonstrates setting the `FirstName` and `LastName` properties top change the name of `customer1`.

    You may also notice commented code line that assigns a value to the `customerId` field directly. The `customerId` field is read-only and cannot be changed after it's initialized in the constructor. If you uncomment this code line, the code will not compile.

1. Take a minute to review your code.

    BankCustomer.cs

    ```csharp

    public class BankCustomer
    {
        private static int nextCustomerId;
        private string fName = "Tim";
        private string lName = "Shao";
        public readonly string customerId;
    
        static BankCustomer()
        {
            Random random = new Random();
            nextCustomerId = random.Next(10000000, 20000000);
        }
    
        public BankCustomer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            this.customerId = (nextCustomerId++).ToString("D10");
        }
    
        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }
    
        public string LastName
        {
            get { return lName; }
            set { lName = value; }
        }
    }

    ```

    Program.cs

    ```csharp

    string firstName = "Tim";
    string lastName = "Shao";
    
    BankCustomer customer1 = new BankCustomer(firstName, lastName);
    
    firstName = "Lisa";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Sandy";
    lastName = "Zoeng";
    BankCustomer customer3 = new BankCustomer(firstName, lastName);
    
    Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.customerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.customerId}");
    
    // Create accounts for customers
    BankAccount account1 = new BankAccount(customer1.customerId);
    BankAccount account2 = new BankAccount(customer2.customerId, 1500, "Checking");
    BankAccount account3 = new BankAccount(customer3.customerId, 2500, "Checking");
    
    // Demonstrate the use of BankCustomer properties
    customer1.FirstName = "Thomas";
    customer1.LastName = "Margand";
    // customer1.customerId = "1234567890"; // This line will not compile
    
    Console.WriteLine($"Updated BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    
    
    Console.WriteLine($"Account 1: Account # {account1.accountNumber}, type {account1.accountType}, balance {account1.balance}, rate {BankAccount.interestRate}, customer ID {account1.customerId}");
    Console.WriteLine($"Account 2: Account # {account2.accountNumber}, type {account2.accountType}, balance {account2.balance}, rate {BankAccount.interestRate}, customer ID {account2.customerId}");
    Console.WriteLine($"Account 3: Account # {account3.accountNumber}, type {account3.accountType}, balance {account3.balance}, rate {BankAccount.interestRate}, customer ID {account3.customerId}");

    ```

1. Run the app and review the output in the terminal window.

    You should see the following output:

    ```plaintext

    BankCustomer 1: Tim Shao 0010448234
    BankCustomer 2: Lisa Shao 0010448235
    BankCustomer 3: Sandy Zoeng 0010448236
    Updated BankCustomer 1: Thomas Margand 0010448234
    Account 1: Account # 16005571, type Checking, balance 0, rate 0, customer ID 0010448234
    Account 2: Account # 16005572, type Checking, balance 1500, rate 0, customer ID 0010448235
    Account 3: Account # 16005573, type Checking, balance 2500, rate 0, customer ID 0010448236

    ```

## Create automatically implemented properties for the BankAccount class

In this task, you create automatically implemented properties for the BankAccount class.

Use the following steps to complete this section of the exercise:

1. Open the BankAccount.cs file.

1. Notice that the `BankAccount` class has two public read-write fields: `balance` and `accountType`.

    - `balance` is a read-write field that can be changed at any time.
    - `accountType` is a read-write field that can be changed at any time.

    The other fields in the `BankAccount` class are either static or read-only:
    - `accountNumber` is a read-only field that is set in the constructor and cannot be changed after that.
    - `customerId` is a read-only field that is set in the constructor and cannot be changed after that.
    - `interestRate` is a static field that is shared among all instances of the `BankAccount` class.
    - `nextAccountNumber` is a static field that is shared among all instances of the `BankAccount` class.

1. To convert the `balance` and `accountType` fields to automatically implemented properties, replace the `balance` and `accountType` field declarations with the following code:

    ```csharp

    public double Balance { get; set; } = 0;
    public string AccountType { get; set; } = "Checking";

    ```

    The `Balance` and `AccountType` properties are automatically implemented properties. They encapsulates the private fields `balance` and `accountType` and provides controlled access to them.

    The `public` keyword indicates that the properties are accessible from outside the class, meaning other classes and code can read and modify the properties.

    The properties have two accessors: `get` and `set`. The `get` accessor is used to retrieve the value of the private field. When the property is accessed, the `get` accessor returns the current value of the private field.

    The `set` accessor is used to assign a new value to the private field. The keyword `value` represents the value being assigned to the property. When a new value is assigned to the property, the `set` accessor sets the private field to this new value.

    The code doesn't need to define private fields for `balance` and `accountType` because it uses auto-implemented properties for these fields. Auto-implemented properties in C# automatically create a private, anonymous backing field that stores the property value.

1. Notice that the final constructor is still assigning values to the `balance` and `accountType` fields.

    You need to update the constructor to use the new properties instead of the fields.

1. To update the constructor, replace the existing constructor with the following code:

    ```csharp

    public BankAccount(string customerIdNumber, double balance, string accountType)
    {
        this.accountNumber = nextAccountNumber++;
        this.customerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }

    ```

    This updated constructor uses the `Balance` and `AccountType` properties to set the values of the private fields `balance` and `accountType`.

1. Open the Program.cs file.

1. Locate the `Console.WriteLine` statements that display the account information.

    ```csharp

    Console.WriteLine($"Account 1: Account # {account1.accountNumber}, type {account1.accountType}, balance {account1.balance}, rate {BankAccount.interestRate}, customer ID {account1.customerId}");
    Console.WriteLine($"Account 2: Account # {account2.accountNumber}, type {account2.accountType}, balance {account2.balance}, rate {BankAccount.interestRate}, customer ID {account2.customerId}");
    Console.WriteLine($"Account 3: Account # {account3.accountNumber}, type {account3.accountType}, balance {account3.balance}, rate {BankAccount.interestRate}, customer ID {account3.customerId}");

    ```

1. To implement the new `BankAccount` properties, replace the code identified in the previous step with the following code snippet:

    ```csharp

    Console.WriteLine($"Account 1: Account # {account1.AccountNumber}, type {account1.AccountType}, balance {account1.Balance}, rate {BankAccount.interestRate}, customer ID {account1.CustomerId}");
    Console.WriteLine($"Account 2: Account # {account2.AccountNumber}, type {account2.AccountType}, balance {account2.Balance}, rate {BankAccount.interestRate}, customer ID {account2.CustomerId}");
    Console.WriteLine($"Account 3: Account # {account3.AccountNumber}, type {account3.AccountType}, balance {account3.Balance}, rate {BankAccount.interestRate}, customer ID {account3.CustomerId}");

    ```

    Notice that your code now uses the `Balance` and `AccountType` properties of the `BankAccount` class to access the balance and account type of each account.

1. Take a minute to review your code.

    BankAccount.cs

    ```csharp

    public class BankAccount
    {
        private static int nextAccountNumber;
        public readonly int accountNumber;
        public static double interestRate;
        public readonly string customerId;
        
        public double Balance { get; set; } = 0;
        public string AccountType { get; set; } = "Checking";
    
        static BankAccount()
        {
            Random random = new Random();
            nextAccountNumber = random.Next(10000000, 20000000);
            interestRate = 0;
        }
    
        public BankAccount(string customerIdNumber)
        {
            this.accountNumber = nextAccountNumber++;
            this.customerId = customerIdNumber;
        }
    
        public BankAccount(string customerIdNumber, double balance, string accountType)
        {
            this.accountNumber = nextAccountNumber++;
            this.customerId = customerIdNumber;

            this.Balance = balance;
            this.AccountType = accountType;
        }
    }
    
    ```

    Program.cs

    ```csharp

    using Classes_M1;
    
    string firstName = "Tim";
    string lastName = "Shao";
    
    BankCustomer customer1 = new BankCustomer(firstName, lastName);
    
    firstName = "Lisa";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Sandy";
    lastName = "Zoeng";
    BankCustomer customer3 = new BankCustomer(firstName, lastName);
    
    Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.customerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.customerId}");
    
    // Create accounts for customers
    BankAccount account1 = new BankAccount(customer1.customerId);
    BankAccount account2 = new BankAccount(customer2.customerId, 1500, "Checking");
    BankAccount account3 = new BankAccount(customer3.customerId, 2500, "Checking");
    
    // Demonstrate the use of BankCustomer properties
    customer1.FirstName = "Thomas";
    customer1.LastName = "Margand";
    // customer1.customerId = "1234567890"; // This line will not compile
    
    Console.WriteLine($"Updated BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    
    
    Console.WriteLine($"Account 1: Account # {account1.accountNumber}, type {account1.AccountType}, balance {account1.Balance}, rate {BankAccount.interestRate}, customer ID {account1.customerId}");
    Console.WriteLine($"Account 2: Account # {account2.accountNumber}, type {account2.AccountType}, balance {account2.Balance}, rate {BankAccount.interestRate}, customer ID {account2.customerId}");
    Console.WriteLine($"Account 3: Account # {account3.accountNumber}, type {account3.AccountType}, balance {account3.Balance}, rate {BankAccount.interestRate}, customer ID {account3.customerId}");

    ```

1. Run the app and review the output in the terminal window.

    You should see the following output:

    ```plaintext

    BankCustomer 1: Tim Shao 0014416130
    BankCustomer 2: Lisa Shao 0014416131
    BankCustomer 3: Sandy Zoeng 0014416132
    Updated BankCustomer 1: Thomas Margand 0014416130
    Account 1: Account # 13328120, type Checking, balance 0, rate 0, customer ID 0014416130
    Account 2: Account # 13328121, type Checking, balance 1500, rate 0, customer ID 0014416131
    Account 3: Account # 13328122, type Checking, balance 2500, rate 0, customer ID 0014416132

    ```

## Create read-only properties for the BankAccount class

In this task, you create read-only properties in the BankAccount classes.

Use the following steps to complete this section of the exercise:

1. Open the BankAccount.cs file.

1. Locate the two read-only fields in the `BankAccount` class: `accountNumber` and `customerId`.

    The `accountNumber` field is read-only and is set in the constructor. The `customerId` field is read-only and is set in the constructor.

    ```csharp

    public readonly int accountNumber;
    public readonly string customerId;

    ```

1. To convert the `accountNumber` and `customerId` fields to read-only properties, replace the `accountNumber` and `customerId` field declarations with the following code:

    ```csharp

    public int AccountNumber { get; }
    public string CustomerId { get; }

    ```

    The `{ get; }` syntax indicates that these properties are read-only, meaning they can be accessed (read) but not modified (written) after the object is constructed. This is useful for ensuring that the account number and customer ID remain constant once they are set.

    Read-only properties provide a level of immutability (the object's state can't be modified after it's created) and help to protect the integrity of the account data.

1. To update the two `BankAccount` constructors, replace the existing constructors with the following code:

    ```csharp

    public BankAccount(string customerIdNumber)
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = customerIdNumber;
    }

    public BankAccount(string customerIdNumber, double balance, string accountType)
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }

    ```

    The updated constructors use the `AccountNumber` and `CustomerId` properties to set the values of the private fields `accountNumber` and `customerId`.

1. Open the Program.cs file.

1. Notice that the `Console.WriteLine` statements that display the account information are still using the `accountNumber` and `customerId` fields.

    ```csharp

    Console.WriteLine($"Account 1: Account # {account1.accountNumber}, type {account1.AccountType}, balance {account1.Balance}, rate {BankAccount.interestRate}, customer ID {account1.customerId}");
    Console.WriteLine($"Account 2: Account # {account2.accountNumber}, type {account2.AccountType}, balance {account2.Balance}, rate {BankAccount.interestRate}, customer ID {account2.customerId}");
    Console.WriteLine($"Account 3: Account # {account3.accountNumber}, type {account3.AccountType}, balance {account3.Balance}, rate {BankAccount.interestRate}, customer ID {account3.customerId}");

    ```

1. To update the `Console.WriteLine` statements, replace the code identified in the previous step with the following code snippet:

    ```csharp

    Console.WriteLine($"Account 1: Account # {account1.AccountNumber}, type {account1.AccountType}, balance {account1.Balance}, rate {BankAccount.interestRate}, customer ID {account1.CustomerId}");
    Console.WriteLine($"Account 2: Account # {account2.AccountNumber}, type {account2.AccountType}, balance {account2.Balance}, rate {BankAccount.interestRate}, customer ID {account2.CustomerId}");
    Console.WriteLine($"Account 3: Account # {account3.AccountNumber}, type {account3.AccountType}, balance {account3.Balance}, rate {BankAccount.interestRate}, customer ID {account3.CustomerId}");

    ```

    Notice that your code now uses the `AccountNumber` and `CustomerId` properties of the `BankAccount` class to access the account number and customer ID of each account.

1. Take a minute to review your code.

    BankAccount.cs

    ```csharp

    public class BankAccount
    {
        private static int nextAccountNumber;
        public static double interestRate;
        public int AccountNumber { get; }
        public string CustomerId { get; }
        public double Balance { get; set; } = 0;
        public string AccountType { get; set; } = "Checking";
    
    
        static BankAccount()
        {
            Random random = new Random();
            nextAccountNumber = random.Next(10000000, 20000000);
            interestRate = 0;
        }
    
        public BankAccount(string customerIdNumber)
        {
            this.AccountNumber = nextAccountNumber++;
            this.CustomerId = customerIdNumber;
        }
    
        public BankAccount(string customerIdNumber, double balance, string accountType)
        {
            this.AccountNumber = nextAccountNumber++;
            this.CustomerId = customerIdNumber;
            this.Balance = balance;
            this.AccountType = accountType;
        }
    }

    ```

    Program.cs

    ```csharp

    using Classes_M1;
    
    string firstName = "Tim";
    string lastName = "Shao";
    
    BankCustomer customer1 = new BankCustomer(firstName, lastName);
    
    firstName = "Lisa";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Sandy";
    lastName = "Zoeng";
    BankCustomer customer3 = new BankCustomer(firstName, lastName);
    
    Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.customerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.customerId}");
    
    // Create accounts for customers
    BankAccount account1 = new BankAccount(customer1.customerId);
    BankAccount account2 = new BankAccount(customer2.customerId, 1500, "Checking");
    BankAccount account3 = new BankAccount(customer3.customerId, 2500, "Checking");
    
    // Demonstrate the use of BankCustomer properties
    customer1.FirstName = "Thomas";
    customer1.LastName = "Margand";
    // customer1.customerId = "1234567890"; // This line will not compile
    
    Console.WriteLine($"Updated BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    
    Console.WriteLine($"Account 1: Account # {account1.accountNumber}, type {account1.AccountType}, balance {account1.Balance}, rate {BankAccount.interestRate}, customer ID {account1.customerId}");
    Console.WriteLine($"Account 2: Account # {account2.accountNumber}, type {account2.AccountType}, balance {account2.Balance}, rate {BankAccount.interestRate}, customer ID {account2.customerId}");
    Console.WriteLine($"Account 3: Account # {account3.accountNumber}, type {account3.AccountType}, balance {account3.Balance}, rate {BankAccount.interestRate}, customer ID {account3.customerId}");

    ```

1. Run the app and review the output in the terminal window.

    You should see the following output:

    ```plaintext

    BankCustomer 1: Tim Shao 0010453163
    BankCustomer 2: Lisa Shao 0010453164
    BankCustomer 3: Sandy Zoeng 0010453165
    Updated BankCustomer 1: Thomas Margand 0010453163
    Account 1: Account # 15760425, type Checking, balance 0, rate 0, customer ID 0010453163
    Account 2: Account # 15760426, type Checking, balance 1500, rate 0, customer ID 0010453164
    Account 3: Account # 15760427, type Checking, balance 2500, rate 0, customer ID 0010453165

    ```

## Create methods for the BankCustomer and BankAccount classes

Methods are used to define the behavior of a class. They encapsulate the logic that operates on the data stored in the class fields.

In this task, you create methods for the `BankCustomer` and `BankAccount` classes.

Use the following steps to complete this section of the exercise:

1. Open the BankCustomer.cs file.

    The `BankCustomer` class has two properties: `FirstName` and `LastName`. Methods can be used to perform operations on these properties. For example, you can create a method to return the full name of the customer by combining the first and last names. You can also create methods to update the customer's name and display customer information.

1. Create a blank code line below the `LastName` property.

1. To create a method that returns the full name of the customer, add the following code:

    ```csharp

    public string ReturnFullName()
    {
        return $"{FirstName} {LastName}";
    }

    ```

    The `ReturnFullName` method concatenates the `FirstName` and `LastName` properties to return the full name of the customer.

1. To create a method that updates the customer's name, add the following code:

    ```csharp

    public void UpdateName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    ```

    The `UpdateName` method takes two parameters, `firstName` and `lastName`, and updates the `FirstName` and `LastName` properties with the new values.

1. To create a method that displays customer information, add the following code:

    ```csharp

    public string DisplayCustomerInfo()
    {
        return $"Customer ID: {customerId}, Name: {ReturnFullName()}";
    }

    ```

    The `DisplayCustomerInfo` method returns a string that includes the customer ID and the full name of the customer. It uses the `ReturnFullName` method to get the full name.

1. Open the BankAccount.cs file.

    The `BankAccount` class has a `Balance` property and `interestRate` field. These two class members can be used to create methods to deposit and withdraw money from the account, transfer money to another account, display account information, and apply interest to the account balance.

1. Create a blank code line below the constructors.

1. To create a method that deposits money into the account, add the following code:

    ```csharp

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    ```

    The `Deposit` method takes an amount as a parameter and adds it to the `Balance` property if the amount is greater than zero.

1. To create a method that withdraws money from the account, add the following code:

    ```csharp

    public bool Withdraw(double amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }

    ```

    The `Withdraw` method takes an amount as a parameter and subtracts it from the `Balance` property if the amount is greater than zero and the balance is sufficient. The method returns `true` if the withdrawal is successful and `false` otherwise.

1. To create a method that transfers money to another account, add the following code:

    ```csharp

    public bool Transfer(BankAccount targetAccount, double amount)
    {
        if (Withdraw(amount))
        {
            targetAccount.Deposit(amount);
            return true;
        }
        return false;
    }

    ```

    The `Transfer` method takes a `BankAccount` object and an amount as parameters. It withdraws the amount from the current account and deposits it into the target account. The method returns `true` if the transfer is successful and `false` otherwise.

1. To create a mthod that applies interest to the account balance, add the following code:

    ```csharp

    public void ApplyInterest()
    {
        Balance += Balance * interestRate;
    }

    ```

    The `ApplyInterest` method calculates the interest on the account balance using the `interestRate` field and adds the interest to the `Balance` property. At this point, the `interestRate` field is a static field that is shared among all instances of the `BankAccount` class. Since interest rate is initialized to 0, the `ApplyInterest` method doesn't actually apply any interest. You can update the `interestRate` field to a non-zero value to see the effect of the `ApplyInterest` method.

1. To create a method that displays account information, add the following code:

    ```csharp

    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {interestRate}, Customer ID: {CustomerId}";
    }

    ```

    The `DisplayAccountInfo` method returns a string that includes the account number, account type, balance, interest rate, and customer ID.

1. Take a minute to review your updated `BankCustomer` and `BankAccount` classes.

    BankCustomer.cs

    ```csharp

    public class BankCustomer
    {
        private static int nextCustomerId;
        private string fName = "Tim";
        private string lName = "Shao";
        public readonly string customerId;
    
        static BankCustomer()
        {
            Random random = new Random();
            nextCustomerId = random.Next(10000000, 20000000);
        }
    
        public BankCustomer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            this.customerId = (nextCustomerId++).ToString("D10");
        }
    
        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }
    
        public string LastName
        {
            get { return lName; }
            set { lName = value; }
        }
    
        // Method to return the full name of the customer
        public string ReturnFullName()
        {
            return $"{FirstName} {LastName}";
        }
    
        // Method to update the customer's name
        public void UpdateName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    
        // Method to display customer information
        public string DisplayCustomerInfo()
        {
            return $"Customer ID: {customerId}, Name: {FullName()}";
        }

    }
    ```

    BankAccount.cs

    ```csharp

    public class BankAccount
    {
        private static int nextAccountNumber;
        public static double interestRate;
        public int AccountNumber { get; }
        public string CustomerId { get; }
        public double Balance { get; set; } = 0;
        public string AccountType { get; set; } = "Checking";
    
        static BankAccount()
        {
            Random random = new Random();
            nextAccountNumber = random.Next(10000000, 20000000);
            interestRate = 0;
        }
    
        public BankAccount(string customerIdNumber)
        {
            this.AccountNumber = nextAccountNumber++;
            this.CustomerId = customerIdNumber;
        }
    
        public BankAccount(string customerIdNumber, double balance, string accountType)
        {
            this.AccountNumber = nextAccountNumber++;
            this.CustomerId = customerIdNumber;
            this.Balance = balance;
            this.AccountType = accountType;
        }
    
        // Method to deposit money into the account
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }
    
        // Method to withdraw money from the account
        public bool Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    
        // Method to transfer money to another account
        public bool Transfer(BankAccount targetAccount, double amount)
        {
            if (Withdraw(amount))
            {
                targetAccount.Deposit(amount);
                return true;
            }
            return false;
        }
    
        // Method to display account information
        public string DisplayAccountInfo()
        {
            return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {interestRate}, Customer ID: {CustomerId}";
        }

    }

    ```

## Create extension methods for the BankCustomer and BankAccount classes

Extension methods are a powerful feature in C# that allow you to add new methods to existing classes without modifying the original class. Extension methods are defined as static methods in a static class and are used as if they were instance methods of the extended class. If you have a class that you can't modify (for example, a class from a third-party library), you can use extension methods to add new functionality to that class. If you have access to the source code of the class, adding the new methods directly to the class is recommended. However, extension methods are useful when you can't or don't want to modify the original class.

In this task, you create extension methods for the `BankCustomer` and `BankAccount` classes.

Use the following steps to complete this section of the exercise:

1. Use the **Classes_M1** project to create a new `Extensions.cs` class file.

    You can use the `Classes_M1` project to create new class file named Extensions. Right-click the **Classes_M1** project in the Solution Explorer, select **New File**, select **Class**, and then enter **Extensions**.

    Your `Extensions` class should look similar to the following code snippet:

    ```csharp

    using System;

    namespace Classes_M1;

    public class Extensions
    {

    }

    ```

1. To replace the default `Extensions` class with an extension class for the `BankCustomer` class, update your class file to match the following code:

    ```csharp

    using System;
    
    namespace Classes_M2;
    
    public static class BankCustomerExtensions
    {
        // Extension method to check if the customer ID is valid
        public static bool IsValidCustomerId(this BankCustomer customer)
        {
            return customer.customerId.Length == 10;
        }

        // Extension method to greet the customer
        public static string GreetCustomer(this BankCustomer customer)
        {
            return $"Hello, {customer.ReturnFullName()}!";
        }
    }

    ```

    The `BankCustomerExtensions` class contains two extension methods for the `BankCustomer` class:

    - `IsValidCustomerId`: This method checks if the customer ID is valid by verifying that the length of the customer ID is 10.
    - `GreetCustomer`: This method greets the customer by returning a string that says "Hello" followed by the customer's full name. The extension method uses the `ReturnFullName` method of the `BankCustomer` class to get the full name.

1. To create extension methods for the `BankAccount` class, add the following code:

    ```csharp

    public static class BankAccountExtensions
    {
        // Extension method to check if the account is overdrawn
        public static bool IsOverdrawn(this BankAccount account)
        {
            return account.Balance < 0;
        }

        // Extension method to check if a specified amount can be withdrawn
        public static bool CanWithdraw(this BankAccount account, double amount)
        {
            return account.Balance >= amount;
        }
    }

    ```

    The `BankAccountExtensions` class contains two extension methods for the `BankAccount` class:
    - `IsOverdrawn`: This method checks if the account is overdrawn by verifying that the balance is less than zero.
    - `CanWithdraw`: This method checks if a specified amount can be withdrawn from the account by verifying that the balance is greater than or equal to the specified amount.

1. Take a minute to review the extension methods:

    ```C#

    using System;
    
    namespace Classes_M2;

    public static class BankCustomerExtensions
    {
        // Extension method to check if the customer ID is valid
        public static bool IsValidCustomerId(this BankCustomer customer)
        {
            return customer.customerId.Length == 10;
        }

        // Extension method to greet the customer
        public static string GreetCustomer(this BankCustomer customer)
        {
            return $"Hello, {customer.ReturnFullName}!";
        }
    }

    public static class BankAccountExtensions
    {
        // Extension method to check if the account is overdrawn
        public static bool IsOverdrawn(this BankAccount account)
        {
            return account.Balance < 0;
        }

        // Extension method to check if a specified amount can be withdrawn
        public static bool CanWithdraw(this BankAccount account, double amount)
        {
            return account.Balance >= amount;
        }
    }

    ```

    > [!NOTE]
    > Extension methods are passed an instance of the class they're extending as the first parameter. The `this` keyword before the parameter type indicates that the method is an extension method for that type. In this case, the `this` keyword appears before the `BankCustomer` and `BankAccount` types to indicate that the methods are extension methods for those classes.

## Update the Program.cs file to demonstrate the updated classes, properties, and methods

In this task, you update the Program.cs file to demonstrate the following steps:

1. Create BankCustomer objects.
1. Create BankAccount objects for the instantiated customers.
1. Demonstrate the use of BankCustomer properties. For example, update the customer's name.
1. Demonstrate the use of BankAccount methods. For example, deposit, withdraw, transfer, apply interest.
1. Demonstrate the use of extension methods. For example, greet the customer, check if the customer ID is valid, check if the account is overdrawn, check if a specified amount can be withdrawn.
1. Display customer and account information using the DisplayCustomerInfo and DisplayAccountInfo methods. These methods are defined in the BankCustomer and BankAccount classes, respectively.

Use the following steps to complete this section of the exercise:

1. Open the Program.cs file.

1. Replace the existing code with the following code:

    ```csharp

    using Classes_M2;
    
    // Step 1: Create BankCustomer objects
    Console.WriteLine("Creating BankCustomer objects...");
    string firstName = "Tim";
    string lastName = "Shao";
    
    BankCustomer customer1 = new BankCustomer(firstName, lastName);
    
    firstName = "Lisa";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Sandy";
    lastName = "Zoeng";
    BankCustomer customer3 = new BankCustomer(firstName, lastName);
    
    Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.customerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.customerId}");
    
    // Step 2: Create BankAccount objects for customers
    Console.WriteLine("\nCreating BankAccount objects for customers...");
    BankAccount account1 = new BankAccount(customer1.customerId);
    BankAccount account2 = new BankAccount(customer2.customerId, 1500, "Checking");
    BankAccount account3 = new BankAccount(customer3.customerId, 2500, "Checking");
    
    Console.WriteLine($"Account 1: Account # {account1.AccountNumber}, type {account1.AccountType}, balance {account1.Balance}, rate {BankAccount.interestRate}, customer ID {account1.CustomerId}");
    Console.WriteLine($"Account 2: Account # {account2.AccountNumber}, type {account2.AccountType}, balance {account2.Balance}, rate {BankAccount.interestRate}, customer ID {account2.CustomerId}");
    Console.WriteLine($"Account 3: Account # {account3.AccountNumber}, type {account3.AccountType}, balance {account3.Balance}, rate {BankAccount.interestRate}, customer ID {account3.CustomerId}");
    
    // Step 3: Demonstrate the use of BankCustomer properties
    Console.WriteLine("\nUpdating BankCustomer 1's name...");
    customer1.FirstName = "Thomas";
    customer1.LastName = "Margand";
    Console.WriteLine($"Updated BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    
    // Step 4: Demonstrate the use of BankAccount methods
    Console.WriteLine("\nDemonstrating BankAccount methods...");
    
    // Deposit
    Console.WriteLine("Depositing 500 into Account 1...");
    account1.Deposit(500);
    Console.WriteLine($"Account 1 after deposit: Balance = {account1.Balance}");
    
    // Withdraw
    Console.WriteLine("Withdrawing 200 from Account 2...");
    bool withdrawSuccess = account2.Withdraw(200);
    Console.WriteLine($"Account 2 after withdrawal: Balance = {account2.Balance}, Withdrawal successful: {withdrawSuccess}");
    
    // Transfer
    Console.WriteLine("Transferring 300 from Account 3 to Account 1...");
    bool transferSuccess = account3.Transfer(account1, 300);
    Console.WriteLine($"Account 3 after transfer: Balance = {account3.Balance}, Transfer successful: {transferSuccess}");
    Console.WriteLine($"Account 1 after receiving transfer: Balance = {account1.Balance}");
    
    // Apply interest
    Console.WriteLine("Applying interest to Account 1...");
    account1.ApplyInterest();
    Console.WriteLine($"Account 1 after applying interest: Balance = {account1.Balance}");
    
    // Step 5: Demonstrate the use of extension methods
    Console.WriteLine("\nDemonstrating extension methods...");
    Console.WriteLine(customer1.GreetCustomer());
    Console.WriteLine($"Is customer1 ID valid? {customer1.IsValidCustomerId()}");
    Console.WriteLine($"Can account2 withdraw 2000? {account2.CanWithdraw(2000)}");
    Console.WriteLine($"Is account3 overdrawn? {account3.IsOverdrawn()}");
    
    // Step 6: Display customer and account information
    Console.WriteLine("\nDisplaying customer and account information...");
    Console.WriteLine(customer1.DisplayCustomerInfo());
    Console.WriteLine(account1.DisplayAccountInfo());

    ```

1. Run the app and review the output in the terminal window.

    You should see the following output:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: Tim Shao 0012396421
    BankCustomer 2: Lisa Shao 0012396422
    BankCustomer 3: Sandy Zoeng 0012396423
    
    Creating BankAccount objects for customers...
    Account 1: Account # 11657161, type Checking, balance 0, rate 0, customer ID 0012396421
    Account 2: Account # 11657162, type Checking, balance 1500, rate 0, customer ID 0012396422
    Account 3: Account # 11657163, type Checking, balance 2500, rate 0, customer ID 0012396423
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Thomas Margand 0012396421
    
    Demonstrating BankAccount methods...
    Depositing 500 into Account 1...
    Account 1 after deposit: Balance = 500
    Withdrawing 200 from Account 2...
    Account 2 after withdrawal: Balance = 1300, Withdrawal successful: True
    Transferring 300 from Account 3 to Account 1...
    Account 3 after transfer: Balance = 2200, Transfer successful: True
    Account 1 after receiving transfer: Balance = 800
    Applying interest to Account 1...
    Account 1 after applying interest: Balance = 800
    
    Demonstrating extension methods...
    Hello, Thomas Margand!
    Is customer1 ID valid? True
    Can account2 withdraw 2000? False
    Is account3 overdrawn? False
    
    Displaying customer and account information...
    Customer ID: 0012396421, Name: Thomas Margand
    Account Number: 11657161, Type: Checking, Balance: 800, Interest Rate: 0, Customer ID: 0012396421

    ```

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
