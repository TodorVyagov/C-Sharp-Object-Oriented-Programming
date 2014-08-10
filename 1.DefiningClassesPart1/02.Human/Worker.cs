namespace HumanActions
{
    using System;

    class Worker : Human
    {
        private const int WorkDays = 5;

        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative!");
                }
                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            private set
            {
                if (value < 0 | value > 12)
                {
                    throw new ArgumentException("Incorrect work hours! Work hours must be between 0 and 12 per day!");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerDay = this.WeekSalary / WorkDays;
            return moneyPerDay / (decimal)this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " Money per hour:" + this.MoneyPerHour();
        }
    }
}
