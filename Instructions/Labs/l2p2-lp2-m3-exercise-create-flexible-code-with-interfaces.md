---
lab:
    title: 'Exercise - Create Flexible Code Using Interfaces'
    description: 'Create flexible and maintainable code by refactoring tightly coupled code to use interfaces in C#.'
---

In object-oriented programming, interfaces define a contract that classes can implement. They specify method signatures and properties that implementing classes must provide. This allows for consistent behavior across different types while enabling flexibility in implementation. In C#, interfaces are defined using the `interface` keyword, and classes implement them using the `: InterfaceName` syntax.

In this exercise, you will refactor a tightly coupled console application to use interfaces. By introducing interfaces and dependency injection, you will decouple the application logic from specific implementations, making the code more flexible and easier to maintain.

This exercise takes approximately **20-25 minutes** to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: [Download .NET](https://dotnet.microsoft.com/download).
1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: [Download Visual Studio Code](https://code.visualstudio.com/).
1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see [Install and configure Visual Studio Code for C# development](https://learn.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code).

## Exercise scenario

Suppose you're a software developer at a tech company working on a new project. Your team has identified that some parts of the codebase are tightly coupled, making it difficult to test and extend. To address this, you decide to refactor the code to use interfaces and dependency injection. This will decouple the application logic from specific implementations, improving flexibility and maintainability.

This exercise includes the following tasks:

1. Create a new C# project.
1. Define interfaces to abstract logging and database access.
1. Update existing classes to implement the interfaces.
1. Refactor the application to use dependency injection.
1. Test the refactored application to ensure it works as expected.

## Task 1: Create a new C# project

To start, you need to create a new C# project in your development environment. This project will serve as the foundation for refactoring the code.

1. Open Visual Studio Code.
1. Ensure that the C# Dev Kit extension is installed.
1. Open the terminal in Visual Studio Code by selecting `View > Terminal`.
1. Navigate to the directory where you want to create your project.
1. Run the following command to create a new console application:

   ```bash
   dotnet new console -n RefactorWithInterfaces
   ```

   *This command creates a new console application named `RefactorWithInterfaces`, which will serve as the starting point for the exercise.*

1. Navigate into the newly created project directory:

   ```bash
   cd RefactorWithInterfaces
   ```

   *This step ensures that you are working within the correct project directory.*

1. Open the project in Visual Studio Code:

   ```bash
   code .
   ```

   *Opening the project in Visual Studio Code allows you to edit and manage the files easily.*

### Check your work: Create a new C# project

Ensure that the project has been created successfully by verifying the presence of the `Program.cs` file in the project directory. You should also see the project structure in the Visual Studio Code Explorer pane.

## Task 2: Define interfaces to abstract logging and database access

Next, define two interfaces: one for logging and another for database access. These interfaces will serve as contracts for the application to depend on.

1. In the `RefactorWithInterfaces` project, create a new file named `ILogger.cs`.
1. Add the following code to define the `ILogger` interface:

   ```csharp
   public interface ILogger
   {
       void Log(string message);
   }
   ```

   *The `ILogger` interface defines a contract for logging functionality, ensuring that any class implementing it provides a `Log` method.*

1. Create another file named `IDataAccess.cs`.
1. Add the following code to define the `IDataAccess` interface:

   ```csharp
   public interface IDataAccess
   {
       void Connect();
       string GetData();
   }
   ```

   *The `IDataAccess` interface abstracts database operations, requiring implementing classes to provide methods for connecting to a database and retrieving data.*

### Check your work: Define interfaces

Verify that the `ILogger` and `IDataAccess` interfaces are correctly defined by checking their respective files. The `ILogger` interface should include the `Log` method, and the `IDataAccess` interface should include the `Connect` and `GetData` methods.

## Task 3: Update existing classes to implement the interfaces

Now, update the existing `ConsoleLogger` and `DatabaseAccess` classes to implement the newly defined interfaces.

1. In the `RefactorWithInterfaces` project, open the `ConsoleLogger.cs` file.
1. Modify the class to implement the `ILogger` interface:

   ```csharp
   using System;

   public class ConsoleLogger : ILogger
   {
       public void Log(string message)
       {
           Console.WriteLine($"ConsoleLogger: {message}");
       }
   }
   ```

   *The `ConsoleLogger` class now implements the `ILogger` interface, providing a concrete implementation of the `Log` method to log messages to the console.*

1. Open the `DatabaseAccess.cs` file.
1. Modify the class to implement the `IDataAccess` interface:

   ```csharp
   using System;

   public class DatabaseAccess : IDataAccess
   {
       public void Connect()
       {
           Console.WriteLine("DatabaseAccess: Connected to the database.");
       }

       public string GetData()
       {
           return "Sample Data";
       }
   }
   ```

   *The `DatabaseAccess` class now implements the `IDataAccess` interface, providing methods to connect to a database and retrieve data.*

### Check your work: Update existing classes

Ensure that the `ConsoleLogger` and `DatabaseAccess` classes correctly implement their respective interfaces by checking their files. Each class should provide concrete implementations for the methods defined in the interfaces.

## Task 4: Refactor the application to use dependency injection

Refactor the `Application` class to depend on the `ILogger` and `IDataAccess` interfaces instead of directly instantiating the `ConsoleLogger` and `DatabaseAccess` classes.

1. In the `RefactorWithInterfaces` project, create a new file named `Application.cs`.
1. Add the following code:

   ```csharp
   public class Application
   {
       private readonly ILogger _logger;
       private readonly IDataAccess _dataAccess;

       public Application(ILogger logger, IDataAccess dataAccess)
       {
           _logger = logger;
           _dataAccess = dataAccess;
       }

       public void Run()
       {
           _logger.Log("Application started.");
           _dataAccess.Connect();
           var data = _dataAccess.GetData();
           _logger.Log($"Data retrieved: {data}");
           _logger.Log("Application finished.");
       }
   }
   ```

   *The `Application` class now uses dependency injection to receive its dependencies, making it more flexible and easier to test.*

1. Open the `Program.cs` file.
1. Replace the existing code with the following:

   ```csharp
   var logger = new ConsoleLogger();
   var dataAccess = new DatabaseAccess();

   var app = new Application(logger, dataAccess);
   app.Run();
   ```

   *The `Program.cs` file creates instances of `ConsoleLogger` and `DatabaseAccess` and injects them into the `Application` class, demonstrating how dependency injection works in practice.*

### Check your work: Refactor the application

Verify that the `Application` class now depends on the `ILogger` and `IDataAccess` interfaces. Ensure that the `Program.cs` file creates instances of `ConsoleLogger` and `DatabaseAccess` and passes them to the `Application` constructor.

## Task 5: Test the refactored application

Finally, test the refactored application to ensure it works as expected.

1. Run the application using the following command:

   ```bash
   dotnet run
   ```

   *Running the application executes the refactored code, allowing you to verify its behavior.*

1. Verify the output to ensure that the application logs messages to the console and retrieves data from the database.

### Check your work: Test the refactored application

Confirm that the application runs without errors and produces the following output:

```console
ConsoleLogger: Application started.
DatabaseAccess: Connected to the database.
ConsoleLogger: Data retrieved: Sample Data
ConsoleLogger: Application finished.
```

*This output confirms that the application is functioning correctly, with logging and database operations working as expected.*

Refactoring code using techniques like interfaces and dependency injection helps decouple components, making your application more flexible and maintainable. Interfaces define clear contracts between parts of the system, while dependency injection ensures that dependencies are provided in a modular and testable way. Together, these practices improve the structure of your code, making it easier to extend, test, and adapt to future requirements.

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Additionally, building a portfolio of projects can be a great way to demonstrate your skills to potential employers.
