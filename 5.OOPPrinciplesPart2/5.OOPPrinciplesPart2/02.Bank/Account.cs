namespace Bank
{
    using System;

    public abstract class Account
    {
        private Customer customer;
        private double interestRate; //positive

        public decimal Balance { get; protected set; } //can also be negative

        public double InterestRate
        {
            get { return this.interestRate; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Interest rate cannot be negative!");
                }
                this.interestRate = value;
            }
        }

        public Customer Customer
        {
            get { return this.customer; }
        }

        //Constructor
        protected Account(Customer customer, decimal balance, double interestRate)
        {
            this.customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public abstract decimal CalculateInterest(int months);
    }
}
