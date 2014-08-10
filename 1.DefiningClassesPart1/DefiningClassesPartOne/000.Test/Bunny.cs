namespace BunnyWars
{
    using System;

    public class Bunny
    {
        private const int InitialHealth = 100; //INITIAL_HEALTH or InitialHealth
        private const int InitialCarrots = 0;

        private readonly string name; //fields!!!
        private string color;
        private ulong carrotsCount;

        public Bunny(string name) //Constructor
        {
            this.name = name;
            this.Health = InitialHealth; 
            this.carrotsCount = InitialCarrots;
            this.IsRetired = false;
        }

        public Bunny(string bunnyName, string playerColor) : this(bunnyName) //преизползване на конструктор
        {
            this.Color = playerColor;
        }

        public string Name //Property
        {
            get
            {
                return this.name;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set //can be private
            {
                if (value != "Blue" && value != "Red")
                {
                    throw new ArgumentException("Color must be Blue or Red!");
                }

                this.color = value;
            }
        }

        //private int Health { get; set; }; //is the same as this code below
        public int Health
        {
            get
            {
                return this.Health;
            }
            set
            {
                this.Health = value;
            }
        }

        public bool IsRetired { get; set; } //Property

        public void ChangeColor(string newColor) //Method
        {
            this.color = newColor;
        }

        public ulong AddCarrots(ulong carrots)
        {
            return this.carrotsCount += carrots;
        }

        public string SayName()
        {
            return this.name;
        }

        public void Retire()
        {
            if (this.Health <= 0)
            {
                this.IsRetired = true;
            }
        }
    }
}
