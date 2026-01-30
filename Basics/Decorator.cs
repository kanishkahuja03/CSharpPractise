using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    public class SimpleCoffee : ICoffee
    {
        public string GetDescription() => "Simple Coffee";
        public double GetCost() => 50;
    }

    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;

        protected CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual string GetDescription() => _coffee.GetDescription();
        public virtual double GetCost() => _coffee.GetCost();
    }

    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
            => _coffee.GetDescription() + ", Milk";

        public override double GetCost()
            => _coffee.GetCost() + 10;
    }

    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
            => _coffee.GetDescription() + ", Sugar";

        public override double GetCost()
            => _coffee.GetCost() + 5;
    }

    class Program
    {
        static void Main()
        {
                ICoffee coffee = new SimpleCoffee();
                coffee = new MilkDecorator(coffee);
                coffee = new SugarDecorator(coffee);

                Console.WriteLine(coffee.GetDescription());
                Console.WriteLine($"Cost: {coffee.GetCost()}");
        }
    }
}
