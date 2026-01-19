using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Logger
    {
        private static Logger _instance = new Logger();

        private Logger()
        {
        }

        public static Logger Instance => _instance;

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Program
    {
        public static void Main()
        {
            Logger.Instance.Log("Application started");

        }
    }

}
