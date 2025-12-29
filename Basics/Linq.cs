using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public class Car
    {
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public override string ToString() => $"{Year} {Make} {Model} - Color: {Color}";
    };
}
