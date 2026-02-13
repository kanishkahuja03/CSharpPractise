using System;
using System.Collections.Generic;

namespace InterfaceExample
{
    public interface IShape
    {
        double CalculateArea();
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public double CalculateArea()
        {
            return Length * Width;
        }
    }

    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== Interface & Polymorphism Demo ===");

            List<IShape> shapes = new List<IShape>
            {
                new Circle(100),
                new Rectangle(50, 50)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine($"Area: {shape.CalculateArea():F2}");
            }

            Console.WriteLine("=== End of Execution ===");
        }
    }
}

