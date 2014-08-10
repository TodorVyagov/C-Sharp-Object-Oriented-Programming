namespace WarMachines
{
    using WarMachines.Engine;

    public class WarMachinesProgram
    {
        public static void Main()
        {
            //Tank tank = new Tank("T1000", 100, 100);
            ////System.Console.WriteLine(tank);
            //tank.ToggleDefenseMode();
            ////System.Console.WriteLine(tank);

            //Fighter fighter = new Fighter("F-16", 1000, 30, true);

            ////System.Console.WriteLine(fighter);
            //fighter.ToggleStealthMode();
            ////System.Console.WriteLine(fighter);

            //Pilot pilot = new Pilot("Frank");
            //Pilot pilot1 = new Pilot("Frank1");

            //pilot.AddMachine(tank);
            //pilot.AddMachine(fighter);
            //pilot1.AddMachine(fighter);
            //tank.Attack("fighter");
            //tank.Attack("fighter");
            //tank.Attack("fighter");
            //tank.Attack("fighter");
            //tank.Attack("fighter");

            //System.Console.WriteLine(pilot.Report());
            //System.Console.WriteLine(pilot1.Report());

            WarMachineEngine.Instance.Start();

        }
    }
}
