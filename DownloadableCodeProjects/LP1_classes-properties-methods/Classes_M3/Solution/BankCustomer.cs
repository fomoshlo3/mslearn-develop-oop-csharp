using System;

namespace Classes_M3;

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
