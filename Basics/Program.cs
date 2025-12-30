using Basics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
public class Program
{
    static void Main(string[] args)
    {
        //PremiumLibraryMember member = new PremiumLibraryMember("Alice Smith", 30);
        //member.DisplayMembershipDetails();

        //Car.carMenu();

        //xmlData();

        Person.personMain();
    }


    public static void xmlData()
    {
        string inputFilePath = "input.xml";
        string outputFilePath = "output.xml";

        XElement inputXml = XElement.Load(inputFilePath);
        // Reads the xml data and creates an in-memory representation of xml data.
        // XElement is a part of LINQ to XML API in C#.

        var modifiedData = from element in inputXml.Elements("Person")
                           where (int)element.Element("Age") > 25
                           select new XElement("ModifiedPerson",
                           new XElement("Name", element.Element("Name").Value),
                           new XElement("Age", (int)element.Element("Age") + 5)
                           );

        XElement outputXml = new XElement("ModifiedData", modifiedData);
        outputXml.Save(outputFilePath);
        Console.WriteLine("Data tranfer is done to {0}", outputFilePath);
    }
}