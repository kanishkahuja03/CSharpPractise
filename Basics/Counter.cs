using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    [Serializable]
    public class Counter
    {
        public int Value { get; set; }
    }
}

//    Counter counter;
//        try
//        {
//            using (FileStream fs = new FileStream("counter.dat", FileMode.OpenOrCreate))
//            {
//                if (fs.Length > 0)
//                {
//                    BinaryFormatter formatter = new BinaryFormatter();
//    counter = (Counter) formatter.Deserialize(fs);
//    Console.WriteLine("Successfully deserialized counter.");

//                }
//                else
//{
//    counter = new Counter();
//    Console.WriteLine("File is empty. Initializing new counter.");
//}
//            }
//        }
//        catch (SerializationException ex)
//        {
//            Console.WriteLine($"SerializationException: {ex.Message}");
//counter = new Counter();
//        }
//        catch (FileNotFoundException)
//        {
//    counter = new Counter();
//    Console.WriteLine("File not found. Initialization new counter.");
//}
//Console.WriteLine($"Current Value: {counter.Value}");
//counter.Value++;

//using (FileStream fs = new FileStream("counter.dat", FileMode.Create))
//{

//    BinaryFormatter formatter = new BinaryFormatter();
//    counter = (Counter)formatter.Deserialize(fs);
//    Console.WriteLine("Successfully serialized counter.");

//}
//}
