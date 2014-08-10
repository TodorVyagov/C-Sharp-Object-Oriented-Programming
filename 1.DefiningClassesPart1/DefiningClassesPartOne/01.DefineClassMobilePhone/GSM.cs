namespace DefineClassMobilePhone
{
    using System;
using System.Collections.Generic;
using System.Globalization;

    public class GSM
    {

        //Fields
        private static string iPhone4S = String.Format(@"{0,10} - {1}.
Price: {2, 26:C}
Battery model: {3, 17}.
Battery capacity: {4, 11}mAh.
Battery type: {8, 18}.
Display size: {5, 12}x{6}px.
Number of colors: {7, 14}.
{9}"
                , "Apple", "iPhone 4S", 900, "Samsung", 1432, 640, 960, 16000000, BatteryType.LiPo, GSMTest.dashes);

        private string manufacturer;
        private string model;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        public List<Call> calls = new List<Call>();

        //Constructors
        public GSM(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public GSM(string manufacturer, string model, decimal price)
            : this(manufacturer, model)
        {
            this.Price = price;
        }

        public GSM(string manufacturer, string model, decimal price, string owner) 
            : this(manufacturer, model, price)
        {
            this.Owner = owner;
        }

        public GSM(string manufacturer, string model, decimal price, string owner, string batteryModel, int batteryCapacity, BatteryType typeBattery)
            : this(manufacturer, model, price, owner)
        {
            battery = new Battery(batteryModel, batteryCapacity, typeBattery);
        }

        public GSM(string manufacturer, string model, decimal price, string owner, string batteryModel, int batteryCapacity, BatteryType typeBattery, 
            int displayHeight, int displayWidth, int numberOfColors) : this(manufacturer, model, price, owner, batteryModel, batteryCapacity, typeBattery)
        {
            display = new Display(displayHeight, displayWidth, numberOfColors);
        }

        //Properties
        public static string IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Manufacturer name cannot be empty!");
                }
                this.manufacturer = value;
            }
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
                    throw new ArgumentNullException("Model name cannot be empty!");
                }

                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price of mobile phone cannot be < 0!");
                }

                this.price = value;
            }

        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Owner name cannot be empty!");
                }

                this.owner = value;
            }
        }

        public Call CallHistory
        {
            set
            {
                this.calls.Add(value);
            }
        }

        //Methods
        public void AddCall(string date, string time, string phoneNumber, int callDuaration)
        {
            this.CallHistory = new Call(date, time, phoneNumber, callDuaration);
        }

        public void DeleteCall(int index)
        {
            this.calls.RemoveAt(index);
        }

        public void ClearCallHistory()
        {
            this.calls.Clear();
        }

        public decimal PriceOfCalls(decimal pricePerMinute)
        {
            decimal totalCost = 0;
            int totalTime = 0;

            foreach (var call in this.calls)
	        {
		        totalTime += call.CallDuaration;
	        }
            totalCost = (pricePerMinute * totalTime) / 60;

            return totalCost;
        }

        public override string ToString()
        {
            return string.Format(@"{0,10} - {1}.
Price: {2, 26:C}
Owner: {3, 25}.
Battery model: {4, 17}.
Battery capacity: {5, 11}mAh.
Battery type: {9, 18}.
Display size: {6, 12}x{7}px.
Number of colors: {8, 14}.
{10}"
                , this.manufacturer, this.model, this.price, this.owner, this.battery.Model, this.battery.Capacity,
                this.display.Height, this.display.Width, this.display.Colors, this.battery.TypeOfBattery, GSMTest.dashes);
        }
    }
}
