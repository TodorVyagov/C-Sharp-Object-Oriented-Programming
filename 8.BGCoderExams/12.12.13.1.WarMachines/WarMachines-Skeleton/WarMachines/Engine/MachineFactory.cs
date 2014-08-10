namespace WarMachines.Engine
{
    using System;
    using System.Collections.Generic;

    using WarMachines.Interfaces;
    using WarMachines.Machines;

    public class MachineFactory : IMachineFactory
    {
        IList<string> names;

        public MachineFactory()
        {
            names = new List<string>();
        }

        public IPilot HirePilot(string name)
        {
            this.NameChecker(name);
            return new Pilot(name);
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            this.NameChecker(name);
            return new Tank(name, attackPoints, defensePoints);
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            this.NameChecker(name);
            return new Fighter(name, attackPoints, defensePoints, stealthMode);
        }

        private void NameChecker(string name)
        {
            if (this.names.Contains(name))
            {
                throw new ArgumentException("Name already exists! Duplicate of names is not allowed!");
            }

            this.names.Add(name);
        }
    }
}
