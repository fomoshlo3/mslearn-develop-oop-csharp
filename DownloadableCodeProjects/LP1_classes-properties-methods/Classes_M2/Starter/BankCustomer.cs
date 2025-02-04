using System;

namespace Classes_M1;

/* 
//Task 1

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

*/



// Task 2

/* 
public class BankCustomer
{
    // add public fields for fName, lName, and accountID
    public string fName = "John";
    public string lName = "Doe";
    public string customerId = "1010101010";

    public BankCustomer()
    {
        Console.WriteLine($"BankCustomer created: {fName} {lName} {customerId}");
    }

    public BankCustomer(string firstName, string lastName)
    {
        fName = firstName;
        lName = lastName;

        Console.WriteLine($"BankCustomer created: {fName} {lName} {customerId}");
    }

    public BankCustomer(string firstName, string lastName, string customerIdNumber)
    {
        fName = firstName;
        lName = lastName;
        customerId = customerIdNumber;

        Console.WriteLine($"BankCustomer created: {fName} {lName} {customerId}");
    }
}

*/

/* 
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

*/


// Task 3

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

    public BankCustomer(string firstName, string lastName)
    {
        fName = firstName;
        lName = lastName;
        this.customerId = (nextCustomerId++).ToString("D10");
    }
    
}






// Task 4





