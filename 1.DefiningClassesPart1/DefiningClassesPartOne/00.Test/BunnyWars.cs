namespace BunnyWars
{
    using System;

    class BunnyWars
    {
        static void Main()
        {
            Bunny vankata = new Bunny("Vanka");
            vankata.ChangeColor("Blue");
            ulong currentVankataCarrots = vankata.AddCarrots(100);
            //Console.WriteLine("Vankata carrots = " + currentVankataCarrots);

            Bunny pesho = new Bunny("Pesho", "Green");
            ulong currentPeshoCarrots = vankata.AddCarrots(2000);
            //Console.WriteLine("Pesho carrots = " + currentPeshoCarrots);

            string vankataName = vankata.Name;
            Console.WriteLine(vankataName);
        }
    }
}
