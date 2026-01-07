using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Application started");
            Stopwatch sw = Stopwatch.StartNew();

            Task<string> userTask = GetUserDataAsync();
            Task<string> orderTask = GetOrderDataAsync();

            Console.WriteLine("Doing other work while waiting...");

            string[] results = await Task.WhenAll(userTask, orderTask);

            Console.WriteLine(results[0]);
            Console.WriteLine(results[1]);

            Console.WriteLine($"Total time: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine("Application finished");
        }

        static async Task<string> GetUserDataAsync()
        {
            Console.WriteLine("Fetching user data...");
            await Task.Delay(3000);
            return "User data received";
        }

        static async Task<string> GetOrderDataAsync()
        {
            Console.WriteLine("Fetching order data...");
            await Task.Delay(2000);
            return "Order data received";
        }
    }
}
