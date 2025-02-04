---
lab:
    title: 'Exercise - Create classes and objects in C#'
    module: 'Get started with classes and objects in C#'
---


# Create classes and objects in C#

A class is a blueprint for creating objects and objects are the building-blocks that make up a program. In C#, you define classes using the `class` keyword. You can create objects from a class using the `new` operator. Each object created from a class is an instance of that class.

In this exercise, you create a console app that uses class definitions to instantiate objects.

This exercise takes approximately **25** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: [https://code.visualstudio.com/download](https://code.visualstudio.com/download)
1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For addition help configuring the Visual Studio Code environment, see [Install and configure Visual Studio Code for C# development](https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/)

## Exercise scenario

Suppose you're helping a non-profit company with a software project. You have experience creating structured apps in C#, but no experience with object-oriented programming. You need to gain experience before starting work on the company software. You decide to create a simple banking app that includes "BankCustomer" and "BankAccount" classes.

This exercise includes the following tasks:

1. Create a console app and a class named **BankCustomer**.
1. Update the Program.cs file to create instances of the **BankCustomer** class.
1. Add public fields and updated constructors to the BankCustomer class.
1. Update the BankCustomer class using static members to ensure unique customer IDs.
1. Create a class named BankAccount that implements static members.

## Create a console app and a class named BankCustomer

In this task, you create a new console app, add a `BankCustomer` class to the project, and then create a class definition for the `BankCustomer` class. The class definition includes public fields and a parameterless constructor.

Use the following steps to complete this task:

1. Open Visual Studio Code.

1. Use Visual Studio Code to open a new folder named **My CSharp Projects** that's located in the Windows Desktop folder.

    For example:

    1. On the Visual Studio Code welcome screen, select **Open Folder**. If the Welcome page isn't displayed in the editor, open the **File** menu and select **Open Folder**.
    1. In the **Open Folder** dialog box, navigate to the Windows Desktop folder.
    1. Select **New Folder** and name the folder **My CSharp Projects**.
    1. Select the **My CSharp Projects** folder and then select **Select Folder**.

1. Use the Command Palette to create a new console app named **Classes_M1**.

    For example:

    1. To open the Command Palette, press **Ctrl+Shift+P**.
    1. In the Command Palette, type **.NET:** and then select **.NET: New Project**.
    1. In the 'Create a new .NET Project' box, select **Console App**.
    1. In the 'Name the new project' box, type **Classes_M1** and then press Enter.
    1. In the 'Select location for the project' box, select **Default directory**
    1. In the 'Create project or view options' box, select **Create project**

    You should see a new console app project named **Classes_M1** in the Visual Studio Code EXPLORER view.

1. If the Welcome page is still open in the Visual Studio Code editor, close the Welcome page.

1. In the EXPLORER view, collapse the **MY CSHARP PROJECTS** folder structure, and then select **SOLUTION EXPLORER**.

    The Solution Explorer in Visual Studio Code is a feature provided by the C# Dev Kit extension. It offers a structured view of your application, its solutions, and its projects, making it easier to manage .NET projects within VS Code. When you open a workspace containing .NET solution files or project files, the Solution Explorer will automatically appear and load the solution files.

    Key features of the Solution Explorer include:

    - Automatically loading single or multiple solution files in a workspace.
    - Remembering the last loaded solution file for a workspace.
    - Providing context menu options for managing solutions and projects.
    - Supporting Solution Folders for organizing projects within a solution.

1. Under **SOLUTION EXPLORER**, expand the **Classes_M1** project and locate the **Program.cs** file.

    The structure of your solution should be similar to the following example:

    ```plaintext
    Classes_M1
        Classes_M1
            Dependencies
            Program.cs
    ```

1. Hover the mouse pointer over the two **Classes_M1** "folders" to reveal their association to the solution.

    The **Classes_M1** folder at the top level of the solution represents the solution folder. The **Classes_M1** folder nested under the solution folder represents the project folder. The **Program.cs** file is located within the project folder.

1. Open the **Program.cs** file, and then delete the existing "hello, world" code.

1. Right-click the **Classes_M1** project, and then select **New File**.

    If you don't see the option to create a new file, ensure that you're accessing the **Classes_M1** project folder not the **Classes_M1** solution folder.

1. In the 'Create a new file' dropdown, to create a class file named BankCustomer.cs, select **Class** and then enter **BankCustomer**.

    You should see a new file named **BankCustomer.cs** open in the Visual Studio Code editor. The file should be located in the **Classes_M1** project folder, and the code should look similar to the following code snippet:

    ```csharp

    using System;

    namespace Classes_M1;

    class BankCustomer
    {
    
    }

    ```

    At this point, your `BankCustomer` class definition is empty. You'll add constructors and fields to the class during this task.

1. Notice that a `Classes_M1` namespace is specified.

    A namespace is a way to organize code in C#. It provides a way to group related classes and other types into a single unit. You can use this namespace to access the `BankCustomer` class from other classes in the project.

1. To create a constructor for the `BankCustomer` class, add the following code to your `BankCustomer` class definition:

    ```csharp

    public BankCustomer()
    {
        Console.WriteLine("BankCustomer created");
    }

    ```

    The `BankCustomer` class now includes a parameterless constructor that writes a message to the console when a new instance of the `BankCustomer` class is created.

1. Your updated `BankCustomer` class should now look similar to the following code snippet:

    ```csharp

    public class BankCustomer
    {
        public BankCustomer()
        {
            Console.WriteLine("BankCustomer created");
        }
    }

    ```

1. To create a second constructor that accepts parameters for the bank customer's first and last name, add the following code to your `BankCustomer` class definition:

    ```csharp

    public BankCustomer(string firstName, string lastName)
    {
        Console.WriteLine($"BankCustomer created: {firstName} {lastName}");
    }

    ```

    The `BankCustomer` class now includes a second constructor that accepts parameters for the customer's first and last name. The constructor writes a message to the console that includes the customer's first and last name when a new instance of the `BankCustomer` class is created.

1. Your updated `BankCustomer` class should now look similar to the following code snippet:

    ```csharp

    public class BankCustomer
    {
        public BankCustomer()
        {
            Console.WriteLine("BankCustomer created");
        }

        public BankCustomer(string firstName, string lastName)
        {
            Console.WriteLine($"BankCustomer created: {firstName} {lastName}");
        }
    }

    ```

## Update the Program.cs file to create instances of the BankCustomer class

In this task, you update the Program.cs file to create instances of the `BankCustomer` class and run the app to verify that the instances are created successfully.

Use the following steps to complete this task:

1. Switch to the Program.cs file

    The Program.cs file is where you write the code that creates instances of the `BankCustomer` class.

1. In the Program.cs file, add the following code to create an instance of the `BankCustomer` class:

    At this point, the Program.cs file should be empty. If the "hello, world" code is still present, delete it now.

1. Add a `using` statement that specifies the namespace defined by the customer `BankCustomer` class.

    ```csharp

    using Classes_M1;

    ```

    This `using` statement allows you to access the `BankCustomer` class from within the Program.cs file.

1. To create an instance of the `BankCustomer` class, add the following code to the Program.cs file:

    ```csharp

    BankCustomer bankCustomer1 = new BankCustomer();

    ```

    The `new` operator is used to create a new instance of the `BankCustomer` class. The `BankCustomer` class constructor is called when the new instance is created.

1. To create a second instance of the `BankCustomer` class that uses the new constructor, add the following code to the Program.cs file:

    ```csharp

    BankCustomer bankCustomer2 = new BankCustomer("John", "Doe");

    ```

    The `BankCustomer` class constructor that accepts parameters for the customer's first and last name is called when the new instance is created. The constructor writes a message to the console that includes the customer's first and last name.

1. Take a minute to your Program.cs and BankCustomer.cs files.

    Program.cs file:

    ```csharp

    using Classes_M1;
    
    BankCustomer customer1 = new BankCustomer();

    BankCustomer customer2 = new BankCustomer("John", "Doe");
    
    ```

    BankCustomer.cs file:

    ```csharp

    using System;

    namespace Classes_M1;

    public class BankCustomer
    {
        public BankCustomer()
        {
            Console.WriteLine("BankCustomer created");
        }

        public BankCustomer(string firstName, string lastName)
        {
            Console.WriteLine($"BankCustomer created: {firstName} {lastName}");
        }
    }

    ```

1. Ensure that you've saved your changes to both files.

    Visual Studio Code can be configured to automatically save changes for you. If you haven't configured Visual Studio Code to automatically save changes, you can manually save your changes by selecting **File** > **Save** or **File** > **Save ALL** from the top menu bar.

1. To ensure that your solution builds without errors, right-click the **Classes_M1** solution in the Solution Explorer, and then select **Build**.

    If you don't see the **Build** option listed, ensure that you've selected the **Classes_M1** solution in the Solution Explorer. The **Build** option isn't available when a project is selected.

    You need to fix any errors before you can run your app.

1. To run your app, right-click the **Classes_M1** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    If you don't see the **Debug** option listed, ensure that you've selected the **Classes_M1** project in the Solution Explorer. The **Debug** option isn't available when a solution is selected.

    There are several ways to run your app in Visual Studio Code. For example:

    - You can use the **Run** menu
    - You can select the **Run** button in the top menu bar
    - You can use the **F5** key
    - You can use the Terminal panel and type `dotnet run`

    Any of these options is fine. Some options are more convenient than others, depending on your preferences. Also, some options use the debugger, which can be helpful when you need to step through your code.

1. Review the output in the Debug Console panel.

    You should see the following output:

    ```plaintext

    BankCustomer created
    BankCustomer created: John Doe

    ```

## Add public fields and updated constructors to the BankCustomer class

In this task, you add public fields to the `BankCustomer` class, update the instance constructors to use additional parameters, and then update the Program.cs file to access each object's public data.

Use the following steps to complete this task:

1. Open the BankCustomer.cs file.

1. Add the following public fields to the class definition:

    ```csharp

    public string fName = "John";
    public string lName = "Doe";
    public string accountId = "1010101010";

    ```

    Notice that the fields are initialized with default values.

1. Update the second constructor to assign constructor parameters to the local variables.

    ```csharp

    public BankCustomer(string firstName, string lastName)
    {
        fName = firstName;
        lName = lastName;

    ```

1. Delete the `Console.WriteLine()` messages from the constructors.

    You the update the Program.cs file to display the data using the public fields. The updated constructors should be similar to the following code snippet:

    ```csharp

    public BankCustomer()
    {

    }

    public BankCustomer(string firstName, string lastName)
    {
        fName = firstName;
        lName = lastName;

    }

    ```

1. Switch to the Program.cs file

1. Create local variables for `firstName`, `lastName`, and `accountNumber`. .

    ```csharp

    string firstName = "John";
    string lastName = "Doe";
    string customerIdNumber = "1010101010";

    ```

1. Update the code that creates the second instance of the `BankCustomer` class to use local variables.

    ```csharp

    firstName = "Jane";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    ```

1. Add code that creates a third instance of the `BankCustomer` class using the third constructor.

    ```csharp

    firstName = "Leonardo";
    lastName = "Rossi";
    accountId = "2020202020";
    BankCustomer customer3 = new BankCustomer(firstName, lastName, customerIdNumber);

    ```

1. Add `Console.WriteLine` statements that uses the objects to display the public data fields.

    ```csharp

    Console.WriteLine($"BankCustomer 1: {customer1.fName} {customer1.lName} {customer1.customerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.fName} {customer2.lName} {customer2.customerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.fName} {customer3.lName} {customer3.customerId}");

    ```

1. Take a minute to review your updated code files.

    Program.cs file:

    ```csharp

    using Classes_M1;

    namespace Classes_M1;

    string firstName = "John";
    string lastName = "Doe";
    string customerIdNumber = "1010101010";
    
    BankCustomer customer1 = new BankCustomer();
    
    firstName = "Jane";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Leonardo";
    lastName = "Rossi";
    customerIdNumber = "2020202020";
    BankCustomer customer3 = new BankCustomer(firstName, lastName, customerIdNumber);
    
    Console.WriteLine($"BankCustomer 1: {customer1.fName} {customer1.lName} {customer1.customerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.fName} {customer2.lName} {customer2.customerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.fName} {customer3.lName} {customer3.customerId}");


    ```

    BankCustomer.cs file:

    ```csharp

    using System;

    namespace Classes_M1;

    public class BankCustomer
    {
        // add public fields for fName, lName, and accountID
        public string fName = "John";
        public string lName = "Doe";
        public string customerId = "1010101010";
    
        public BankCustomer()
        {
    
        }
    
        public BankCustomer(string firstName, string lastName)
        {
            fName = firstName;
            lName = lastName;
    
        }
    
        public BankCustomer(string firstName, string lastName, string customerIdNumber)
        {
            fName = firstName;
            lName = lastName;
            customerId = customerIdNumber;
        }
    }

    ```

1. Run your updated app and verify that you get the following output:

    ```plaintext

    BankCustomer 1: John Doe 1010101010
    BankCustomer 2: Jane Doe 1010101010
    BankCustomer 3: Leonardo Rossi 2020202020

    ```

    Notice customer1 and customer2 share the same ID number. The public fields are initialized with default values. Although the constructors update the fields with the values passed as parameters, there are clearly some issues to address.

## Update the BankCustomer class using static members to ensure unique customer IDs

In this task, you update the `BankCustomer` class using a static field and static constructor to ensure unique `customerId` values are assigned to each new customer object.

Use the following steps to complete this task:

1. Use the **Classes_M1** project to create a class named `BankAccount`.

1. Open the `BankCustomer`class.

1. next step

1. next step

1. Take a minute to review the updated Program.cs and Customer.cs files.

    Program.cs file:

    ```csharp

    using Classes_M1;

    string firstName = "John";
    string lastName = "Doe";
    int accountNumber = 0;
    
    BankCustomer customer1 = new BankCustomer();
    
    firstName = "Jane";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Leonardo";
    lastName = "Rossi";
    accountNumber = 12345;
    BankCustomer customer3 = new BankCustomer(firstName, lastName, accountNumber);
    
    Console.WriteLine($"BankCustomer 1: {customer1.fName} {customer1.lName} {customer1.accNumber}");
    Console.WriteLine($"BankCustomer 2: {customer2.fName} {customer2.lName} {customer2.accNumber}");
    Console.WriteLine($"BankCustomer 3: {customer3.fName} {customer3.lName} {customer3.accNumber}");
    
    
    ```

    BankCustomer.cs file:

    ```csharp

    public class BankCustomer
    {
        private static int nextCustomerId;
        public string fName = "John";
        public string lName = "Doe";
        public readonly string customerId;
    
        static BankCustomer()
        {
            Random random = new Random();
            nextCustomerId = random.Next(10000000, 20000000);
        }
    
        public BankCustomer()
        {
            this.customerId = (nextCustomerId++).ToString("D10");
        }
    
        public BankCustomer(string firstName, string lastName)
        {
            fName = firstName;
            lName = lastName;
            this.customerId = (nextCustomerId++).ToString("D10");
        }
    
        public BankCustomer(string firstName, string lastName, string customerIdNumber)
        {
            fName = firstName;
            lName = lastName;
            customerId = customerIdNumber;
        }
    }

    ```

## Create a class named BankAccount that implements static members

In this task, you create an `BankAccount` class that initializes the interest rate as a static field.

Use the following steps to complete this task:

1. Use the **Classes_M1** project to create a class named `BankAccount`.

1. Create public fields for `accountNumber`, `balance`, `interestRate`, and `accountType`. Initialize the fields using default values.

1. Add a static field named `nextAccountNumber` to the `BankAccount` class. Initialize the field.

1. next step

1. next step

1. next step

1. next step

1. Take a minute to review your code.

    Program.cs file:

    ```csharp

    using Classes_M1;

    string firstName = "John";
    string lastName = "Doe";
    int accountNumber = 0;
    
    BankCustomer customer1 = new BankCustomer();
    
    firstName = "Jane";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Leonardo";
    lastName = "Rossi";
    accountNumber = 12345;
    BankCustomer customer3 = new BankCustomer(firstName, lastName, accountNumber);
    
    Console.WriteLine($"BankCustomer 1: {customer1.fName} {customer1.lName} {customer1.accNumber}");
    Console.WriteLine($"BankCustomer 2: {customer2.fName} {customer2.lName} {customer2.accNumber}");
    Console.WriteLine($"BankCustomer 3: {customer3.fName} {customer3.lName} {customer3.accNumber}");
    
    // create an account for customer 3
    BankAccount bankAccount1 = new BankAccount(customer3.accNumber, 500, "Checking");
    
    Console.WriteLine($"BankAccount 1: Account # {bankAccount1.accountNumber}, type {bankAccount1.accountType}, ballance {bankAccount1.balance}, rate {BankAccount.interestRate}");
    
    ```

    BankCustomer.cs file:

    ```csharp

    public class BankCustomer
    {
        private static int nextCustomerId;
        public string fName = "John";
        public string lName = "Doe";
        public readonly string customerId;
    
        static BankCustomer()
        {
            Random random = new Random();
            nextCustomerId = random.Next(10000000, 20000000);
        }
    
        public BankCustomer()
        {
            this.customerId = (nextCustomerId++).ToString("D10");
        }
    
        public BankCustomer(string firstName, string lastName)
        {
            fName = firstName;
            lName = lastName;
            this.customerId = (nextCustomerId++).ToString("D10");
        }
    
        public BankCustomer(string firstName, string lastName, string customerIdNumber)
        {
            fName = firstName;
            lName = lastName;
            customerId = customerIdNumber;
        }
    }

    ```

    BankAccount.cs file:

    ```csharp

    public class BankAccount
    {
        private static int nextAccountNumber = 1;
        public int accountNumber;
        public double balance = 0;
        public static double interestRate = 0;
        public string accountType = "Checking";
    
        public BankAccount()
        {
            this.accountNumber = nextAccountNumber++;
            Console.WriteLine($"BankAccount created: account# {accountNumber}, balance {balance}, rate {interestRate}, type {accountType}");
        }
    
        public BankAccount(double balance, string accountType)
        {
            this.accountNumber = nextAccountNumber++;
            this.balance = balance;
            this.accountType = accountType;
            Console.WriteLine($"BankAccount created: account# {accountNumber}, balance {balance}, rate {interestRate}, type {accountType}");
        }
    }

    ```

1. Run the app and review the output in the terminal window.

    You should see the following output:

    ```plaintext

    BankCustomer 1: John Doe 0014653176
    BankCustomer 2: Jane Doe 0014653177
    BankCustomer 3: Leonardo Rossi 0014653178
    Account 1: Account # 12885967, type Checking, balance 0, rate 0, customer ID 0014653176
    Account 2: Account # 12885968, type Checking, balance 1500, rate 0, customer ID 0014653177
    Account 3: Account # 12885969, type Checking, balance 2500, rate 0, customer ID 0014653178

    ```

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
