using System;

namespace Classes_M3;

// Task 1 - review

// Task 2 - Create partial classes (BankAccount)

/* 
public partial class BankCustomer
{
    private static int nextCustomerId;
    private string fName = "John";
    private string lName = "Doe";
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

*/


// Task 3 - Create a static classes (new AccountTypes class and Transactions class that contains BankAccount methods)






// Task 4 - Implement named and optional parameters






// Task 5 - Implement object initializers and copy constructors


public partial class BankCustomer
{
    private static int nextCustomerId;
    private static readonly Random random = new Random(); // Shared Random instance
    private string fName = "John";
    private string lName = "Doe";
    public readonly string customerId;

    static BankCustomer()
    {
        nextCustomerId = random.Next(10000000, 20000000);
    }

    public BankCustomer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        this.customerId = (nextCustomerId++).ToString("D10");
    }

    // Copy constructor with unique customerId
    public BankCustomer(BankCustomer existingCustomer)
    {
        this.customerId = (nextCustomerId++).ToString("D10");
        this.FirstName = existingCustomer.FirstName;
        this.LastName = existingCustomer.LastName;
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



