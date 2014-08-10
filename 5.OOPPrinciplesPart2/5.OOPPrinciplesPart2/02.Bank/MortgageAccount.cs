namespace Bank
{
    using System;

    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, double interestRate) : base(customer, balance, interestRate)
        {
        }

        public void Deposit(decimal amountOfMoney)
        {
            this.Balance += amountOfMoney;
        }

        public override decimal CalculateInterest(int months)
        {
            decimal money = this.Balance;

            if (money < 0)
            {
                money *= -1;
            }

            if (this.Customer == Customer.Individual)
            {
                if (months <= 6)
                {
                    return 0;
                }
                else
                {
                    return (decimal)(this.InterestRate / 100) * money * (months - 6);//first 6 months there is no interest
                }
            }
            else //(this.Customer == Customer.Company) // 1/2 interest for the first 12 months
            {
                if (months <= 12)
                {
                    return ((decimal)(this.InterestRate / 100) * money * months) / 2;
                }
                else
                {
                    decimal firstYearInterest = ((decimal)(this.InterestRate / 100) * money * 12) / 2;
                    return (decimal)(this.InterestRate / 100) * money * (months - 12) + firstYearInterest; 
                }
            }
        }
    }
}
