using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarMachines
{
    public class Tank : WarMachines.Machines.Machine, WarMachines.Interfaces.ITank
    {
        private const int InitialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = InitialHealthPoints;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode
        {
            get;
            private set;
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
                this.DefenseMode = false;
            }
            else
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
                this.DefenseMode = true;
            }
        }

        public override string ToString()
        {
            var text = new System.Text.StringBuilder(base.ToString());

            text.AppendLine(string.Format(" *Defense: {0}", (this.DefenseMode ? "ON" : "OFF")));

            return text.ToString().TrimEnd();
        }
    }
}
