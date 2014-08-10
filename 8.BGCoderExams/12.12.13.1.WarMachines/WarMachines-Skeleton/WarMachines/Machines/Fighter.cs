namespace WarMachines
{
    using System;

    using WarMachines.Interfaces;
    using WarMachines.Machines;

    public class Fighter : Machine, IFighter
    {
        private const int InitialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = InitialHealthPoints;
            this.StealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get;
            private set;
        }

        public void ToggleStealthMode()
        {
            if (this.StealthMode)
            {
                this.StealthMode = false;
            }
            else
            {
                this.StealthMode = true;
            }
        }

        public override string ToString()
        {
            var text = new System.Text.StringBuilder(base.ToString());

            text.AppendLine(string.Format(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF"));

            return text.ToString().TrimEnd();
        }
    }
}
