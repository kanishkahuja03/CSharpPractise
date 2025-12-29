using Basics;
using System.Xml.Linq;
public class Program
    {
    static void Main(string[] args)
    {
        //PremiumLibraryMember member = new PremiumLibraryMember("Alice Smith", 30);
        //member.DisplayMembershipDetails();

        //carMenu();

        xmlData();

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

    public static void carMenu()
    {
        List<Car> cars = new List<Car>
        {
            new Car { Model = "Accord", Make = "Honda", Year = 2020, Color = "Red" },
            new Car { Model = "Civic", Make = "Honda", Year = 2019, Color = "Blue" },
            new Car { Model = "Corolla", Make = "Toyota", Year = 2021, Color = "Black" },
            new Car { Model = "Camry", Make = "Toyota", Year = 2022, Color = "White" },
        };

        Console.WriteLine("Car Information System");

        while (true)
        {
            Console.WriteLine("\n1. List all cars");
            Console.WriteLine("2. Search for cars");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ListAllCars(cars);
                        break;
                    case 2:
                        SearchCars(cars);
                        break;
                    case 3:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    static void ListAllCars(List<Car> cars)
    {
        Console.WriteLine("\nAll Cars:");
        cars.ForEach(Console.WriteLine);
    }
    static void SearchCars(List<Car> cars)
    {
        Console.Write("Enter car make: ");
        string make = Console.ReadLine();
        Console.Write("Enter car model: ");
        string model = Console.ReadLine();
        var matchingCars = cars.Where(c =>
        c.Make.Equals(make, StringComparison.OrdinalIgnoreCase)
        && c.Model.Equals(model, StringComparison.OrdinalIgnoreCase)).ToList();
        Console.WriteLine(matchingCars.Any()
        ? "\nMatching Cars:\n" + string.Join("\n", matchingCars)
        : "No matching cars found.");
    }
}

