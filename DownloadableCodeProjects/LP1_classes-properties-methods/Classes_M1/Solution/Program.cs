﻿using Classes_M1;

/* 
// Task 1

BankCustomer customer1 = new BankCustomer();

BankCustomer customer2 = new BankCustomer("John", "Doe");

 */


// Task 2

/* 
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


*/


// Task 3

/* 
string firstName = "John";
string lastName = "Doe";
string accountIdNumber = "1010101010";

BankCustomer customer1 = new BankCustomer();

firstName = "Jane";
BankCustomer customer2 = new BankCustomer(firstName, lastName);

firstName = "Leonardo";
lastName = "Rossi";
accountIdNumber = "2020202020";
BankCustomer customer3 = new BankCustomer(firstName, lastName, accountIdNumber);

Console.WriteLine($"BankCustomer 1: {customer1.fName} {customer1.lName} {customer1.customerId}");
Console.WriteLine($"BankCustomer 2: {customer2.fName} {customer2.lName} {customer2.customerId}");
Console.WriteLine($"BankCustomer 3: {customer3.fName} {customer3.lName} {customer3.customerId}");

// create an account for customer 3
BankAccount account1 = new BankAccount(500, "Checking");

Console.WriteLine($"Account 1: Account # {account1.accountNumber}, type {account1.accountType}, ballance {account1.balance}, rate {BankAccount.interestRate}");

*/



string firstName = "John";
string lastName = "Doe";

BankCustomer customer1 = new BankCustomer(firstName, lastName);

firstName = "Jane";
BankCustomer customer2 = new BankCustomer(firstName, lastName);

firstName = "Leonardo";
lastName = "Rossi";
BankCustomer customer3 = new BankCustomer(firstName, lastName);

Console.WriteLine($"BankCustomer 1: {customer1.fName} {customer1.lName} {customer1.customerId}");
Console.WriteLine($"BankCustomer 2: {customer2.fName} {customer2.lName} {customer2.customerId}");
Console.WriteLine($"BankCustomer 3: {customer3.fName} {customer3.lName} {customer3.customerId}");

// Create accounts for customers
BankAccount account1 = new BankAccount(customer1.customerId);
BankAccount account2 = new BankAccount(customer2.customerId, 1500, "Checking");
BankAccount account3 = new BankAccount(customer3.customerId, 2500, "Checking");

Console.WriteLine($"Account 1: Account # {account1.accountNumber}, type {account1.accountType}, balance {account1.balance}, rate {BankAccount.interestRate}, customer ID {account1.customerId}");
Console.WriteLine($"Account 2: Account # {account2.accountNumber}, type {account2.accountType}, balance {account2.balance}, rate {BankAccount.interestRate}, customer ID {account2.customerId}");
Console.WriteLine($"Account 3: Account # {account3.accountNumber}, type {account3.accountType}, balance {account3.balance}, rate {BankAccount.interestRate}, customer ID {account3.customerId}");



// Task 4