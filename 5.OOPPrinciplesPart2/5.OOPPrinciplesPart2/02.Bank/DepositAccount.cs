namespace Bank
{
    using System;

    public class DepositAccount : Account, IDepositable, IWithdrawable
    {
        public DepositAccount(Customer customer, decimal balance, double interestRate) : base(customer, balance, interestRate)
        {
        }

        public void Deposit(decimal amountOfMoney)
        {
            this.Balance += amountOfMoney;
        }

        public void Withdraw(decimal amountOfMoney)
        {
            if (amountOfMoney > this.Balance)
            {
                //throw new ArgumentOutOfRangeException("Insufficient money in the account!");
                Console.WriteLine("Insufficient money in the account! You are trying to withdraw: {0}. Your balance is: {1}.", amountOfMoney, this.Balance);
                return;
            }
            this.Balance -= amountOfMoney;
        }

        public override decimal CalculateInterest(int months)
        {
            decimal money = this.Balance;

            if (money < 0)
            {
                money *= -1;
            }

            if (this.Balance >= 0 && this.Balance < 1000)
            {
                return 0;
            }
            return months * (decimal)(this.InterestRate / 100) * money;
        }
    }
}
