using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lambda
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Raj", Age = 25, Salary = 40000 },
                new Employee { Id = 2, Name = "Rahul", Age = 35, Salary = 60000 },
                new Employee { Id = 3, Name = "Shayam", Age = 30, Salary = 50000 },
                new Employee { Id = 4, Name = "Dev", Age = 45, Salary = 80000 },
                new Employee { Id = 5, Name = "Lata", Age = 28, Salary = 45000 }
            };

            var olderEmployees = employees.Where(e => e.Age > 30);

            Console.WriteLine("Employees older than 30:");
            foreach (var emp in olderEmployees)
            {
                Console.WriteLine(emp.Name);
            }

            var employeeNames = employees.Select(e => e.Name);

            Console.WriteLine("Employee Names:");
            foreach (var name in employeeNames)
            {
                Console.WriteLine(name);
            }

            var sortedBySalary = employees.OrderByDescending(e => e.Salary);

            Console.WriteLine("Employees sorted by salary:");
            foreach (var emp in sortedBySalary)
            {
                Console.WriteLine($"{emp.Name} - {emp.Salary}");
            }

            Func<Employee, bool> highEarner = e => e.Salary > 50000;

            Console.WriteLine("High earning employees:");
            foreach (var emp in employees.Where(highEarner))
            {
                Console.WriteLine(emp.Name);
            }

            Action<string> greet = (message) => Console.WriteLine(message);
            greet("Greeting from Lambda expressions");

            Func<int, int, int> addNumbers = (a, b) => a + b;
            Console.WriteLine($"Sum: {addNumbers(10, 20)}");

            Action<int, int> displaySum = (a, b) => Console.WriteLine(a + b);
            displaySum(10, 20);
        }
    }
}