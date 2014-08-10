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

        public Bunny(string name)
        {
            this.name = name;
            this.Health = InitialHealth;
            this.carrotsCount = InitialCarrots;
            this.isRetired = false;
        }

        public Bunny(string bunnyName, string playerColor)
            : this(bunnyName) //преизползване на конструктор
        {
            this.Color = playerColor;
        }



        public string Name
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

        public bool isRetired { get; set; }

        public void ChangeColor(string newColor)
        {
            this.color = newColor;
        }

        public ulong AddCarrots(int carrots)
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
                this.isRetired = true;
            }
        }
    }
}
