/*A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts.
Customers could be individuals or companies.
	All accounts have customer, balance and interest rate (monthly based). Deposit accounts are allowed to deposit
and with draw money. Loan and mortgage accounts can only deposit money.
All accounts can calculate their interest amount for a given period (in months). In the common case its is calculated
as follows: number_of_months * interest_rate.
Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
Deposit accounts have no interest if their balance is positive and less than 1000.
Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
Your task is to write a program to model the bank system by classes and interfaces. You should identify the classes, interfaces,
base classes and abstract actions and implement the calculation of the interest functionality through overridden methods.*/
namespace Bank
{
    using System;

    class TestingBank
    {
        static void Main()
        {
            DepositAccount depositPersonAcc = new DepositAccount(Customer.Individual, 10000.00M, 2.5);
            Console.WriteLine("Individual deposit account(balance = {0}) interest for 12 months = {1:F2}."
                , depositPersonAcc.Balance, depositPersonAcc.CalculateInterest(12));
            Console.WriteLine("Withdrawing from this account 9500.");
            depositPersonAcc.Withdraw(9500);
            Console.WriteLine("Individual deposit account(balance = {0}) interest for 12 months = {1:F2}."
    , depositPersonAcc.Balance, depositPersonAcc.CalculateInterest(12));
            Console.WriteLine("Try to withdraw 501.");
            depositPersonAcc.Withdraw(501);

            LoanAccount loanPersonAcc = new LoanAccount(Customer.Individual, -15250.35M, 2.0);
            LoanAccount loanCompanyAcc = new LoanAccount(Customer.Company, -50000, 1.5);
            Console.WriteLine("\nIndividual loan account(balance = {0}) interest for 3 months = {1:F2}."
    , loanPersonAcc.Balance, loanPersonAcc.CalculateInterest(3));
            Console.WriteLine("Individual loan account(balance = {0}) interest for 10 months = {1:F2}."
    , loanPersonAcc.Balance, loanPersonAcc.CalculateInterest(10));
            Console.WriteLine("Company loan account(balance = {0}) interest for 10 months = {1:F2}."
    , loanCompanyAcc.Balance, loanCompanyAcc.CalculateInterest(10));
            Console.WriteLine("Company loan account(balance = {0}) interest for 2 months = {1:F2}."
    , loanCompanyAcc.Balance, loanCompanyAcc.CalculateInterest(2));

            MortgageAccount mortgagePersonAcc = new MortgageAccount(Customer.Individual, -2500.50M, 3.2);
            MortgageAccount mortgageCompanyAcc = new MortgageAccount(Customer.Company, -1000M, 1);
            Console.WriteLine("\nIndividual mortgage account(balance = {0}) interest for 6 months = {1:F2}."
    , mortgagePersonAcc.Balance, mortgagePersonAcc.CalculateInterest(6));
            Console.WriteLine("Individual mortgage account(balance = {0}) interest for 10 months = {1:F2}."
    , mortgagePersonAcc.Balance, mortgagePersonAcc.CalculateInterest(10));
            Console.WriteLine("Individual mortgage account(balance = {0}) interest for 12 months = {1:F2}."
    , mortgageCompanyAcc.Balance, mortgageCompanyAcc.CalculateInterest(12)); //for first 12 months interest is 60$
            Console.WriteLine("Individual mortgage account(balance = {0}) interest for 24 months = {1:F2}."
    , mortgageCompanyAcc.Balance, mortgageCompanyAcc.CalculateInterest(24)); //for 24 months interest is 60$ for first 12months + 120$ for next 12 months
        }
    }
}
