namespace Bank
{
    using System;

    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, double interestRate)
            : base(customer, balance, interestRate)
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
                if (months <= 3)
                {
                    return 0;
                }
                else
                {
                    return (decimal)(this.InterestRate / 100) * money * (months - 3);//first 3 months there is no interest
                }
            }
            else //(this.Customer == Customer.Company)
            {
                if (months <= 2)
                {
                    return 0;
                }
                else
                {
                    return (decimal)(this.InterestRate / 100) * money * (months - 2);//first 2 months there is no interest
                }
            }

        }
    }
}
