using System;

namespace Classes_M2;

public class BankCustomer
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

    // Method to return the full name of the customer
    public string FullName()
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

    // Override Equals method to compare customers by customerId
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        BankCustomer other = (BankCustomer)obj;
        return customerId == other.customerId;
    }

    // Override GetHashCode method
    public override int GetHashCode()
    {
        return customerId.GetHashCode();
    }
}

