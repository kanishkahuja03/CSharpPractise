using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHAndling
{
    class Program
        {
            static void Main()
            {
            try
            {
                MethodA();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Main caught exception: " + ex.Message); // Program will crash if exception is not handled
            }
            //MethodA();

                Console.WriteLine("Program continues"); // Program continues after exception is handled
        }

            static void MethodA()
            {
                try
                {
                    MethodB();
                }
                catch (MyCustomException ex)
                {
                    Console.WriteLine("MethodA caught exception: " + ex.Message);
                    throw; // rethrow to Main
                }
            }
            static void MethodB()
            {
                Console.WriteLine("MethodB running");
                throw new MyCustomException("Something went wrong in MethodB");
            }
    }

    public class MyCustomException : Exception
    {
        public MyCustomException() { }
        public MyCustomException(string message) : base("Message by Custom Exception, " + message) { }
    }
}
