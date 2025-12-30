using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Basics
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public static void personMain()
        {
            var jsonData = new Person { Name = "John", Age = 30 };
            File.WriteAllText("data.json", JsonConvert.SerializeObject(jsonData));

            var jsonString = File.ReadAllText("data.json");
            var jsonPerson = JsonConvert.DeserializeObject<Person>(jsonString);
            Console.WriteLine($"JSON Data: Name={jsonPerson.Name}, Age={jsonPerson.Age}");

            var xmlData = new Person { Name = "Jane", Age = 25 };
            var xmlSerializer = new XmlSerializer(xmlData.GetType());

            using(var writer = new StreamWriter("data.xml"))
            {
                xmlSerializer.Serialize(writer, xmlData);
            }

            using(var reader = new StreamReader("data.xml"))
            {
                var xmlObj = xmlSerializer.Deserialize(reader) as Person; // as is used for safe type casting
                Console.WriteLine($"XML Data: Name={xmlObj.Name}, Age={xmlObj.Age}");
            }
        }
    }
}
