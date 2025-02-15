---
lab:
    title: 'Exercise - Decouple code using Interfaces'
    description: 'Create flexible and maintainable code by refactoring tightly coupled code to use interfaces in C#.'
---

# Decouple code using Interfaces

In object-oriented programming, interfaces define a contract that classes can implement. They specify method signatures and properties that implementing classes must provide. This allows for consistent behavior across different types while enabling flexibility in implementation. In C#, interfaces are defined using the `interface` keyword, and classes implement them using the `: InterfaceName` syntax.

In this exercise, you will refactor a tightly coupled console application to use interfaces. By introducing interfaces and dependency injection, you will decouple the application logic from specific implementations, making the code more flexible and easier to maintain.

This exercise takes approximately **20-25 minutes** to complete.

This exercise demonstrates how to use interfaces in C# to create flexible, reusable, and loosely coupled code. You'll learn to define and implement interfaces with default methods, use interfaces as method parameters, and work with system-defined interfaces like `IEnumerable` and `IComparable`. By the end, you'll understand how to apply these concepts to real-world scenarios.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: [Download .NET](https://dotnet.microsoft.com/download).
1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: [Download Visual Studio Code](https://code.visualstudio.com/).
1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see [Install and configure Visual Studio Code for C# development](https://learn.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code).

## Exercise scenario

Suppose you're a software developer at a tech company working on a new project. Your task is to design a system that models people in different roles, such as teachers and students, while ensuring the code is flexible, reusable, and easy to maintain. You'll achieve this by leveraging interfaces and system-defined features in C#.

## Task 1: Create a new C# project

To start, you need to create a new C# project in your development environment. This project will serve as the foundation for refactoring the code.

1. Open Visual Studio Code.
1. Ensure that the C# Dev Kit extension is installed.
1. Open the terminal in Visual Studio Code by selecting `View > Terminal`.
1. Navigate to the directory where you want to create your project.
1. Run the following command to create a new console application:

   ```bash
   dotnet new console -n DecoupleWithInterfaces
   ```

   *This command creates a new console application named `DecoupleWithInterfaces`, which will serve as the starting point for the exercise.*

1. Navigate into the newly created project directory:

   ```bash
   cd DecoupleWithInterfaces
   ```

   *This step ensures that you are working within the correct project directory.*

1. Open the project in Visual Studio Code:

   ```bash
   code .
   ```

   *Opening the project in Visual Studio Code allows you to edit and manage the files easily.*

1. Create separate files for each interface and class. For example:
   - `IPerson.cs` for the `IPerson` interface.
   - `Teacher.cs` for the `Teacher` class.
   - `Student.cs` for the `Student` class.
   - `PersonUtilities.cs` for the utility class.
   - `Classroom.cs` for the `Classroom` class.

## Task 2: Extend the IPerson Interface

You start by adding a new property and a default method to the `IPerson` interface. Default methods allow you to provide functionality directly in the interface, which can be overridden by implementing classes if needed.

Create a file named `IPerson.cs` and add the following code:

```csharp
public interface IPerson
{
    string Name { get; set; }
    int Age { get; set; }
    void DisplayInfo();

    // New property
    string Role { get; }

    // Default method
    void Greet()
    {
        Console.WriteLine($"Hello, my name is {Name} and I am a {Role}.");
    }
}
```

*This code introduces a default method and a new property to the interface, enabling shared functionality across implementing classes.*

### Check your work: Extend the IPerson Interface

Ensure the `IPerson` interface includes the `Role` property and the `Greet` method with a default implementation.

## Task 3: Update Teacher and Student Classes

The `Teacher` and `Student` classes now implement the new `Role` property. The `Teacher` class overrides the default `Greet` method, while the `Student` class uses the default implementation.

Create separate files for each class:

### `Teacher.cs`

```csharp
public class Teacher : IPerson
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;

    public string Role => "Teacher";

    public void DisplayInfo()
    {
        Console.WriteLine($"Teacher Name: {Name}, Age: {Age}");
    }

    public void Greet()
    {
        Console.WriteLine($"Hello, I am {Name}, a teacher with {Age} years of experience.");
    }
}
```

### `Student.cs`

```csharp
public class Student : IPerson, IComparable
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;

    public string Role => "Student";

    public void DisplayInfo()
    {
        Console.WriteLine($"Student Name: {Name}, Age: {Age}");
    }

    public int CompareTo(Student? other)
    {
        if (other == null) return 1;
        return this.Age.CompareTo(other.Age);
    }
}
```

*This code demonstrates how different classes can implement shared functionality while customizing behavior as needed.*

### Check your work: Update Teacher and Student Classes

Verify that the `Teacher` and `Student` classes implement the `IPerson` interface and correctly define the `Role` property and `Greet` method.

## Task 4: Use Interfaces as Method Parameters

Create a file named `PersonUtilities.cs` and add the following code:

```csharp
public class PersonUtilities
{
    public static void PrintPersonDetails(IPerson person)
    {
        person.DisplayInfo();
        person.Greet();
    }
}
```

*This code highlights the flexibility of using interfaces to handle multiple object types generically.*

### Check your work: Use Interfaces as Method Parameters

Ensure the `PersonUtilities` class can accept and process both `Teacher` and `Student` objects through the `PrintPersonDetails` method.

## Task 5: Implement System-Defined Interfaces

### Add Sorting with IComparable

The `Student` class implements the `IComparable` interface to enable sorting by age. This is already implemented in the previous task.

### Create a Classroom with IEnumerable

Create a file named `Classroom.cs` and add the following code:

```csharp
using System.Collections;
using System.Collections.Generic;

public class Classroom : IEnumerable
{
    private List students = new List();

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void SortStudentsByAge()
    {
        students.Sort(); // Uses the IComparable implementation in Student
    }

    public IEnumerator GetEnumerator()
    {
        return students.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
```

*This code shows how to create a custom collection class that supports iteration and manual sorting.*

### Check your work: Implement System-Defined Interfaces

Confirm that the `Student` class supports sorting and that the `Classroom` class allows iteration over its collection of students.

## Task 6: Update the Program Class

Update the `Program.cs` file to demonstrate all the concepts by creating `Teacher` and `Student` objects, passing them to the utility class, and working with a `Classroom` collection.

```csharp
class Program
{
    static void Main(string[] args)
    {
        IPerson teacher = new Teacher { Name = "Helen Karu", Age = 35 };
        IPerson student1 = new Student { Name = "Eba Lencho", Age = 20 };
        IPerson student2 = new Student { Name = "Frederiek Eppink", Age = 22 };

        // Use the utility class
        PersonUtilities.PrintPersonDetails(teacher);
        PersonUtilities.PrintPersonDetails(student1);

        // Create a classroom and add students
        Classroom classroom = new Classroom();
        classroom.AddStudent((Student)student1);
        classroom.AddStudent((Student)student2);

        // Sort students by age
        classroom.SortStudentsByAge();

        Console.WriteLine("\nSorted Students by Age:");
        foreach (var student in classroom)
        {
            student.DisplayInfo();
        }
    }
}
```

*The code demonstrates a complete solution by creating `Teacher` and `Student` objects, using a utility class to print their details, adding students to a `Classroom`, sorting them by age, and iterating through the sorted collection to display their information.*

### Check your work: Update the Program Class

1. Ensure that the `Program.cs` file demonstrates the following:
   - Creation of `Teacher` and `Student` objects.
   - Passing these objects to the `PersonUtilities.PrintPersonDetails` method.
   - Adding `Student` objects to a `Classroom` collection.
   - Sorting the `Classroom` collection by age.
   - Iterating over the sorted collection and displaying student details.

1. Build and run the program to verify the output:
   - Open the terminal in Visual Studio Code.
   - Run the following command to build and execute the program:

     ```bash
     dotnet run
     ```

1. The following is the console expected output:

    ```code
    Teacher Name: Helen Karu, Age: 35
    Hello, I am Helen Karu, a teacher with 35 years of experience.
    
    Student Name: Eba Lencho, Age: 20
    Hello, my name is Eba Lencho and I am a Student.
    
    Sorted Students by Age:
    Student Name: Eba Lencho, Age: 20
    Student Name: Frederiek Eppink, Age: 22
    ```

1. Review the output to ensure it matches the expected behavior:
   - The `Teacher` and `Student` details should be printed using the `PersonUtilities` class.
   - The list of students in the `Classroom` should be displayed in ascending order of age after sorting.

Refactoring code using techniques like interfaces and dependency injection helps decouple components, making your application more flexible and maintainable. Interfaces define clear contracts between parts of the system, while dependency injection ensures that dependencies are provided in a modular and testable way. Together, these practices improve the structure of your code, making it easier to extend, test, and adapt to future requirements.

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Additionally, building a portfolio of projects can be a great way to demonstrate your skills to potential employers.
