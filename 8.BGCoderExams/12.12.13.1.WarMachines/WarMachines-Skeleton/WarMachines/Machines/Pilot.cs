
namespace WarMachines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WarMachines.Interfaces;
    using WarMachines.Machines;

    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> engagedMachines;

        public Pilot(string name)
        {
            this.Name = name;
            engagedMachines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                // TO DO Check for name duplicate!!!

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be empty!");
                }
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (this.engagedMachines.Contains(machine))
            {
                throw new ArgumentException("One machine cannot be engaged more than once!");
            }

            this.engagedMachines.Add(machine);
            machine.Pilot = this;
        }

        public string Report()
        {
            var report = new System.Text.StringBuilder();
            string numberOfEngagedMachines = this.engagedMachines.Count == 0 ? "no" : this.engagedMachines.Count.ToString();
            string machineName = this.engagedMachines.Count == 1 ? "machine" : "machines";

            report.AppendLine(string.Format("{0} - {1} {2}", this.Name, numberOfEngagedMachines, machineName));

            var orderedMachines = engagedMachines
                .OrderBy(m => m.HealthPoints)
                .ThenBy(m => m.Name);

            foreach (var machine in orderedMachines)
            {
                report.AppendLine(machine.ToString());
            }

            return report.ToString().TrimEnd();
        }
    }
}
