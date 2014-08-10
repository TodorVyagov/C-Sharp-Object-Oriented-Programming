namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;

    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private IList<string> targets;

        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be empty!");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Pilot cannot be null!");
                }
                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints
        {
            get;
            protected set;
        }

        public double DefensePoints
        {
            get;
            protected set;
        }

        public IList<string> Targets
        {
            get
            {
               return new List<string>(this.targets);
            }
        }

        public void Attack(string target)
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                throw new ArgumentNullException("Taarget cannot be empty!");
            }

            this.targets.Add(target);
        }

        public override string ToString()
        {
            var text = new System.Text.StringBuilder(); //I do not add it as Using, because it is used only once.
            text.AppendLine(string.Format("- {0}", this.Name));
            text.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            text.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            text.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            text.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            string targetsListed;

            if (this.Targets.Count > 0)
            {
                targetsListed = string.Join(", ", this.Targets);
            }
            else
            {
                targetsListed = "None";
            }

            text.AppendLine(string.Format(" *Targets: {0}", targetsListed));

            return text.ToString();
        }
    }
}
