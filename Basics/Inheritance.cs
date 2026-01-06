using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance

{
    interface ILibraryMembership
    {
        abstract void DisplayMembershipDetails();
    }

    public abstract class LibraryMember : ILibraryMembership
    {
        protected string Name;
        protected int Age;

        public LibraryMember(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public abstract void DisplayMembershipDetails();
    }

    public class PremiumLibraryMember : LibraryMember
    {

        public PremiumLibraryMember(string name, int age)
            : base(name, age)
        { }

        public override void DisplayMembershipDetails()
        {
            Console.WriteLine($"Premium Library Member: {Name}, Age: {Age}");
            Console.WriteLine("Access to premium book collections");
            Console.WriteLine("Extended borrowing periods");
            Console.WriteLine("Priority reservation for new releases");
        }
    }

    public class RegularLibraryMember : LibraryMember
    {
        public RegularLibraryMember(string name, int age)
            : base(name, age)
        { }
        public override void DisplayMembershipDetails()
        {
            Console.WriteLine($"Regular Library Member: {Name}, Age: {Age}");
            Console.WriteLine("Access to standard book collections");
            Console.WriteLine("Standard borrowing periods");
        }
    }

    public class Program
    {
        public static void Main()
        {
            ILibraryMembership premiumMember = new PremiumLibraryMember("Alice", 30);
            ILibraryMembership regularMember = new RegularLibraryMember("Bob", 25);
            premiumMember.DisplayMembershipDetails();
            Console.WriteLine();
            regularMember.DisplayMembershipDetails();
        }
    }
}