namespace ClassTimer
{
    using System;
    using System.Threading;

    public class Timer
    {
        public delegate void MethodToExecute();

        public MethodToExecute method;

        public void Start(double secondsInterval, int totalTimeInSeconds)
        {
            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(totalTimeInSeconds);
            while (start <= end)
            {
                method();
                Thread.Sleep((int)(secondsInterval * 1000));
                start = DateTime.Now;
            }

        }
    }
}
