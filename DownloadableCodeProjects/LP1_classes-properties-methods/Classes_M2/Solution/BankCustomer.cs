using System;

namespace Classes_M2;

public class BankCustomer
{
    private static int s_nextCustomerId;
    private string FirstName = "Tim";
    private string LastName = "Shao";
    public readonly string customerId;

    static BankCustomer()
    {
        Random random = new Random();
        s_nextCustomerId = random.Next(10000000, 20000000);
    }

    public BankCustomer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        this.customerId = (s_nextCustomerId++).ToString("D10");
    }

    public string FirstName
    {
        get { return FirstName; }
        set { FirstName = value; }
    }

    public string LastName
    {
        get { return LastName; }
        set { LastName = value; }
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
        return $"Customer ID: {customerId}, Name: {ReturnFullName()}";
    }
}