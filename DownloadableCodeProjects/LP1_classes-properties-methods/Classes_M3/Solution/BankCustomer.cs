using System;

namespace Classes_M3;

public partial class BankCustomer
{
    private static int s_nextCustomerId;
    private string _firstName = "Tim";
    private string _lastName = "Shao";
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

    // Copy constructor with unique customerId
    public BankCustomer(BankCustomer existingCustomer)
    {
        this.customerId = (s_nextCustomerId++).ToString("D10");
        this.FirstName = existingCustomer.FirstName;
        this.LastName = existingCustomer.LastName;
    }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }
}
