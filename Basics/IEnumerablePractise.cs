using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace IEnumerablePractise
{
    public class LogReader
    {
        static public async IAsyncEnumerable<string> GetErrorLog(TextReader reader)
        {
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (line.Contains("ERROR"))
                {
                    yield return line;
                }
            }
        }
    }

    internal class Program
    {
        public static async Task Main()
        {
            using var reader = new StreamReader("LogIEPractise.txt");
            using var writer = new StreamWriter("ErrorLog.txt");

            await foreach (var line in LogReader.GetErrorLog(reader))
            {
                await writer.WriteLineAsync(line);
            }

        }
    }
}
