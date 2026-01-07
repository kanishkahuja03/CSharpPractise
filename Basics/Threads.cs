using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static int total = 0;
        static object locker = new object(); // Object used for locking

        static void Main()
        {
            Task t1 = Task.Run(AddNumbers);
            Task t2 = Task.Run(AddNumbers);

            Task.WaitAll(t1, t2);

            Console.WriteLine($"Final total: {total}");
        }

        static void AddNumbers()
        {
            for (int i = 1; i <= 100000; i++)
            {
                lock (locker)  // Only one thread can access this block at a time
                {
                    total++;
                }
            }
        }
    }
}
