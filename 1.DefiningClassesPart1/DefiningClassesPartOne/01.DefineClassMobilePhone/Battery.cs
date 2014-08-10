namespace DefineClassMobilePhone
{
    using System;

    public class Battery
    {
        private string model;
        private int capacity;
        private BatteryType batteryType;

        public Battery()
        {
        }

        public Battery(string model, int capacity, BatteryType batteryType)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.TypeOfBattery = batteryType;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Battery model cannot be empty!");
                }

                this.model = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Capacity of battery cannot be negative!");
                }
                this.capacity = value;
            }
        }

        public BatteryType TypeOfBattery
        {
            get
            {
                return this.batteryType;
            }
            private set
            {
                this.batteryType = value;
            }
        }
    }
}
