using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Car
    {
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }
        public bool HasSunroof { get; }
        public bool HasNavigation { get; }

        internal Car(
            string brand,
            string model,
            int year,
            bool sunroof,
            bool navigation)
        {
            Brand = brand;
            Model = model;
            Year = year;
            HasSunroof = sunroof;
            HasNavigation = navigation;
        }
    }

    public interface ICarBuilder
    {
        ICarBuilder SetBrand(string brand);
        ICarBuilder SetModel(string model);
        ICarBuilder SetYear(int year);
        ICarBuilder AddSunroof();
        ICarBuilder AddNavigation();
        Car Build();
    }

    public class CarBuilder : ICarBuilder
    {
        private string _brand;
        private string _model;
        private int _year;
        private bool _sunroof;
        private bool _navigation;

        public ICarBuilder SetBrand(string brand)
        {
            _brand = brand;
            return this;
        }

        public ICarBuilder SetModel(string model)
        {
            _model = model;
            return this;
        }

        public ICarBuilder SetYear(int year)
        {
            _year = year;
            return this;
        }

        public ICarBuilder AddSunroof()
        {
            _sunroof = true;
            return this;
        }

        public ICarBuilder AddNavigation()
        {
            _navigation = true;
            return this;
        }

        public Car Build()
        {
            if (string.IsNullOrEmpty(_brand) || string.IsNullOrEmpty(_model))
                throw new InvalidOperationException("Car must have brand and model");

            return new Car(_brand, _model, _year, _sunroof, _navigation);
        }
    }

    public class Program
    {
        static void Main()
        {
            ICarBuilder builder = new CarBuilder();
            Car myCar = builder
                .SetBrand("Toyota")
                .SetModel("Camry")
                .SetYear(2022)
                .AddSunroof()
                .Build();
            Console.WriteLine($"Car: {myCar.Brand} {myCar.Model}, Year: {myCar.Year}, Sunroof: {myCar.HasSunroof}, Navigation: {myCar.HasNavigation}");
        }
    }

}