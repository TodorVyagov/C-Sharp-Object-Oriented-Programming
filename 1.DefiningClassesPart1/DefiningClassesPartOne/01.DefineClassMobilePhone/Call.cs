namespace DefineClassMobilePhone
{
    using System;
    using System.Globalization;

    public class Call
    {
        private DateTime dateAndTime; //date - dd.MM.YYYY; time - hour:minutes
        private string phoneNumber;
        private int callDuaration; //duaration in seconds

        /// <param name="date">Date in format d.M.yyyy</param>
        /// <param name="time">Time in format H:m</param>
        /// <param name="phoneNumber">Phone number. Valid symbols: digits and '+'</param>
        /// <param name="callDuaration">Call duaration in seconds</param>
        public Call(string date, string time, string phoneNumber, int callDuaration)
        {
            this.DateAndTime = date + " " + time;
            this.PhoneNumber = phoneNumber;
            this.CallDuaration = callDuaration;
        }

        private string DateAndTime
        {
            set
            {
                this.dateAndTime = DateTime.ParseExact(value, "d.M.yyyy H:m", CultureInfo.InvariantCulture);
            }
        }

        public string Date
        {
            get
            {
                return this.dateAndTime.ToString("dd.MM.yyyy");
            }
        }

        public string Time
        {
            get
            {
                return this.dateAndTime.ToString("HH:mm");
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            private set
            {
                for (int digit = 0; digit < value.Length; digit++)
                {
                    if (!char.IsDigit(value[digit]) && !(value[digit] == '+' && digit == 0))
                    {
                        throw new ArgumentException("Incorrect number! Number has to contain only digits and may have leading '+'");
                    }
                }
                this.phoneNumber = value;
            }
        }

        public int CallDuaration
        {
            get
            {
                return this.callDuaration;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Call duaration cannot be negative!");
                }
                this.callDuaration = value;
            }
        }

        public override string ToString()
        {
            return string.Format(@"Call info:
Date: {0, 20}.
Time: {1, 20}.
Phone number: {2, 4}.
Duaration: {3, 14}s.
", this.Date, this.Time, this.phoneNumber, this.callDuaration);
        }
    }
}
