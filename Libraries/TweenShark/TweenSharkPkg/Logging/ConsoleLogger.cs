using System;

namespace De.Kjg.TweenSharkPkg.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string what)
        {
            Console.WriteLine("Log: " + what);
        }

        public void Error(string what)
        {
            Console.WriteLine("Error: " + what);
        }
    }
}