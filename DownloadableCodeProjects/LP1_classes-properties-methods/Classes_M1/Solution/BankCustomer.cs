using System;

namespace Classes_M1;

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
    
}
