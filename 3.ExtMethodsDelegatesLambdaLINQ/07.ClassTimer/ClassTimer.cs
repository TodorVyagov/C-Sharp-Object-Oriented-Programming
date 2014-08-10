//Using delegates write a class Timer that has can execute certain method at each t seconds.
namespace ClassTimer
{
    using System;

    class ClassTimer
    {
        public static void PrintSomething()
        {
            Console.WriteLine(DateTime.Now);
        }

        static void Main()
        {
            Timer timer = new Timer();
            timer.method = PrintSomething;
            timer.Start(0.4, 2);
        }
    }
}
