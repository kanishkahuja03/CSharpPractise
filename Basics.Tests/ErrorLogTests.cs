using IEnumerablePractise;
using System.Linq;

namespace Basics.Tests
{
    [TestClass]
    public sealed class ErrorLogTests
    {
        [TestMethod]
        public async Task Test_ErrorCount()
        {
            using var reader = new StreamReader("LogIEPractise.txt");
            List<string> errorLog = await LogReader.GetErrorLog(reader).ToListAsync();
            int errorCount = errorLog.Count();
            int expectedErrors = 3;
            Assert.AreEqual(expectedErrors, errorCount, 0.001, "Number of errors are incorrect.");
        }
    }
}
